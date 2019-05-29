using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool turn = true; // True = Xs turn; False = Os turn
        int turn_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Jeremiah", "About");
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;
            b.Enabled = false;
            turn_count++;

            checkForWinner();
        }

        private void checkForWinner() //checks for a winner
        {
            
            bool there_is_a_winner = false;

            //Check Horizontally
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;

            //Check Vertically
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;

            //Check Diagonally
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                there_is_a_winner = true;

            // reset; point counter; show winner and draw message
            if (there_is_a_winner)
            {
                disableButtons();

                String winner = "";

                if (turn)
                {
                    winner = "O";
                    o_wins.Text = (Int32.Parse(o_wins.Text) + 1).ToString();
                }
                else
                {
                    winner = "X";
                    x_wins.Text = (Int32.Parse(x_wins.Text) + 1).ToString();
                }

                MessageBox.Show(winner + " Wins!", "Winner");
                


            }//end if 
            
            else
            {
                if (turn_count == 9)
                {
                    draw_wins.Text = (Int32.Parse(draw_wins.Text) + 1).ToString();
                    MessageBox.Show("It's a draw!", "Try Again");
                }
            }//end else

        }//end checkForWinner

        
        private void disableButtons() //Disables the buttons when the game has ended
        {
            
                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = false;
                    }//end try
                    catch { }

            }//end foreach
            

        }//end disableButtons

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

          
                foreach (Control c in Controls)
                {
                    try
                     {
                          Button b = (Button)c;
                          b.Enabled = true;
                          b.Text = "";
                     }//end try
                    catch { }

            }//end foreach
            

        }

        private void button_enter(object sender, EventArgs e) //hovering over the button shows whose turn
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";

                else
                    b.Text = "O";
            }//end if

            
        }

        private void button_leave(object sender, EventArgs e) //reverts hover over the button text
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";

            }//end if
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ResetPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_wins.Text = "0";
            x_wins.Text = "0";
            draw_wins.Text = "0";
            turn = true;
            turn_count = 0;


            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }//end try
                catch { }

            }//end foreach

        }

    }
}
