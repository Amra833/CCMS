using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GUI_CW_GROUP
{
    public partial class FrmMemberDetails : Form
    {
        public FrmMemberDetails()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Read inputs
            string name = TxtName.Text;
            string nic = TxtNIC.Text;
            DateTime dob;
            if (!DateTime.TryParse(TxtDOB.Text, out dob))
            {
                MessageBox.Show("Invalid date format for DOB");
                TxtDOB.Focus();
                return;
            }
            string address = TxtAddress.Text;
            string contactNumber = TxtNumber.Text;
            string email = TxtEmail.Text;
            string jerseyNumber = TxtJersey.Text;
            string category = CmbCategory.SelectedItem?.ToString();

            // Validating fields
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name cannot be empty");
                TxtName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(nic))
            {
                MessageBox.Show("NIC cannot be empty");
                TxtNIC.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Address cannot be empty");
                TxtAddress.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(contactNumber))
            {
                MessageBox.Show("Contact Number cannot be empty");
                TxtNumber.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email cannot be empty");
                TxtEmail.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(jerseyNumber))
            {
                MessageBox.Show("Jersey Number cannot be empty");
                TxtJersey.Focus();
                return;
            }
            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Category should be selected");
                CmbCategory.Focus();
                return;
            }

            // Use connection
            using (MySqlConnection con = new DbConnection().CreateConnection)
            {
                // Insert command
                string query = "INSERT INTO member_details (Player_Name, NIC, DOB, Address, Contact_Number, Email, Jersey_Number, Category) VALUES (@Name, @NIC, @DOB, @Address, @Contact_Number, @Email, @Jersey_Number, @Category)";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@NIC", nic);
                    cmd.Parameters.AddWithValue("@DOB", dob);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Contact_Number", contactNumber);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Jersey_Number", jerseyNumber);
                    cmd.Parameters.AddWithValue("@Category", category);

                    // Execute command
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Saved successfully");
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            string jerseyNumber = TxtJersey.Text;

            // Validate jersey number
            if (string.IsNullOrWhiteSpace(jerseyNumber))
            {
                MessageBox.Show("Jersey Number cannot be empty");
                TxtJersey.Focus();
                return;
            }

            // Use connection
            using (MySqlConnection con = new DbConnection().CreateConnection)
            {
                // Delete command
                string query = "DELETE FROM member_details WHERE Jersey_Number = @Jersey_Number";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Jersey_Number", jerseyNumber);

                    // Execute command
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Cleared successfully");
        }
    }
}
