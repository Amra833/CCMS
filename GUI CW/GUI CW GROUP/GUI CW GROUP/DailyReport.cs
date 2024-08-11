using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_CW_GROUP
{
    public partial class FrmSquadReport : Form
    {
        public FrmSquadReport()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            
            //validating squad to check whether an option is selected
            if (CmbSquad.SelectedIndex == -1)
            {
                MessageBox.Show("Squad should be selected");
                return;
            }

            //Read inputs
            string keyword = CmbSquad.SelectedItem.ToString();

            //Use connection
            MySqlConnection con = new DbConnection().CreateConnection;
            string query;


            if (CmbSquad.SelectedItem.ToString() == "Batsman")
            {
                query = "select Player_Name,Jersey_Number,Personal_Score from Batsman";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Squad", keyword);

                //Executing command
                con.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DgvList.DataSource = dt;
            }
            else if (CmbSquad.SelectedItem.ToString() == "Bowler")
            {
                query = "select Player_Name,Jersey_Number,Personal_Wickets from Bowler";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Squad", keyword);

                //Executing command
                con.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DgvList.DataSource = dt;
            }
            

        }
    }
}
