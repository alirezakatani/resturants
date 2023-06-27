using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public class sqlcon
    {

        public String sql { get; set; }
        public SqlConnection connection { get; set; }
        public SqlConnectionStringBuilder builder { get; set; }
        public SqlCommand command { get; set; }
        public SqlDataReader reader { get; set; }



        public void setcon()
        {
            builder= new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-ECP70S8";
            builder.UserID = "Sa";
            builder.Password = "1080566783";
            builder.InitialCatalog = "rest_manager";
            connection = new SqlConnection(builder.ConnectionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            reader = command.ExecuteReader();
        }

        public void delcon()
        {
            connection.Close();
        }
            
           


    }
}
