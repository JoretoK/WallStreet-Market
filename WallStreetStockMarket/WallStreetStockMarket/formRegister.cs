using System;
using System.Windows.Forms;
using System.IO;

namespace WallStreetStockMarket
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string comPas = txtComPassword.Text;

            // Create a StreamWriter object to write the username and password to a file
           // string fileName = @"D:\Users.txt";

            if (password != comPas)
            {
                MessageBox.Show("Passwords don't match.","Registration failed",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtUsername.Focus();
            }
            else if (txtUsername.Text == "" || txtPassword.Text == "" || txtComPassword.Text == "")
            {
                MessageBox.Show("Field can't be empty!", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
            }
            else if (password == comPas)
            {
                StreamWriter writer = new StreamWriter(File.OpenWrite("Users.txt"));
                writer.WriteLine(username + "," + password);
                writer.Close();
                MessageBox.Show("User registration is successful!", "Register successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            StreamWriter writer1 = new StreamWriter(File.OpenWrite("SaveGame.txt"));

            writer1.WriteLine(250000 + "," + 10);
            writer1.Close();
        }

        private void CheckbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtComPassword.PasswordChar = '•';
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtComPassword.Text = "";
            txtUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new formLogin().Show();
            this.Hide();
        }
    }
}
