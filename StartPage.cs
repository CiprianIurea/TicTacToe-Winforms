namespace TicTacToe
{
    public partial class StartPage : Form
    {
        public static string player1 = "", player2 = "";
        public static bool versus;
        public StartPage()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            TicTacToe game = new TicTacToe();
            game.ShowDialog();
        }

        private void vsai(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label1.Text = "Player";
                textBox1.Show();
                checkBox2.Enabled = false;
                versus = checkBox1.Checked;
            }
            else
            {
                label1.Text = "";
                textBox1.Hide();
                checkBox2.Enabled = true;
                versus = checkBox1.Checked;
            }
            tc(sender, e);
        }

        private void StartPage_Load(object sender, EventArgs e)
        {
            textBox1.Hide();
            textBox2.Hide();
        }

        private void vsplayer(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                label1.Text = "Player 1";
                textBox1.Show();
                label2.Text = "Player 2";
                textBox2.Show();
                checkBox1.Enabled = false;
            }
            else
            {
                label1.Text = "";
                textBox1.Hide();
                label2.Text = "";
                textBox2.Hide();
                checkBox1.Enabled = true;
            }
            tc(sender, e);
        }

        private void tc(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (textBox1.Text != "")
                    button1.Enabled = true;
                else
                    button1.Enabled = false;
                player1 = textBox1.Text;
                player2 = "AI";
            }
            else if (checkBox2.Checked)
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    if (textBox1.Text == textBox2.Text)
                        button1.Enabled = false;
                    else
                        button1.Enabled = true;
                }
                else
                    button1.Enabled = false;
                player1 = textBox1.Text;
                player2 = textBox2.Text;
            }
        }

        private void exitform(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}