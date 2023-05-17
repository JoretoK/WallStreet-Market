using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WallStreetStockMarket
{
    public partial class Game : Form
    {

        int total;
        int capacity;
        int number;
        bool isNumber = false;

        int fbPrice = 37000;
        int aplPrice = 43000;
        int spotPrice = 21000;
        int msftPrice = 50000;
        int googlePrice = 56000;
        int btcPrice = 12000;
        int psPrice = 24000;

        private void ChangeLabels(ComboBox currentComboBox, ComboBox comboBox, Label buy, Label sell)
        {
            foreach (Control control in this.Controls)
            {
                if (control is ComboBox comboBox2 && comboBox2 != currentComboBox)
                {
                    comboBox2.Text = "";
                }
            }

            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    // Check if the textbox name is not the one to exclude
                    if (textBox.Name != "textBoxToExclude")
                    {
                        // Clear the textbox
                        textBox.Text = "";
                    }
                }
            }

            if (comboBox.SelectedIndex == 0)
            {
                buy.BackColor = Color.LightBlue;
                sell.BackColor = Color.White;
            }
            else
            {
                sell.BackColor = Color.LightBlue;
                buy.BackColor = Color.White;
            }
        }

        private void BuyStocks(ComboBox combo, TextBox textBox, int price)
        {
            total = int.Parse(label_Total.Text);
            capacity = int.Parse(label_Capacity.Text);
            if (combo.SelectedText == "Buy" && textBox.Text == "")
            {
                MessageBox.Show("Fields can't be empty!", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                isNumber = int.TryParse(textBox.Text, out number);

                price = price * number;

                if (price > total)
                {
                    MessageBox.Show("Can't afford this", "Storage capacity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    total = total - price;
                    capacity -= number;
                    label_Total.Text = total.ToString();
                    label_Capacity.Text = capacity.ToString();
                }
            }
        }

        private void SellStocks(ComboBox combo, TextBox textBox, int price)
        {
            total = int.Parse(label_Total.Text);
            capacity = int.Parse(label_Capacity.Text);
            if (combo.SelectedText == "Sell" && textBox.Text == "")
            {
                MessageBox.Show("Fields can't be empty!", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                isNumber = int.TryParse(textBox.Text, out number);

                price = price * number;
                total = total + price;
                capacity += number;
                label_Total.Text = total.ToString();
                label_Capacity.Text = capacity.ToString();
            }
        }

        public Game()
        {

            InitializeComponent();

            IconImage.Image = Image.FromFile("D:\\ГПИ C#\\Курсов проект\\WallStreetStockMarket\\images\\icon.png");
            AvatarImage.Image = Image.FromFile("D:\\ГПИ C#\\Курсов проект\\WallStreetStockMarket\\images\\avatar.png");
            stock_Image.Image = Image.FromFile("D:\\ГПИ C#\\Курсов проект\\WallStreetStockMarket\\images\\stock.png");

            fb_Image.Image = Image.FromFile("D:\\ГПИ C#\\Курсов проект\\WallStreetStockMarket\\images\\facebook.png");
            apple_Image.Image = Image.FromFile("D:\\ГПИ C#\\Курсов проект\\WallStreetStockMarket\\images\\apple.png");
            spot_Image.Image = Image.FromFile("D:\\ГПИ C#\\Курсов проект\\WallStreetStockMarket\\images\\spot.png");
            Mic_Image.Image = Image.FromFile("D:\\ГПИ C#\\Курсов проект\\WallStreetStockMarket\\images\\mic.png");
            google_Image.Image = Image.FromFile("D:\\ГПИ C#\\Курсов проект\\WallStreetStockMarket\\images\\google.png");
            bit_Image.Image = Image.FromFile("D:\\ГПИ C#\\Курсов проект\\WallStreetStockMarket\\images\\bit.png");
            ps_Image.Image = Image.FromFile("D:\\ГПИ C#\\Курсов проект\\WallStreetStockMarket\\images\\ps.png");

            btn_Highscores.FlatAppearance.MouseOverBackColor = Color.LightBlue;
            btn_Profile.FlatAppearance.MouseOverBackColor = Color.LightBlue;
            btn_SignOut.FlatAppearance.MouseOverBackColor = Color.LightBlue;
            saveProgress.FlatAppearance.MouseOverBackColor = Color.LightBlue;
            btn_Exit.FlatAppearance.MouseOverBackColor = Color.LightBlue;

        }
        private void AvatarImage_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profile form = new Profile();
            form.Show();
            form.Change(AvatarImage.Image);
            this.Hide();

        }

        public void Change2(Image newImage)
        {
            AvatarImage.Image = newImage;
        }

        private void btn_SignOut_Click(object sender, EventArgs e)
        {
            new formLogin().Show();
            this.Hide();
        }

        private void fb_Action_SelectedIndexChanged(object sender, EventArgs e)
        {
            stock_Image.Image = Image.FromFile("D:\\ГПИ C#\\Курсов проект\\WallStreetStockMarket\\images\\facebook.png");

            ChangeLabels(fb_Action, fb_Action, lb_Buy, lb_Sell);
        }

        private void apple_Action_SelectedIndexChanged(object sender, EventArgs e)
        {
            stock_Image.Image = Image.FromFile("D:\\ГПИ C#\\Курсов проект\\WallStreetStockMarket\\images\\apple.png");

            ChangeLabels(apple_Action, apple_Action, lb_Buy, lb_Sell);
        }

        private void spot_Action_SelectedIndexChanged(object sender, EventArgs e)
        {

            stock_Image.Image = Image.FromFile("D:\\ГПИ C#\\Курсов проект\\WallStreetStockMarket\\images\\spot.png");

            ChangeLabels(spot_Action, spot_Action, lb_Buy, lb_Sell);
        }

        private void mic_Action_SelectedIndexChanged(object sender, EventArgs e)
        {
            stock_Image.Image = Image.FromFile("D:\\ГПИ C#\\Курсов проект\\WallStreetStockMarket\\images\\mic.png");

            ChangeLabels(mic_Action, mic_Action, lb_Buy, lb_Sell);
        }

        private void google_Action_SelectedIndexChanged(object sender, EventArgs e)
        {
            stock_Image.Image = Image.FromFile("D:\\ГПИ C#\\Курсов проект\\WallStreetStockMarket\\images\\google.png");

            ChangeLabels(google_Action, google_Action, lb_Buy, lb_Sell);
        }

        private void bit_Action_SelectedIndexChanged(object sender, EventArgs e)
        {
            stock_Image.Image = Image.FromFile("D:\\ГПИ C#\\Курсов проект\\WallStreetStockMarket\\images\\bit.png");

            ChangeLabels(bit_Action, bit_Action, lb_Buy, lb_Sell);
        }

        private void ps_Action_SelectedIndexChanged(object sender, EventArgs e)
        {
            stock_Image.Image = Image.FromFile("D:\\ГПИ C#\\Курсов проект\\WallStreetStockMarket\\images\\ps.png");

            ChangeLabels(ps_Action, ps_Action, lb_Buy, lb_Sell);
        }

        private void lb_Buy_Click(object sender, EventArgs e)
        {

            BuyStocks(fb_Action, tb_Fc, fbPrice);

            BuyStocks(apple_Action, tb_Apple, aplPrice);

            BuyStocks(spot_Action, tb_Spot, spotPrice);

            BuyStocks(mic_Action, tb_Mic, msftPrice);

            BuyStocks(google_Action, tb_Google, googlePrice);

            BuyStocks(bit_Action, tb_Bit, btcPrice);

            BuyStocks(ps_Action, tb_Ps, psPrice);
        }

        private void lb_Sell_Click(object sender, EventArgs e)
        {
            SellStocks(fb_Action, tb_Fc, fbPrice);

            SellStocks(apple_Action, tb_Apple, aplPrice);

            SellStocks(spot_Action, tb_Spot, spotPrice);

            SellStocks(mic_Action, tb_Mic, msftPrice);

            SellStocks(google_Action, tb_Google, googlePrice);

            SellStocks(bit_Action, tb_Bit, btcPrice);

            SellStocks(ps_Action, tb_Ps, psPrice);
        }

        private void saveProgress_Click(object sender, EventArgs e)
        {
            StreamWriter writer1 = new StreamWriter(File.OpenWrite("SaveGame.txt"));

            writer1.WriteLine(label_Total.Text + "," + label_Capacity.Text);
            writer1.Close();

            MessageBox.Show("Game Saved!", "Progress", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("SaveGame.txt");

            string line;
            string t = "";
            string c = "";
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                t += parts[0];
                c += parts[1];
                reader.Close();
                break;
            }
            label_Total.Text = t;
            label_Capacity.Text = c;
        }

        private void btn_Highscores_Click(object sender, EventArgs e)
        {
            new Highscores().Show();
            this.Hide();
        }
    }
}
