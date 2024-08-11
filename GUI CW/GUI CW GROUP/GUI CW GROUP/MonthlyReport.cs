using MySql.Data.MySqlClient;
using System;
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
    public partial class FrmMatchReport : Form
    {
        public FrmMatchReport()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //validating match type to check whether an option is selected
            if (CmbType.SelectedIndex == -1)
            {
                MessageBox.Show("Match Type should be selected");
                return;
            }

            //Read inputs
            string keyword = CmbType.SelectedItem.ToString();

            //Use connection
            MySqlConnection con = new DbConnection().CreateConnection;

            //insert command


            //insert query
            string query = "select Opposite_team,Match_status,Score as Best_score from match_details";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Connection = con;
            //Executing command
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DgvList.DataSource = dt;
        }
    }
}
