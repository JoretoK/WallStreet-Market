using System;
using System.Drawing;
using System.Windows.Forms;

namespace WallStreetStockMarket
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
            AvatarImage.Image = Image.FromFile("D:\\ГПИ C#\\Курсов проект\\WallStreetStockMarket\\images\\avatar.png");
        }

        private void btnChangeAv_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.png; *.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                AvatarImage.Image = new Bitmap(open.FileName);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Game newForm = new Game();
            newForm.Show();
            this.Hide();
            newForm.Change2(AvatarImage.Image);        
        }

        public void Change(Image newImage)
        { 
            AvatarImage.Image = newImage;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Profile Avatar changed successfuly", "Avatar Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
