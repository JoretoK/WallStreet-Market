using System;
using System.Windows.Forms;
using System.IO;

namespace WallStreetStockMarket
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();      
        }
      
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Field can't be empty!", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
            }
            else
            {

                string username = txtUsername.Text;
                string password = txtPassword.Text;

                // Create a StreamReader object to read the usernames and passwords from the file
                StreamReader reader = new StreamReader(File.OpenRead("Users.txt"));

                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts[0] == username && parts[1] == password)
                    {
                        MessageBox.Show("Log in successful","Login successful",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        reader.Close();
                        new Game().Show();
                        this.Hide();
                        return;
                    }
                }              
                reader.Close();
                MessageBox.Show("Invalid username or password.", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }          
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void CheckbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }       
    }
}
