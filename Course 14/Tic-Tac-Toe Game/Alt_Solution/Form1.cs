using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1; 
        enum enPlayer { Player1, Player2 }

        enum enWinner { Player1, Player2, Draw, GameInProgress }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public byte PlayCount;
        };


        public Form1()
        {
            InitializeComponent();
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

        private void EndGame()
        {
            lblTurn.Text = "Game Over";

            switch(GameStatus.Winner)
            {
                case enWinner.Player1:
                    lblWinner.Text = "Player 1";
                    break;

                case enWinner.Player2:
                    lblWinner.Text = "Player 2";
                    break;

                default:
                    lblWinner.Text = "Draw";
                    break;
            }

            MessageBox.Show("Game Over", "Game Over",
             MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool CheckValues(Button Cell1, Button Cell2, Button Cell3)
        {
            if (Cell1.Tag.ToString() != "?" && Cell1.Tag.ToString() == Cell2.Tag.ToString() && Cell1.Tag.ToString() == Cell3.Tag.ToString())
            {
                Cell1.BackColor = Color.GreenYellow;
                Cell2.BackColor = Color.GreenYellow;
                Cell3.BackColor = Color.GreenYellow;

                if(Cell1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
            }

            GameStatus.GameOver = false;
            return false;
        }

        private void CheckWinner()
        {
            // Check rows
            if (CheckValues(btnA1, btnB1, btnC1))
                return;

            if (CheckValues(btnA2, btnB2, btnC2))
                return;

            if (CheckValues(btnA3, btnB3, btnC3))
                return;

            // Check columns
            if (CheckValues(btnA1, btnA2, btnA3))
                return;

            if (CheckValues(btnB1, btnB2, btnB3))
                return;

            if (CheckValues(btnC1, btnC2, btnC3))
                return;

            // Check diagonals
            if (CheckValues(btnA1, btnB2, btnC3))
                return;

            if (CheckValues(btnC1, btnB2, btnA3))
                return;
        }

        private void ChangeImage(Button btn)
        {
            if (btn.Tag.ToString() == "?")
            {
                switch(PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Resources.X;
                        btn.Tag = "X";
                        PlayerTurn = enPlayer.Player2;
                        lblTurn.Text = "Player 2";
                        GameStatus.PlayCount++;
                        CheckWinner();
                        break;

                    case enPlayer.Player2:
                        btn.Image = Resources.O;
                        btn.Tag = "O";
                        PlayerTurn = enPlayer.Player1;
                        lblTurn.Text = "Player 1";
                        GameStatus.PlayCount++;
                        CheckWinner();
                        break;
                }

                if(GameStatus.PlayCount == 9)
                {
                    GameStatus.GameOver = true;
                    GameStatus.Winner = enWinner.Draw;
                    EndGame();
                }
            }
            else
            {
                MessageBox.Show("Wrong Choice", "Invalid Move",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetButton(Button Cell)
        {
            Cell.BackColor = Color.Transparent;
            Cell.Tag = "?";
            Cell.Image = Resources.question_mark_96;
        }

        private void RestartGame()
        {
            ResetButton(btnA1);
            ResetButton(btnA2);
            ResetButton(btnA3);

            ResetButton(btnB1);
            ResetButton(btnB2);
            ResetButton(btnB3);

            ResetButton(btnC1);
            ResetButton(btnC2);
            ResetButton(btnC3);

            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player 1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            lblWinner.Text = "In Progress";
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            ChangeImage((Button)sender);
        }

    }
}
