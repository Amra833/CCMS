using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GUI_CW_GROUP
{
    public class DbConnection
    {
        public MySqlConnection CreateConnection
        {
            get
            {
                string connection_string = "server = 127.0.0.1 ; uid = root ; pwd = A2003@jkr# ; database = cricket_club";

                MySqlConnection con = new MySqlConnection(connection_string);
                return con;
            }
        }
    }
}