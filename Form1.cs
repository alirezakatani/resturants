using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

       
 
            //    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //    builder.DataSource = "DESKTOP-ECP70S8";
            //    builder.UserID = "Sa";
            //    builder.Password = "1080566783";
            //    builder.InitialCatalog = "rest_manager";
          

            //    SqlConnection connection = new SqlConnection(builder.ConnectionString);
            //connection.Close();
 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sql = "SELECT * FROM rest_manager.dbo.manager where username='"+text_user.Text+"' and password='"+text_pass.Text+"'";
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-ECP70S8";
            builder.UserID = "Sa";
            builder.Password = "1080566783";
            builder.InitialCatalog = "rest_manager";


            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.Write("user name or password not valid");
                        MessageBox.Show("user name or password not valid");
                        return;
                    }
                    else
                    {
                        reader.Read();
                        MessageBox.Show("welcome "+reader.GetString(1)+ " "+reader.GetString(2));
                    }

                }
            }
            connection.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 newmanager = new Form2();
            newmanager.ShowDialog();
          




        }
    }
}
