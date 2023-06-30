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
    public partial class Form8 : Form
    {
        int list_id;
        Person pers;
        list lis;
        string path;
        food fod;
        public Form8(Person per,list nlist)
        {
            InitializeComponent();
            pers = per;
            list_id = nlist.list_id;
            lis = nlist;

            sqlcon newsql = new sqlcon();
            newsql.sql = "select food.name as food_name,food.meal as food_meal,food.kind as food_kind,food.price as food_price,food.time_prepare as food_time_prepare,list.* from food left join list_match on (food_name=food.name and food_meal=food.meal and food.rest_name=list_match.rest_name) left join list on(list_match.list_name=list.list_name and list_match.list_meal=list.list_meal)   where list.list_id=" + list_id+" and food.rest_name='"+pers.rest_name+"'";

            newsql.setdata_adaptor();

            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = newsql.ds.Tables[0];
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form9 fr9 = new Form9(pers);
            fr9.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text=="" || textBox4.Text=="" || textBox5.Text=="" || path==null )
            {
                MessageBox.Show("لطفا تمامی فیلد ها را کامل کنید");
                return;

            }
            sqlcon newsql = new sqlcon();
            newsql.sql = "insert into list_match values('" + textBox1.Text + "','" + textBox2.Text + "','" +lis.list_name+"','"+lis.list_meal+"','"+pers.rest_name+"')" ;
            newsql.setcon();
            dataGridView1.Update();


        }

        private void button3_Click(object sender, EventArgs e)
        {

            sqlcon con = new sqlcon();
            con.sql = "SELECT * FROM rest_manager.dbo.food where name='" + textBox1.Text + "' and meal='" + textBox2.Text + "' and rest_name='" + pers.rest_name + "'"; ;
            con.setcon();
            if (con.reader.HasRows)
            {
                con.reader.Read();
                textBox3.Text = con.reader.GetString(2);
                textBox4.Text = Convert.ToString(con.reader.GetInt32(3));
                textBox5.Text = Convert.ToString(con.reader.GetInt32(4));

                path = con.reader.GetString(6);
                Bitmap pic = new Bitmap(path);
                pictureBox1.Image = pic;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                fod = new food();
                fod.name = textBox1.Text;
                fod.meal = textBox2.Text;
                fod.kind = textBox3.Text;
                fod.price = Convert.ToInt32(textBox4.Text);
                fod.rest_name = pers.rest_name;
                fod.image_path = path;
                fod.time_prepare = Convert.ToInt32(textBox5.Text);
                con.delcon();
            }
            else
            {

                MessageBox.Show("غذای مورد نظر وجود ندارد", "عدم وجود غذا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
