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
        }

        private void LoadComboBoxData()
        {
            string connectionString = @"Data Source=E:\DB Browser for SQLite\Historia_Medieval.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT nombre, apellido FROM personajes"; // Reemplaza 'TablaEjemplo' con tu tabla real
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
            string connectionString = @"Data Source=E:\DB Browser for SQLite\Historia_Medieval.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO personajes (nombre, apellido, mote, fecha_nacimiento, fecha_muerte, importancia, biografia) VALUES (@Nombre, @Apellido, @Mote, @FechaNacimiento, @FechaMuerte, @Importancia, @Biografia)";
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
                    }
                    MessageBox.Show("Personaje agregado exitosamente.");
                    comboBox1.Items.Clear();
                    LoadComboBoxData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
