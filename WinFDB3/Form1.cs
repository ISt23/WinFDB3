using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFDB3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost,3306;Database=lb1;Uid=root;Pwd=xxxxxxxxxx;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                // Виведення даних з таблиці "Замовлення"
                string ordersQuery = "SELECT * FROM orders";
                MySqlCommand ordersCommand = new MySqlCommand(ordersQuery, connection);

                MySqlDataAdapter ordersDataAdapter = new MySqlDataAdapter(ordersCommand);
                DataTable ordersDataTable = new DataTable();

                ordersDataAdapter.Fill(ordersDataTable);

                dataGridView1.DataSource = ordersDataTable;

                // Виведення даних з таблиці "Медикаменти"
                string medicinesQuery = "SELECT * FROM pharmacies";
                MySqlCommand medicinesCommand = new MySqlCommand(medicinesQuery, connection);

                MySqlDataAdapter medicinesDataAdapter = new MySqlDataAdapter(medicinesCommand);
                DataTable medicinesDataTable = new DataTable();

                medicinesDataAdapter.Fill(medicinesDataTable);

                dataGridView2.DataSource = medicinesDataTable;

                // Виведення даних з таблиці "Аптеки"
                string pharmaciesQuery = "SELECT * FROM products";
                MySqlCommand pharmaciesCommand = new MySqlCommand(pharmaciesQuery, connection);

                MySqlDataAdapter pharmaciesDataAdapter = new MySqlDataAdapter(pharmaciesCommand);
                DataTable pharmaciesDataTable = new DataTable();

                pharmaciesDataAdapter.Fill(pharmaciesDataTable);

                dataGridView3.DataSource = pharmaciesDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при з'єднанні з базою даних: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
