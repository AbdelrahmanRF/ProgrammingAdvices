using System;
using System.Drawing;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
        bool isGameEnded = false;
        bool isPlayer1 = true;
        string GameWinner = "In Progress";
        PictureBox[,] Board = new PictureBox[3, 3];
        PictureBox[] WinMoves = new PictureBox[3];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Row 0
            Board[0, 0] = pbA1;
            Board[0, 1] = pbA2;
            Board[0, 2] = pbA3;

            // Row 1
            Board[1, 0] = pbB1;
            Board[1, 1] = pbB2;
            Board[1, 2] = pbB3;

            // Row 2
            Board[2, 0] = pbC1;
            Board[2, 1] = pbC2;
            Board[2, 2] = pbC3;
        }

        private bool CanGameContinue(PictureBox Choice)
        {
            if (isGameEnded)
                return false;

            if (!string.IsNullOrEmpty(Choice.Tag?.ToString()))
            {
                MessageBox.Show("Wrong Choice", "Invalid Move",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void TakeUserChoice(PictureBox Choice)
        {
            Choice.Tag = isPlayer1 ? "X" : "O";
            Choice.Image = isPlayer1 ? Resources.X : Resources.O;

            if (CheckIfGameEnded())
            {
                WrapTheGame();
            }
        }

        private bool CheckIfGameEnded()
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(Board[i, 0].Tag?.ToString()) &&
                    Board[i, 0].Tag.ToString() == Board[i, 1].Tag?.ToString() &&
                    Board[i, 1].Tag.ToString() == Board[i, 2].Tag?.ToString())
                {
                    WinMoves[0] = Board[i, 0];
                    WinMoves[1] = Board[i, 1];
                    WinMoves[2] = Board[i, 2];
                    return true;
                }
            }

            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(Board[0, i].Tag?.ToString()) &&
                    Board[0, i].Tag.ToString() == Board[1, i].Tag?.ToString() &&
                    Board[1, i].Tag.ToString() == Board[2, i].Tag?.ToString())
                {
                    WinMoves[0] = Board[0, i];
                    WinMoves[1] = Board[1, i];
                    WinMoves[2] = Board[2, i];
                    return true;
                }
            }

            // Check diagonals
            if (!string.IsNullOrEmpty(Board[1, 1].Tag?.ToString()))
            {
                if (Board[0, 0].Tag?.ToString() == Board[1, 1].Tag.ToString() &&
                    Board[1, 1].Tag.ToString() == Board[2, 2].Tag?.ToString())
                {
                    WinMoves[0] = Board[0, 0];
                    WinMoves[1] = Board[1, 1];
                    WinMoves[2] = Board[2, 2];
                    return true;
                }

                if (Board[0, 2].Tag?.ToString() == Board[1, 1].Tag.ToString() &&
                    Board[1, 1].Tag.ToString() == Board[2, 0].Tag?.ToString())
                {
                    WinMoves[0] = Board[0, 2];
                    WinMoves[1] = Board[1, 1];
                    WinMoves[2] = Board[2, 0];
                    return true;
                }
            }

            bool AllFilled = true;

            foreach(PictureBox Cell in Board)
            {
                if(String.IsNullOrEmpty(Cell.Tag?.ToString()))
                {
                    AllFilled = false;
                    break;
                }
            }

            if (AllFilled)
            {
                GameWinner = "Draw";
                return true;
            }

            return false;
        }


        private void WrapTheGame()
        {
            isGameEnded = true;

            if (GameWinner == "Draw")
            {
                lblWinner.Text = "Draw";
            }
            else
            {
                lblWinner.Text = WinMoves[0].Tag.ToString() == "X" ? "Player 1" : "Player 2";

                highlightWinMoves();
            }

            MessageBox.Show("Game Over", "Game Over",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void highlightWinMoves()
        {
            foreach (PictureBox Move in WinMoves)
            {
                Move.BackColor = Color.Yellow;
            }
        }

        private void SwitchPlayer()
        {
            if (isGameEnded)
            {
                lblTurn.Text = "Game Over";
                return;
            }

            isPlayer1 = !isPlayer1;

            lblTurn.Text = isPlayer1 ? "Player 1" : "Player 2";
        }

        private void ResetGame()
        {
            isGameEnded = false;
            isPlayer1 = true;
            GameWinner = "In Progress";

            lblTurn.Text = "Player 1";
            lblWinner.Text = GameWinner;

            foreach (PictureBox Cell in Board)
            {
                Cell.BackColor = Color.Transparent;
                Cell.Tag = null;
                Cell.Image = Resources.question_mark_96;
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.White;
            Pen Pen = new Pen(White);

            Pen.Width = 10;

            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(Pen, 477, 96, 477, 422);
            e.Graphics.DrawLine(Pen, 599, 96, 599, 422);

            e.Graphics.DrawLine(Pen, 363, 205, 715, 205);
            e.Graphics.DrawLine(Pen, 363, 313, 715, 313);
        }

        private void pb_Click(object sender, EventArgs e)
        {
            if (!CanGameContinue((PictureBox)sender)) return;

            TakeUserChoice((PictureBox)sender);

            SwitchPlayer();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

    }
}
