using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CuartoEM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadComboBoxData();
            LoadPersonajesComboBox();
            LoadTipoRelacionComboBox();
        }

        private void LoadComboBoxData()
        {
            string connectionString = @"Data Source=E:\DB Browser for SQLite\Historia_Medieval.db;Version=3;";
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

        private void LoadPersonajesComboBox()
        {
            string connectionString = @"Data Source=E:\DB Browser for SQLite\Historia_Medieval.db;Version=3;";
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
            string connectionString = @"Data Source=E:\DB Browser for SQLite\Historia_Medieval.db;Version=3;";
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

        private bool ValidarFechas()
        {
            DateTime fechaInicio, fechaFin;
            if (!DateTime.TryParse(textBoxFechaInicio.Text, out fechaInicio))
            {
                MessageBox.Show("Fecha de inicio no válida.");
                return false;
            }
            if (!DateTime.TryParse(textBoxFechaFin.Text, out fechaFin))
            {
                MessageBox.Show("Fecha de fin no válida.");
                return false;
            }
            if (fechaInicio.Year < 500 || fechaFin.Year < 500)
            {
                MessageBox.Show("Las fechas deben ser a partir del siglo VI.");
                return false;
            }
            return true;
        }

        private void addRelationButton_Click(object sender, EventArgs e)
        {
            if (!ValidarFechas())
            {
                return;
            }

            string connectionString = @"Data Source=E:\DB Browser for SQLite\Historia_Medieval.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO parentescos (personaje_id1, personaje_id2, tipo_relacion_id, fecha_inicio, fecha_fin) VALUES (@personaje_id1, @personaje_id2, @tipo_relacion_id, @fecha_inicio, @fecha_fin)";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@personaje_id1", comboBoxPersonaje1.SelectedItem.ToString().Split(':')[0]);
                        command.Parameters.AddWithValue("@personaje_id2", comboBoxPersonaje2.SelectedItem.ToString().Split(':')[0]);
                        command.Parameters.AddWithValue("@tipo_relacion_id", comboBoxTipoRelacion.SelectedItem.ToString().Split(':')[0]);
                        command.Parameters.AddWithValue("@fecha_inicio", DateTime.Parse(textBoxFechaInicio.Text));
                        command.Parameters.AddWithValue("@fecha_fin", DateTime.Parse(textBoxFechaFin.Text));

                        command.ExecuteNonQuery();
                        MessageBox.Show("Relación agregada exitosamente.");
                    }
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
            string connectionString = @"Data Source=E:\DB Browser for SQLite\Historia_Medieval.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT nombre, apellido, mote, fecha_nacimiento, fecha_muerte, importancia, biografia FROM personajes WHERE nombre = @Nombre AND apellido = @Apellido"; // Reemplaza 'TablaEjemplo' con tu tabla real
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
            // Implementa la lógica que deseas que ocurra cuando se haga clic en addButton
        }

        private void comboBoxTipoRelacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoRelacion.SelectedItem.ToString().Contains("esposos"))
            {
                dateTimePickerInicio.Visible = true;
                dateTimePickerFin.Visible = true;
                textBoxFechaInicio.Visible = true;
                textBoxFechaFin.Visible = true;
            }
            else
            {
                dateTimePickerInicio.Visible = false;
                dateTimePickerFin.Visible = false;
                textBoxFechaInicio.Visible = false;
                textBoxFechaFin.Visible = false;
            }
        }
    }
}
