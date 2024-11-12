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
            LoadTipoRelacionSociopoliticaComboBox();
            LoadPersonajesSociopoliticaComboBox();
            LoadcomboBoxPersonajeInstitucion();
            LoadInstitucionesComboBox();
            LoadTipoRelacionInstitucionComboBox();
        }

        private void LoadComboBoxData() // puebla el masterPersonasComboBox con los nombres y apellidos de los personajes
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
                                masterPersonasComboBox.Items.Add(fullName);
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

        private void masterPersonasComboBox_selectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFullName = masterPersonasComboBox.SelectedItem.ToString();
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

        private void LoadTipoRelacionSociopoliticaComboBox()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, nombre FROM tipos_relaciones_sociopoliticas";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tipoRelacion = $"{reader["id"]}: {reader["nombre"]}";
                                comboBoxTipoRelacionSociopolitica.Items.Add(tipoRelacion);
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

        private void LoadPersonajesSociopoliticaComboBox()
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
                                comboBoxPersonaje1Sociopolitica.Items.Add(fullName);
                                comboBoxPersonaje2Sociopolitica.Items.Add(fullName);
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

        private void addSociopoliticaRelationButton_Click(object sender, EventArgs e)
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
                    string query = "INSERT INTO relaciones_sociopoliticas (personaje_id1, personaje_id2, tipo_relacion_id, fecha_inicio, fecha_fin) VALUES (@personaje_id1, @personaje_id2, @tipo_relacion_id, @fecha_inicio, @fecha_fin)";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        int personajeId1 = int.Parse(comboBoxPersonaje1Sociopolitica.SelectedItem.ToString().Split(':')[0]);
                        int personajeId2 = int.Parse(comboBoxPersonaje2Sociopolitica.SelectedItem.ToString().Split(':')[0]);
                        int tipoRelacionId = int.Parse(comboBoxTipoRelacionSociopolitica.SelectedItem.ToString().Split(':')[0]);

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
                    string queryReciproca = "SELECT reciproca FROM tipos_relaciones_sociopoliticas WHERE id = @tipo_relacion_id";
                    using (SQLiteCommand commandReciproca = new SQLiteCommand(queryReciproca, connection))
                    {
                        //int personajeId1 = int.Parse(comboBoxPersonaje1Sociopolitica.SelectedItem.ToString().Split(':')[0]);
                        //int personajeId2 = int.Parse(comboBoxPersonaje2Sociopolitica.SelectedItem.ToString().Split(':')[0]);
                        int tipoRelacionId = int.Parse(comboBoxTipoRelacionSociopolitica.SelectedItem.ToString().Split(':')[0]);

                        commandReciproca.Parameters.AddWithValue("@tipo_relacion_id", tipoRelacionId);
                        object result = commandReciproca.ExecuteScalar();

                        if (result != null)
                        {
                            string resultString = result.ToString();
                            MessageBox.Show($"Valor de result: {resultString}");

                            // Realizar una consulta adicional para obtener el ID de la relación recíproca
                            string queryReciprocaId = "SELECT id FROM tipos_relaciones_sociopoliticas WHERE nombre = @nombre";
                            using (SQLiteCommand commandReciprocaId = new SQLiteCommand(queryReciprocaId, connection))
                            {
                                int personajeId1 = int.Parse(comboBoxPersonaje1Sociopolitica.SelectedItem.ToString().Split(':')[0]);
                                int personajeId2 = int.Parse(comboBoxPersonaje2Sociopolitica.SelectedItem.ToString().Split(':')[0]);
                                //int tipoRelacionId = int.Parse(comboBoxTipoRelacionSociopolitica.SelectedItem.ToString().Split(':')[0]);


                                commandReciprocaId.Parameters.AddWithValue("@nombre", resultString);
                                object reciprocaIdResult = commandReciprocaId.ExecuteScalar();

                                if (reciprocaIdResult != null && int.TryParse(reciprocaIdResult.ToString(), out int tipoRelacionReciproca))
                                {
                                    // Insertar la relación recíproca
                                    string queryReciprocaInsert = "INSERT INTO relaciones_sociopoliticas (personaje_id1, personaje_id2, tipo_relacion_id, fecha_inicio, fecha_fin) VALUES (@personaje_id1, @personaje_id2, @tipo_relacion_id, @fecha_inicio, @fecha_fin)";
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

                    MessageBox.Show("Relación sociopolítica y relación recíproca agregadas exitosamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void comboBoxPersonaje1Sociopolitica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPersonaje1Sociopolitica.SelectedItem == null)
            {
                MessageBox.Show("No se ha seleccionado ningún personaje.");
                return;
            }

            string selectedFullName = comboBoxPersonaje1Sociopolitica.SelectedItem.ToString();
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
                    string query = "SELECT p2.nombre || ' ' || p2.apellido AS Relacion, tr.nombre AS TipoRelacion " +
                                   "FROM relaciones_sociopoliticas rs " +
                                   "JOIN personajes p2 ON rs.personaje_id2 = p2.id " +
                                   "JOIN tipos_relaciones_sociopoliticas tr ON rs.tipo_relacion_id = tr.id " +
                                   "WHERE rs.personaje_id1 = @PersonajeId";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonajeId", selectedId);
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            comboBoxRelacionesSociopoliticas.Items.Clear();
                            while (reader.Read())
                            {
                                string relacion = $"{reader["TipoRelacion"]} ({reader["Relacion"]})";
                                comboBoxRelacionesSociopoliticas.Items.Add(relacion);
                            }
                        }
                    }
                    if (comboBoxRelacionesSociopoliticas.Items.Count > 0)
                    {
                        comboBoxRelacionesSociopoliticas.Visible = true;
                        comboBoxRelacionesSociopoliticas.DroppedDown = true; // Despliega el ComboBox automáticamente
                                                                             //MessageBox.Show("Relaciones sociopolíticas cargadas correctamente.");
                    }
                    else
                    {
                        comboBoxRelacionesSociopoliticas.Visible = false;
                        MessageBox.Show("No se encontraron relaciones sociopolíticas para el personaje seleccionado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadcomboBoxPersonajeInstitucion()
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
                                comboBoxPersonajeInstitucion.Items.Add(fullName);
                                //comboBoxInstitucion.Items.Add(fullName);
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

        private void LoadInstitucionesComboBox()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, nombre FROM instituciones";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string institucion = $"{reader["id"]}: {reader["nombre"]}";
                                comboBoxInstitucion.Items.Add(institucion);
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

        private void LoadTipoRelacionInstitucionComboBox()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, nombre FROM tipos_relaciones_instituciones";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            comboBoxTipoRelacionInstitucion.Items.Clear();
                            while (reader.Read())
                            {
                                string tipoRelacion = $"{reader["id"]}: {reader["nombre"]}";
                                comboBoxTipoRelacionInstitucion.Items.Add(tipoRelacion);
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

        private void addInstitucionRelationButton_Click(object sender, EventArgs e)
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
                    string query = "INSERT INTO relaciones_instituciones (personaje_id, institucion_id, tipo_relacion_id, fecha_inicio, fecha_fin) VALUES (@personaje_id, @institucion_id, @tipo_relacion_id, @fecha_inicio, @fecha_fin)";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        int personajeId = int.Parse(comboBoxPersonajeInstitucion.SelectedItem.ToString().Split(':')[0]);
                        int institucionId = int.Parse(comboBoxInstitucion.SelectedItem.ToString().Split(':')[0]);
                        int tipoRelacionId = int.Parse(comboBoxTipoRelacionInstitucion.SelectedItem.ToString().Split(':')[0]);

                        command.Parameters.AddWithValue("@personaje_id", personajeId);
                        command.Parameters.AddWithValue("@institucion_id", institucionId);
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

                    MessageBox.Show("Relación con institución agregada exitosamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

    }
}
