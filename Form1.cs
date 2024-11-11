using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace CuartoEM
{
    public partial class Form1 : Form
    {
        private string connectionString;

        public Form1()
        {
            InitializeComponent();
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Historia_Medieval.db");
            connectionString = $"Data Source={dbPath};Version=3;";
            LoadComboBoxData();
            LoadPersonajesComboBox();
            LoadTipoRelacionComboBox();
        }

        private void LoadComboBoxData() // puebla el comboBox1 con los nombres y apellidos de los personajes
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT nombre, apellido FROM personajes";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string fullName = $"{reader["nombre"]}, {reader["apellido"]}";
                                comboBox1.Items.Add(fullName);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoadPersonajesComboBox() // puebla los comboBoxPersonaje1 y comboBoxPersonaje2 con los nombres y apellidos de los personajes
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, nombre, apellido FROM personajes";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string fullName = $"{reader["id"]}: {reader["nombre"]} {reader["apellido"]}";
                                comboBoxPersonaje1.Items.Add(fullName);
                                comboBoxPersonaje2.Items.Add(fullName);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoadTipoRelacionComboBox()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, nombre FROM tipos_relaciones_familiares";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tipoRelacion = $"{reader["id"]}: {reader["nombre"]}";
                                comboBoxTipoRelacion.Items.Add(tipoRelacion);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private bool ValidarFechas(out DateTime? fechaInicio, out DateTime? fechaFin)
        {
            fechaInicio = null;
            fechaFin = null;

            if (comboBoxTipoRelacion.SelectedItem.ToString().Contains("esposos"))
            {
                if (!DateTime.TryParse(textBoxFechaInicio.Text, out DateTime tempFechaInicio))
                {
                    MessageBox.Show("Fecha de inicio no válida.");
                    return false;
                }
                fechaInicio = tempFechaInicio;

                if (!DateTime.TryParse(textBoxFechaFin.Text, out DateTime tempFechaFin))
                {
                    MessageBox.Show("Fecha de fin no válida.");
                    return false;
                }
                fechaFin = tempFechaFin;

                if (fechaInicio.Value.Year < 500 || fechaFin.Value.Year < 500)
                {
                    MessageBox.Show("Las fechas deben ser a partir del siglo VI.");
                    return false;
                }
            }

            return true;
        }

        private void addRelationButton_Click(object sender, EventArgs e)
        {
            if (!ValidarFechas(out DateTime? fechaInicio, out DateTime? fechaFin))
            {
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO parentescos (personaje_id1, personaje_id2, tipo_relacion_id, fecha_inicio, fecha_fin) VALUES (@personaje_id1, @personaje_id2, @tipo_relacion_id, @fecha_inicio, @fecha_fin)";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        int personajeId1 = int.Parse(comboBoxPersonaje1.SelectedItem.ToString().Split(':')[0]);
                        int personajeId2 = int.Parse(comboBoxPersonaje2.SelectedItem.ToString().Split(':')[0]);
                        int tipoRelacionId = int.Parse(comboBoxTipoRelacion.SelectedItem.ToString().Split(':')[0]);

                        command.Parameters.AddWithValue("@personaje_id1", personajeId1);
                        command.Parameters.AddWithValue("@personaje_id2", personajeId2);
                        command.Parameters.AddWithValue("@tipo_relacion_id", tipoRelacionId);

                        if (fechaInicio.HasValue)
                        {
                            command.Parameters.AddWithValue("@fecha_inicio", fechaInicio.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@fecha_inicio", DBNull.Value);
                        }

                        if (fechaFin.HasValue)
                        {
                            command.Parameters.AddWithValue("@fecha_fin", fechaFin.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@fecha_fin", DBNull.Value);
                        }

                        command.ExecuteNonQuery();
                    }

                    // Consulta para obtener la relación recíproca
                    string queryReciproca = "SELECT reciproca FROM tipos_relaciones_familiares WHERE id = @tipo_relacion_id";
                    using (SQLiteCommand commandReciproca = new SQLiteCommand(queryReciproca, connection))
                    {
                        int personajeId1 = int.Parse(comboBoxPersonaje1.SelectedItem.ToString().Split(':')[0]);
                        int personajeId2 = int.Parse(comboBoxPersonaje2.SelectedItem.ToString().Split(':')[0]);
                        int tipoRelacionId = int.Parse(comboBoxTipoRelacion.SelectedItem.ToString().Split(':')[0]);

                        commandReciproca.Parameters.AddWithValue("@tipo_relacion_id", tipoRelacionId);
                        object result = commandReciproca.ExecuteScalar();

                        if (result != null)
                        {
                            string resultString = result.ToString();
                            MessageBox.Show($"Valor de result: {resultString}");

                            // Realizar una consulta adicional para obtener el ID de la relación recíproca
                            string queryReciprocaId = "SELECT id FROM tipos_relaciones_familiares WHERE nombre = @nombre";
                            using (SQLiteCommand commandReciprocaId = new SQLiteCommand(queryReciprocaId, connection))
                            {
                                commandReciprocaId.Parameters.AddWithValue("@nombre", resultString);
                                object reciprocaIdResult = commandReciprocaId.ExecuteScalar();

                                if (reciprocaIdResult != null && int.TryParse(reciprocaIdResult.ToString(), out int tipoRelacionReciproca))
                                {
                                    // Insertar el parentesco recíproco
                                    string queryReciprocaInsert = "INSERT INTO parentescos (personaje_id1, personaje_id2, tipo_relacion_id, fecha_inicio, fecha_fin) VALUES (@personaje_id1, @personaje_id2, @tipo_relacion_id, @fecha_inicio, @fecha_fin)";
                                    using (SQLiteCommand commandReciprocaInsert = new SQLiteCommand(queryReciprocaInsert, connection))
                                    {
                                        commandReciprocaInsert.Parameters.AddWithValue("@personaje_id1", personajeId2);
                                        commandReciprocaInsert.Parameters.AddWithValue("@personaje_id2", personajeId1);
                                        commandReciprocaInsert.Parameters.AddWithValue("@tipo_relacion_id", tipoRelacionReciproca);

                                        if (fechaInicio.HasValue)
                                        {
                                            commandReciprocaInsert.Parameters.AddWithValue("@fecha_inicio", fechaInicio.Value);
                                        }
                                        else
                                        {
                                            commandReciprocaInsert.Parameters.AddWithValue("@fecha_inicio", DBNull.Value);
                                        }

                                        if (fechaFin.HasValue)
                                        {
                                            commandReciprocaInsert.Parameters.AddWithValue("@fecha_fin", fechaFin.Value);
                                        }
                                        else
                                        {
                                            commandReciprocaInsert.Parameters.AddWithValue("@fecha_fin", DBNull.Value);
                                        }

                                        commandReciprocaInsert.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se encontró un ID de relación recíproca válido.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontró una relación recíproca válida.");
                        }
                    }

                    MessageBox.Show("Relación y relación recíproca agregadas exitosamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFullName = comboBox1.SelectedItem.ToString();
            string[] nameParts = selectedFullName.Split(new string[] { ", " }, StringSplitOptions.None);
            string selectedName = nameParts[0];
            string selectedSurname = nameParts[1];
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT nombre, apellido, mote, fecha_nacimiento, fecha_muerte, importancia, biografia FROM personajes WHERE nombre = @Nombre AND apellido = @Apellido";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", selectedName);
                        command.Parameters.AddWithValue("@Apellido", selectedSurname);
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox1.Text = reader["nombre"].ToString();
                                textBox2.Text = reader["apellido"].ToString();
                                textBox3.Text = reader["mote"].ToString();
                                textBox4.Text = reader["fecha_nacimiento"].ToString();
                                textBox5.Text = reader["fecha_muerte"].ToString();
                                textBox6.Text = reader["importancia"].ToString();
                                richTextBox1.Text = reader["biografia"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO personajes (nombre, apellido, mote, fecha_nacimiento, fecha_muerte, importancia, biografia) " +
                                   "VALUES (@Nombre, @Apellido, @Mote, @FechaNacimiento, @FechaMuerte, @Importancia, @Biografia)";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", textBox1.Text);
                        command.Parameters.AddWithValue("@Apellido", textBox2.Text);
                        command.Parameters.AddWithValue("@Mote", textBox3.Text);
                        command.Parameters.AddWithValue("@FechaNacimiento", textBox4.Text);
                        command.Parameters.AddWithValue("@FechaMuerte", textBox5.Text);
                        command.Parameters.AddWithValue("@Importancia", textBox6.Text);
                        command.Parameters.AddWithValue("@Biografia", richTextBox1.Text);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Personaje agregado exitosamente.");
                        LoadComboBoxData();
                        LoadPersonajesComboBox();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void comboBoxTipoRelacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoRelacion.SelectedItem.ToString().Contains("esposos"))
            {
                textBoxFechaInicio.Visible = true;
                textBoxFechaFin.Visible = true;
            }
            else
            {
                textBoxFechaInicio.Visible = false;
                textBoxFechaFin.Visible = false;
            }
        }

        private void comboBoxPersonaje1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPersonaje1.SelectedItem == null)
            {
                MessageBox.Show("No se ha seleccionado ningún personaje.");
                return;
            }

            string selectedFullName = comboBoxPersonaje1.SelectedItem.ToString();
            string[] nameParts = selectedFullName.Split(new string[] { ": " }, StringSplitOptions.None);
            if (nameParts.Length < 2)
            {
                MessageBox.Show("Formato de nombre no válido.");
                return;
            }

            if (!int.TryParse(nameParts[0], out int selectedId))
            {
                MessageBox.Show("ID de personaje no válido.");
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT p2.nombre || ' ' || p2.apellido AS Parentesco, tr.nombre AS TipoRelacion " +
                                   "FROM parentescos p " +
                                   "JOIN personajes p2 ON p.personaje_id2 = p2.id " +
                                   "JOIN tipos_relaciones_familiares tr ON p.tipo_relacion_id = tr.id " +
                                   "WHERE p.personaje_id1 = @PersonajeId";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonajeId", selectedId);
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            comboBoxParentescos.Items.Clear();
                            while (reader.Read())
                            {
                                string parentesco = $"{reader["TipoRelacion"]} ({reader["Parentesco"]})";
                                comboBoxParentescos.Items.Add(parentesco);
                            }
                        }
                    }
                    if (comboBoxParentescos.Items.Count > 0)
                    {
                        comboBoxParentescos.Visible = true;
                        comboBoxParentescos.DroppedDown = true; // Despliega el ComboBox automáticamente
                        //MessageBox.Show("Parentescos cargados correctamente.");
                    }
                    else
                    {
                        comboBoxParentescos.Visible = false;
                        MessageBox.Show("No se encontraron parentescos para el personaje seleccionado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
