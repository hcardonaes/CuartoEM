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
                    string query = "SELECT nombre FROM personajes"; // Reemplaza 'TablaEjemplo' con tu tabla real
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBox1.Items.Add(reader["nombre"].ToString());
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
            string selectedName = comboBox1.SelectedItem.ToString();
            string connectionString = @"Data Source=E:\DB Browser for SQLite\Historia_Medieval.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT nombre, apellido, mote, fecha_nacimiento, fecha_muerte, importancia, biografia FROM personajes WHERE Nombre = @Nombre"; // Reemplaza 'TablaEjemplo' con tu tabla real
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", selectedName);
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
                                textBox7.Text = reader["biografia"].ToString();
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
    }
}
