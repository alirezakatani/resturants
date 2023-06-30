using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        Person pers;
        public Form7(Person per)
        {
            InitializeComponent();
            pers = per;
        }

        private void Form7_Load(object sender, EventArgs e)
        {

            sqlcon newsql = new sqlcon();
            newsql.sql = "select * from rest_manager.dbo.list";
            newsql.setdata_adaptor();

            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = newsql.ds.Tables[0];


        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            if(textBox1.Text=="" || textBox2.Text=="")
            {
                MessageBox.Show("لطفا تمامی فیلد ها را کامل کنید");
                return;

            }
            list nlist = new list();
            nlist.list_date = Convert.ToDateTime(dateTimePicker1.Value);
            nlist.list_id =Convert.ToInt32(textBox3.Text);
            nlist.list_name = textBox1.Text;
            nlist.list_meal = textBox2.Text;

            Form8 fr8 = new Form8(pers,nlist);
            fr8.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            sqlcon newsql = new sqlcon();
            newsql.sql = "select * from list where list_name='" + textBox1.Text+"'";
            newsql.setcon();
            newsql.reader.Read();
            textBox1.Text = newsql.reader.GetString(1);
            textBox2.Text= newsql.reader.GetString(2);
            textBox3.Text=Convert.ToString(newsql.reader.GetInt32(0));
            dateTimePicker1.Value=  newsql.reader.GetDateTime(3);

        }
    }
}
