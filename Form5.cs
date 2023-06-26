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
    public partial class Form5 : Form
    {
        Person pers;
        string path;

        public Form5(Person person)
        {
            InitializeComponent();
            pers = person;
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                Bitmap pic = new Bitmap(path);
                pictureBox1.Image = pic;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String sql = "SELECT * FROM rest_manager.dbo.food where name='" +textBox1.Text + "' and meal='" + textBox2.Text + "'";
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-ECP70S8";
            builder.UserID = "Sa";
            builder.Password = "1080566783";
            builder.InitialCatalog = "rest_manager";
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            food fod = new food();
            fod.name = textBox1.Text;
            fod.meal = textBox2.Text;
            fod.kind = textBox3.Text;
            fod.price =Convert.ToInt32(textBox4.Text);
            fod.rest_name = pers.rest_name;
            fod.image_path = path;
            fod.time_prepare = Convert.ToInt32(textBox5.Text);



            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        sql = "insert into rest_manager.dbo.food values('" + fod.name + "','" + fod.meal + "','" + fod.kind + "','" + fod.price + "','" + fod.time_prepare + "','" + fod.rest_name + "','" + fod.image_path + "')";
                        
                        connection.Close();
                        connection.Open();
                        SqlCommand command2 = new SqlCommand(sql, connection);
                        command2.ExecuteReader();
                        Console.Write("food created");

                        MessageBox.Show("غذا مورد نظر ثبت شد","ثبت غذا",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {
                        reader.Read();
                        MessageBox.Show("this food already exist","Eror",MessageBoxButtons.OK,MessageBoxIcon.Error);

                    }

                }
            }
            connection.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
