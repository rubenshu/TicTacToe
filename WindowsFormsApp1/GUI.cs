using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TicTacToeEngine;

namespace TicTacToeGUI
{
    public partial class GUI : Form
    {
        readonly TicTacToeEngine.TicTacToeEngine TTTEngine = new TicTacToeEngine.TicTacToeEngine();

        // Initialize Designer support for GUI
        public GUI()
        {
            InitializeComponent();
            label2.Text = TTTEngine.Gamestate.ToString();
        }

        // ButtonClick on Grid items
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (Int32.TryParse(button.Text, out int cell))
            {
                if (TTTEngine.ChooseCell(cell))
                {
                    // Assign player to cell
                    button.Text = TTTEngine.AssignCell(cell);
                    // Check for a winner
                    if (TTTEngine.CheckWinner()) {
                        Button[] buttonList = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
                        int i = 1;
                        pictureBox1.Visible = true;

                        foreach (Button b in buttonList)
                        {
                            b.Enabled = false;
                            i++;
                        }
                    }
                    // Display next move
                    label2.Text = TTTEngine.Gamestate.ToString();
                }
            }
        }

        // Button10: reset gamestate
        private void Button10_Click(object sender, EventArgs e)
        {
            TTTEngine.Reset();
            label2.Text = TTTEngine.Gamestate.ToString();
            Resetgrid();
        }

        // Reset grid back to defaults
        private void Resetgrid()
        {
            Button[] buttonList = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            int i = 1;
            if (pictureBox1.Visible == true)
            {
                pictureBox1.Visible = false;
            }

            foreach (Button b in buttonList)
            {
                b.Text = i.ToString();
                b.Enabled = true;
                i++;
            }
        }
    }
}
