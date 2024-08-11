using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI_CW_GROUP
{
    public partial class FrmMatchDetails : Form
    {
        public FrmMatchDetails()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //validating date to make sure to make sure it is not null
            if (TxtDate.Text == "" || TxtDate.Text == null)
            {
                MessageBox.Show("Date cannot be empty");
                TxtDate.Focus();
                return;
            }

            //validating match type to check whether an option is selected
            if (CmbType.SelectedIndex == -1)
            {
                MessageBox.Show("Match type should be selected");
                CmbType.Focus();
                return;
            }

            //validating opposite team to make sure it is not null
            if (TxtOpposite.Text == "" || TxtOpposite.Text == null)
            {
                MessageBox.Show("Opposite team cannot be empty");
                TxtOpposite.Focus();
                return;
            }

            //validating players to make sure it is not null
            if (TxtPlayers.Text == "" || TxtPlayers.Text == null)
            {
                MessageBox.Show("Players cannot be empty");
                TxtPlayers.Focus();
                return;
            }

            //validating score to make sure it is not null
            if (TxtScore.Text == "" || TxtScore.Text == null)
            {
                MessageBox.Show("Score cannot be empty");
                TxtScore.Focus();
                return;
            }

            //validating wickets to make sure it is not null
            if (TxtWickets.Text == "" || TxtWickets.Text == null)
            {
                MessageBox.Show("Wickets cannot be empty");
                TxtWickets.Focus();
                return;
            }

            //validating radio buttons
            if (RdbWon.Checked == false && RdbLost.Checked == false)
            {
                MessageBox.Show("Match status should be selected");
                return;
            }

            //read inputs
            DateTime Date = Convert.ToDateTime(TxtDate.Text);
            string Match_Type = CmbType.SelectedItem.ToString();
            string Players = TxtPlayers.Text;
            int Score = Convert.ToInt32(TxtScore.Text);
            int Wickets = Convert.ToInt32(TxtWickets.Text);
            string Status = "";
            if (RdbWon.Checked)
            {
                Status = "Won";
            }
            if (RdbLost.Checked)
            {
                Status = "Lost";
            }

            //use connection
            MySqlConnection con = new DbConnection().CreateConnection;

            //insert command
            string query = "insert into match_details (Date, Match_Type, Players , Score , Wickets, Status) values (@Date, @Match_Type, @Players , @Score , @Wickets, @Status)";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Match_Type", Match_Type);
            cmd.Parameters.AddWithValue("@Players", Players);
            cmd.Parameters.AddWithValue("@Score", Score);
            cmd.Parameters.AddWithValue("@Wickets", Wickets);
            cmd.Parameters.AddWithValue("@Status", Status);

            //Execute command
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Saved successfully");
        }

        private void BtnSave_Click_1(object sender, EventArgs e)
        {
            //validating date to make sure to make sure it is not null
            if (TxtDate.Text == "" || TxtDate.Text == null)
            {
                MessageBox.Show("Date cannot be empty");
                TxtDate.Focus();
                return;
            }

            //validating match type to check whether an option is selected
            if (CmbType.SelectedIndex == -1)
            {
                MessageBox.Show("Match type should be selected");
                CmbType.Focus();
                return;
            }

            //validating opposite team to make sure it is not null
            if (TxtOpposite.Text == "" || TxtOpposite.Text == null)
            {
                MessageBox.Show("Opposite team cannot be empty");
                TxtOpposite.Focus();
                return;
            }

            //validating players to make sure it is not null
            if (TxtPlayers.Text == "" || TxtPlayers.Text == null)
            {
                MessageBox.Show("Players cannot be empty");
                TxtPlayers.Focus();
                return;
            }

            //validating score to make sure it is not null
            if (TxtScore.Text == "" || TxtScore.Text == null)
            {
                MessageBox.Show("Score cannot be empty");
                TxtScore.Focus();
                return;
            }

            //validating wickets to make sure it is not null
            if (TxtWickets.Text == "" || TxtWickets.Text == null)
            {
                MessageBox.Show("Wickets cannot be empty");
                TxtWickets.Focus();
                return;
            }

            //validating radio buttons
            if (RdbWon.Checked == false && RdbLost.Checked == false)
            {
                MessageBox.Show("Match status should be selected");
                return;
            }

            //read inputs
            DateTime Match_Date = Convert.ToDateTime(TxtDate.Text);
            string Match_Type = CmbType.SelectedItem.ToString();
            string Players = TxtPlayers.Text;
            int Score = Convert.ToInt32(TxtScore.Text);
            int Wickets = Convert.ToInt32(TxtWickets.Text);
            string Match_status = "";
            if (RdbWon.Checked)
            {
                Match_status = "Won";
            }
            if (RdbLost.Checked)
            {
                Match_status = "Lost";
            }

            //use connection
            MySqlConnection con = new DbConnection().CreateConnection;

            //insert command
            string query = "insert into match_details (Match_Date, Match_Type, Players , Score , Wickets, Match_status) values (@Match_Date, @Match_Type, @Players , @Score , @Wickets, @Match_status)";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Match_Date", Match_Date);
            cmd.Parameters.AddWithValue("@Match_Type", Match_Type);
            cmd.Parameters.AddWithValue("@Players", Players);
            cmd.Parameters.AddWithValue("@Score", Score);
            cmd.Parameters.AddWithValue("@Wickets", Wickets);
            cmd.Parameters.AddWithValue("@Match_status", Match_status);

            //Execute command
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Saved successfully");
        }
    }
}