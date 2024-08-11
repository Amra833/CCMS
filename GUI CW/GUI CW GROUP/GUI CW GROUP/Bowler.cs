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
    public partial class FrmBowler : Form
    {
        public FrmBowler()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //validating date to make sure it is not null
                if (TxtDate.Text == "" || TxtDate.Text == null)
                {
                    MessageBox.Show("Date cannot be empty");
                    TxtDate.Focus();
                    return;
                }

                //validating name to make sure it is not null
                if (TxtName.Text == "" || TxtName.Text == null)
                {
                    MessageBox.Show("Name cannot be empty");
                    TxtName.Focus();
                    return;
                }

                //validating jersey to make sure it is not null
                if (TxtJersey.Text == "" || TxtJersey.Text == null)
                {
                    MessageBox.Show("Jersey Number cannot be empty");
                    TxtJersey.Focus();
                    return;
                }

                //validating match type to check whether an option is selected
                if (CmbType.SelectedIndex == -1)
                {
                    MessageBox.Show("Match type should be selected");
                    CmbType.Focus();
                    return;
                }

                //validating wickets to make sure it is not null
                if (TxtWickets.Text == "" || TxtWickets.Text == null)
                {
                    MessageBox.Show("Wickets cannot be empty");
                    TxtWickets.Focus();
                    return;
                }

                //validating opposite team to make sure it is not null
                if (TxtOpposite.Text == "" || TxtOpposite.Text == null)
                {
                    MessageBox.Show("Opposite cannot be empty");
                    TxtOpposite.Focus();
                    return;
                }


                //validating bowler id to make sure it is not null
                if (TxtId.Text == "" || TxtId.Text == null)
                {
                    MessageBox.Show("Bowler Id cannot be empty");
                    TxtId.Focus();
                    return;
                }

                //read inputs
                DateTime Date = Convert.ToDateTime(TxtDate.Text);
                string Name = TxtName.Text;
                string Jersey_Number = TxtJersey.Text;
                string Type = CmbType.SelectedItem.ToString();
                int Personal_Wickets = Convert.ToInt32(TxtWickets.Text);
                string Opposite = TxtOpposite.Text;
                string Bowler_Id = TxtId.Text;

                //use connection
                MySqlConnection con = new DbConnection().CreateConnection;

                //insert command
                string query = "insert into Bowler (Match_date, Player_name,Jersey_Number, Personal_Wickets, Opposite_team, Bowler_Id) values (@Date, @Name,@Jersey_Number, @Personal_Wickets, @Opposite, Bowler_Id)";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Date", Date);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Jersey_Number", Jersey_Number);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@Personal_Wickets", Personal_Wickets);
                cmd.Parameters.AddWithValue("@Opposite", Opposite);
                cmd.Parameters.AddWithValue("@Bowler_Id", Bowler_Id);

                //Execute command
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Saved successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }
    }
}
