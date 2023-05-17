using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WallStreetStockMarket
{
    public partial class Highscores : Form
    {
        public Highscores()
        {
            InitializeComponent();
        }

        private void Highscores_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("D:\\ГПИ C#\\Курсов проект\\WallStreetStockMarket\\images\\grow.png");

            Label[] highScoreLabels = new Label[10];
            for (int i = 0; i < highScoreLabels.Length; i++)
            {
                highScoreLabels[i] = new Label();
                highScoreLabels[i].Text = "";
                highScoreLabels[i].Location = new Point(5, 70 + i * 35);
                //highScoreLabels[i].Font = new Font("MS UI Gothic", 15, FontStyle.Regular);
                highScoreLabels[i].Font = new Font("MS UI Gothic", 15, FontStyle.Regular);
                highScoreLabels[i].ForeColor = Color.DodgerBlue;
                highScoreLabels[i].Width = 700;
                this.Controls.Add(highScoreLabels[i]);
            }

            List<int> highScores = new List<int>(); // initialize empty list
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                int score = random.Next(250000, 1000000000); // generate random score 
                highScores.Add(score);
            }

            string[] firstNames = { "John", "Jane", "Alice", "Bob", "Eve", "Charlie", "David", "Olivia", "Sophia", "Michael" };
            string[] lastNames = { "Smith", "Johnson", "Brown", "Davis", "Garcia", "Miller", "Wilson", "Moore", "Taylor", "Anderson" };
            List<string> playerNames = new List<string>();

            highScores.Sort((x, y) => y.CompareTo(x)); // sort scores in descending order

            for (int i = 0; i < highScoreLabels.Length; i++)
            {
                if (i < highScores.Count)
                {
                    int firstNameIndex = random.Next(0, firstNames.Length);
                    int lastNameIndex = random.Next(0, lastNames.Length);
                    string playerName = $"{firstNames[firstNameIndex]} {lastNames[lastNameIndex]}";
                    highScoreLabels[i].Text = $"{i + 1}. {playerName} ---> {highScores[i]:N0}" + " $";
                }
                else
                {
                    highScoreLabels[i].Text = "";
                }
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Game newForm = new Game();
            newForm.Show();
            this.Hide();
        }
    }
}
