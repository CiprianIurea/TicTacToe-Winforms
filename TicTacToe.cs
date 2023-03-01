
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace TicTacToe
{
    public partial class TicTacToe : Form
    {
        bool turn = true;
        int c = 0;
        bool mode;
        bool winner = false;
        Graphics g = null;
        int scorp1 = 0, scorp2 = 0;
        public TicTacToe()
        {
            InitializeComponent();
            label2.Text = StartPage.player1 + "-" + scorp1;
            label3.Text = scorp2 + "-" + StartPage.player2;
            mode = StartPage.versus;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartPage st = new StartPage();
            st.Show();
        }

        private void b_Click(object sender, EventArgs e)
        {
            bool value;
            Button b = (Button)sender;
            if (mode)
            {
                b.Text = "X";
                value = pickwinner(false);
                if (!value)
                {
                    string name = bestmove();
                    foreach (var d in this.Controls.OfType<Button>())
                    {
                        if (d.Name == name)
                        {
                            d.Text = "O";
                            d.Enabled = false;
                            break;
                        }
                    }
                    pickwinner(false);
                }
                b.Enabled = false;
                turn = !turn;
                c++;
            }
            else
            {
                if (turn)
                {
                    b.Text = "X";
                    pickwinner(false);
                }
                else
                {
                    b.Text = "O";
                    pickwinner(false);
                }
                turn = !turn;
                b.Enabled = false;
                c++;
            }
        }
        private bool checkwin(bool winner)
        {
            if (b1.Text == b2.Text && b1.Text == b3.Text && b1.Text != "")
                winner = true;
            if (b4.Text == b5.Text && b4.Text == b6.Text && b4.Text != "")
                winner = true;
            if (b7.Text == b8.Text && b7.Text == b9.Text && b7.Text != "")
                winner = true;
            if (b1.Text == b4.Text && b1.Text == b7.Text && b1.Text != "")
                winner = true;
            if (b2.Text == b5.Text && b2.Text == b8.Text && b2.Text != "")
                winner = true;
            if (b3.Text == b6.Text && b3.Text == b9.Text && b3.Text != "")
                winner = true;
            if (b1.Text == b5.Text && b1.Text == b9.Text && b1.Text != "")
                winner = true;
            if (b3.Text == b5.Text && b3.Text == b7.Text && b3.Text != "")
                winner = true;
            return winner;
        }
        private int evaluate()
        {
            if (b1.Text == b2.Text && b1.Text == b3.Text)
            {
                if (b1.Text == "X")
                    return 10;
                else if (b1.Text == "O")
                    return -10;
            }

            if (b4.Text == b5.Text && b4.Text == b6.Text)
            {
                if (b4.Text == "X")
                    return 10;
                else if (b4.Text == "O")
                    return -10;
            }
            if (b7.Text == b8.Text && b7.Text == b9.Text)
            {
                if (b7.Text == "X")
                    return 10;
                else if (b7.Text == "O")
                    return -10;
            }
            if (b1.Text == b4.Text && b1.Text == b7.Text)
            {
                if (b1.Text == "X")
                    return 10;
                else if (b1.Text == "O")
                    return -10;
            }
            if (b2.Text == b5.Text && b2.Text == b8.Text)
            {
                if (b2.Text == "X")
                    return 10;
                else if (b2.Text == "O")
                    return -10;
            }
            if (b3.Text == b6.Text && b3.Text == b9.Text)
            {
                if (b3.Text == "X")
                    return 10;
                else if (b3.Text == "O")
                    return -10;
            }
            if (b1.Text == b5.Text && b1.Text == b9.Text)
            {
                if (b1.Text == "X")
                    return 10;
                else if (b1.Text == "O")
                    return -10;
            }
            if (b3.Text == b5.Text && b3.Text == b7.Text)
            {
                if (b3.Text == "X")
                    return 10;
                else if (b3.Text == "O")
                    return -10;
            }
            return 0;
        }
        private int minimax(int depth, bool ismax)
        {
            int result = evaluate(), s = 0;
            if (result == 10)
                return result - depth;
            if (result == -10)
                return result + depth;
            foreach (Control btn in this.Controls)
            {
                if (btn.Text != "" && btn.Name != "button1")
                    s++;
            }
            if (s == 9)
                return 0;
            if (ismax)
            {
                int bestscore = -100;
                foreach (Control btn in this.Controls)
                {
                    if (btn.Text == "")
                    {
                        btn.Text = "X";
                        int score = minimax(depth + 1, false);
                        bestscore = Math.Max(bestscore, score);
                        btn.Text = "";
                    }

                }
                return bestscore;
            }
            else
            {
                int bestscore = 100;
                foreach (Control btn in this.Controls)
                {
                    if (btn.Text == "")
                    {
                        btn.Text = "O";
                        int score = minimax(depth + 1, true);
                        bestscore = Math.Min(bestscore, score);
                        btn.Text = "";
                    }

                }
                return bestscore;
            }
        }
        private string bestmove()
        {
            string name = "";
            int bestscore = 100;
            foreach (Button b in this.Controls.OfType<Button>())
            {
                if (b.Text == "" && b.Name != "button1")
                {
                    b.Text = "O";
                    int score = minimax(0, true);
                    b.Text = "";
                    if (score < bestscore)
                    {
                        bestscore = score;
                        name = b.Name;
                    }
                }
            }
            return name;
        }

        private void PlayAgain_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            foreach (Button b in this.Controls.OfType<Button>())
            {
                if (b.Name != "button1" && b.Name != "PlayAgain")
                {
                    b.Text = "";
                    b.Enabled = true;
                }
            }
            PlayAgain.Enabled = false;
            winner = false;
            turn = true;
            c = 0;
        }
        private bool pickwinner(bool value)
        {
            if (checkwin(winner))
            {
                if (turn)
                {
                    scorp1++;
                    label1.Text = StartPage.player1 + " Wins";
                }
                else
                {
                    scorp2++;
                    label1.Text = StartPage.player2 + " Wins";
                }
                foreach (Control d in this.Controls)
                {
                    if (d is Button)
                    {
                        if (d.Name != "button1")
                            d.Enabled = false;
                    }
                }
                PlayAgain.Enabled = true;
                label2.Text = StartPage.player1 + "-" + scorp1;
                label3.Text = scorp2 + "-" + StartPage.player2;
                value = true;
            }
            else if (c == 9 && checkwin(winner) == false)
            {
                label1.Text = "Draw";
                PlayAgain.Enabled = true;
                value = true;
            }
            if (mode)
            {
                if (c == 4 && checkwin(winner) == false)
                {
                    label1.Text = "Draw";
                    PlayAgain.Enabled = true;
                    value = true;
                }
            }
            return value;
        }

        private void exitform(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}