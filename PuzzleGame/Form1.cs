using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Global Variables
        int moves = 0;
        const int rows = 3;
        const int cols = 3;
        HashSet<int> usedValues = new HashSet<int>(); // A hashset to store the used values from the random function so as to get a unique number each time
        Random rd = new Random();
        Button[,] button = new Button[3, 3];


        private void NewGame()
        {
            if (advancedToolStripMenuItem.Checked)
            {
                advancedMovesLabel.Visible = true;
                moves = 0;
                movesLabel.Text = "Move #0";
                advancedToolStripMenuItem.Checked = true;
                beginnerToolStripMenuItem.Checked = false;
                levelLabel.Text = "Level: Advanced";
                advancedMovesLabel.Text = moves + " out of 150 moves";
            }
            else
            { 
                advancedToolStripMenuItem.Checked = false;
                beginnerToolStripMenuItem.Checked = true;
                levelLabel.Text = "Level: Beginner";
                advancedMovesLabel.Visible = false;
            }
            // Clear the board and usedValues
            Array.Clear(button, 0, button.Length);
            usedValues.Clear();
            moves = 0;
            movesLabel.Text = "Move #0";

            int randomRow = rd.Next(0, 3);
            int randomCol = rd.Next(0, 3);
            
            button[0, 0] = button1;
            button[0, 1] = button2;
            button[0, 2] = button3;
            button[1, 0] = button4;
            button[1, 1] = button5;
            button[1, 2] = button6;
            button[2, 0] = button7;
            button[2, 1] = button8;
            button[2, 2] = button9;

            // Generate random numbers for the buttons
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                     int randomNumber;
                       
                    if (button[i, j] == button[randomRow, randomCol])
                    {
                        button[i, j].Text = "";
                    }
                    else
                    {
                        do
                        {
                          randomNumber = rd.Next(1, 9);
                        } while (!usedValues.Add(randomNumber));

                        button[i, j].Text = randomNumber.ToString();
                    }
                }
            }
        }

        public void isSolved()
        {
            if (advancedToolStripMenuItem.Checked)
            {
                if (moves > 150)
                {
                    MessageBox.Show("Exceeded 150 moves - You lose" + Environment.NewLine + "Press OK to close the game", "Puzzle failed");
                    this.Close();
                }
                advancedMovesLabel.Text = moves + " out of 150 moves";
            }
            else if (button1.Text == "1" && button2.Text == "2" && button3.Text == "3" && button4.Text == "8" && button5.Text == "" && button6.Text ==  "4" && button7.Text == "7" &&  button8.Text == "6" && button9.Text == "5")
            {
                MessageBox.Show("Congratulations - You Win!!!!"+ Environment.NewLine + "Moves needed to complete the puzzle: " + moves, "Puzzle solved", MessageBoxButtons.OK);
                NewGame();
            }
            else if (button1.Text == "1" && button2.Text == "2" && button3.Text == "3" && button4.Text == "4" && button5.Text == "5" && button6.Text == "6" && button7.Text == "7" && button8.Text == "8" && button9.Text == "")
            {
                MessageBox.Show("Congratulations - You Win" + Environment.NewLine + "Moves needed to complete the puzzle: " + moves + Environment.NewLine + "Press OK to start a new game", "Puzzle solved!", MessageBoxButtons.OK);
                NewGame();
            }
        }

        private void beginnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (beginnerToolStripMenuItem.Checked ) 
            {
                advancedToolStripMenuItem.Checked = false;
                NewGame();
            }
        }

        private void advancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (advancedToolStripMenuItem.Checked) 
            { 
                beginnerToolStripMenuItem.Checked = false;
                NewGame();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Programmer: Andreas Patsalos", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button2.Text == "")
            {
                button2.Text = button1.Text;
                button1.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
            else if (button4.Text == "")
            {
                button4.Text = button1.Text;
                button1.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button1.Text == "")
            {
                button1.Text = button2.Text;
                button2.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
            else if (button3.Text == "")
            {
                button3.Text = button2.Text;
                button2.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
            else if (button5.Text == "")
            {
                button5.Text = button2.Text;
                button2.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button2.Text == "")
            {
                button2.Text = button3.Text;
                button3.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
            else if (button6.Text == "")
            {
                button6.Text = button3.Text;
                button3.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button1.Text == "")
            {
                button1.Text = button4.Text;
                button4.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
            else if (button5.Text == "")
            {
                button5.Text = button4.Text;
                button4.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
            else if (button7.Text == "")
            {
                button7.Text = button4.Text;
                button4.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button2.Text == "")
            {
                button2.Text = button5.Text;
                button5.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
            else if (button6.Text == "")
            {
                button6.Text = button5.Text;
                button5.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
            else if (button8.Text == "")
            {
                button8.Text = button5.Text;
                button5.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
            else if (button4.Text == "")
            {
                button4.Text = button5.Text;
                button5.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button3.Text == "")
            {
                button3.Text = button6.Text;
                button6.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
            else if (button5.Text == "")
            {
                button5.Text = button6.Text;
                button6.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
            else if (button9.Text == "")
            {
                button9.Text = button6.Text;
                button6.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button4.Text == "")
            {
                button4.Text = button7.Text;
                button7.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
            else if (button8.Text == "")
            {
                button8.Text = button7.Text;
                button7.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button5.Text == "")
            {
                button5.Text = button8.Text;
                button8.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
            else if (button7.Text == "")
            {
                button7.Text = button8.Text;
                button8.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
            else if (button9.Text == "")
            {
                button9.Text = button8.Text;
                button8.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button6.Text == "")
            {
                button6.Text = button9.Text;
                button9.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
            else if (button8.Text == "")
            {
                button8.Text = button9.Text;
                button9.Text = "";
                movesLabel.Text = "Move #" + ++moves;
                isSolved();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NewGame();
            movesLabel.Text = "Move #0";
            levelLabel.Text = "Level: Beginner";
            isSolved();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void advancedToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (advancedToolStripMenuItem.Checked) 
            {
                MessageBox.Show("You have selected the advanced difficulty. You have 150 moves to solve the puzzle.");
                NewGame();
                levelLabel.Text = "Level: Advanced";
                advancedMovesLabel.Text = moves + " out of 150 moves";
            }
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightCoral;
            underlineLabel.BackColor = Color.Tan;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    button[i, j].BackColor = Color.Tan;
                }
            }
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGreen;
            underlineLabel.BackColor = Color.LightYellow;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    button[i, j].BackColor = Color.LightYellow;
                }
            }
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightSkyBlue;
            underlineLabel.BackColor = Color.LightGray;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    button[i, j].BackColor = Color.LightGray;
                }
            }
        }

        private void otherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog picker = new ColorDialog();

            if (picker.ShowDialog() == DialogResult.OK) {
                {
                    this.BackColor= picker.Color;
                } }
        }
    }
}
