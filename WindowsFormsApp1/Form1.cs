using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UserCon();
            Table1();
            Table2();
            Table3();
        }
        public MySqlConnection connecting;
        public MySqlCommand command;
        public string mylogin = "server=localhost;uid=---;pwd=---;database=---;";
        
        public void UserCon()
        {
            connecting = new MySqlConnection(mylogin);
            connecting.Open();
            var test_connection = connecting.State.ToString();
            if (connecting.State == ConnectionState.Open && test_connection == "Open")
            {
                MessageBox.Show("подключено успешно");
            }
            else
            {
                MessageBox.Show("не удалось подключиться");
            }
        }
        private void Table1()
        {
            string get_table_location = "SELECT * FROM location ORDER BY f_id;";
            MySqlCommand command = new MySqlCommand(get_table_location, connecting);
            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[3]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
            }
            reader.Close();
            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);
            }
        }
        private void Table2()
        {
            string get_table_device_type = "SELECT * FROM device_type ORDER BY f_id;";
            MySqlCommand command = new MySqlCommand(get_table_device_type, connecting);
            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[2]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
            }
            reader.Close();
            foreach (string[] s in data)
            {
                dataGridView2.Rows.Add(s);
            }
        }
        private void Table3()
        {
            string get_table_device = "SELECT * FROM device ORDER BY f_id;";
            MySqlCommand command = new MySqlCommand(get_table_device, connecting);
            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();


            while (reader.Read())
            {
                data.Add(new string[8]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
            }
            reader.Close();
            foreach (string[] s in data)
            {
                dataGridView3.Rows.Add(s);
            }
        }//метод заполнения 3 таблицы
        private void button24_Click(object sender, EventArgs e)
        {

            var value1 = textBox22.Text;
            var value2 = textBox23.Text;
            string AddCommand1 = string.Format("INSERT INTO `_test`.`location` (`f_mailing_address`, `f_object_name`) VALUES ('{0}', '{1}');", value1, value2);
            MySqlCommand command1 = new MySqlCommand(AddCommand1, connecting);
            command1.ExecuteScalarAsync();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            var value1 = textBox14.Text;
            string AddCommand2 = string.Format("INSERT INTO `_test`.`device_type` (`f_name`) VALUES ('{0}');", value1);
            MySqlCommand command2 = new MySqlCommand(AddCommand2, connecting);
            command2.ExecuteScalarAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var value1 = textBox3.Text;
            var value2 = textBox2.Text;
            var value3 = textBox6.Text;
            var value4 = textBox4.Text;
            var value5 = textBox5.Text;
            var value6 = textBox12.Text;
            var value7 = textBox10.Text;
            string AddCommand3 = string.Format("INSERT INTO `_test`.`device` (`f_installation_date`, `f_manufacturer`, `f_model`, `f_serial_number`, `f_type`, `f_location`, `f_ip_address`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');", value1, value2, value3, value4, value5, value6, value7);
            MySqlCommand command3 = new MySqlCommand(AddCommand3, connecting);
            command3.ExecuteScalarAsync();
        }
    }
}