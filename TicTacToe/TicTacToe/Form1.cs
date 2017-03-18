using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        Spielfeld _feld = new Spielfeld();
        bool _zugfolge = false;
        bool _ende = true;

        public Form1()
        {
            
            InitializeComponent();
            button2.Click += ButtonClick;
            button3.Click += ButtonClick;
            button4.Click += ButtonClick;
            button5.Click += ButtonClick;
            button6.Click += ButtonClick;
            button7.Click += ButtonClick;
            button8.Click += ButtonClick;
            button9.Click += ButtonClick;
            button10.Click += ButtonClick;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int red = rnd.Next(1, 255);
            int green = rnd.Next(1, 255);
            int blue = rnd.Next(1, 255);
            

            button1.BackColor = Color.FromArgb(red, green, blue);
            listBox1.ScrollAlwaysVisible = false;
            if (!_ende)
            {
                listBox1.Items.Add("Spiel wurde bereits gestartet");
            }
            else
            {
                listBox1.Items.Add("Spiel wurde gestartet");
            }
            _ende = false;

        }

        private void ButtonClick(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = listBox1.Items.Count - 1;

            Button button = (Button)sender;
            if (_ende == true)
            {
                reset();
            }
            else
            {


                switch (button.Tag.ToString())
                {
                    case "[0,0]":
                        ClickAction(button);
                        break;

                    case "[0,1]":
                        ClickAction(button);
                        break;

                    case "[0,2]":
                        ClickAction(button);
                        break;

                    case "[1,0]":
                        ClickAction(button);
                        break;

                    case "[1,1]":
                        ClickAction(button);
                        break;

                    case "[1,2]":
                        ClickAction(button);
                        break;

                    case "[2,0]":
                        ClickAction(button);
                        break;

                    case "[2,1]":
                        ClickAction(button);
                        break;

                    case "[2,2]":
                        ClickAction(button);
                        break;
                }
                if (Wintest() == true)
                {
                    reset();

                    if (_zugfolge == true)
                    {
                        MessageBox.Show("Der Spieler O hat gewonnen");
                    }
                    else
                    {
                        MessageBox.Show("Der Spieler X hat gewonnen");
                    }
                }
                else
                {
                    if (_zugfolge == true)
                    {
                        textBox3.Text = "X";
                    }
                    else
                    {
                        textBox3.Text = "O";
                    }
                }
            }

            if (!button2.Text.Equals("1") && !button3.Text.Equals("2") && !button4.Text.Equals("3") &&
                !button5.Text.Equals("4") && !button6.Text.Equals("5") && !button7.Text.Equals("6") &&
                !button8.Text.Equals("7") && !button9.Text.Equals("8") && !button10.Text.Equals("9"))
            {
                _ende = true;
                reset();
                MessageBox.Show("Das war ein Unentschieden");
            }
            {
                
            }

        }

        private void ClickAction(Button button)
        {
            if (!button.Text.Equals("X") && !button.Text.Equals("O"))
            {
                listBox1.Items.Add(button.Text + " wurde gedrückt");
                if (_zugfolge == true)
                {
                    button.Text = "X";
                    _zugfolge = false;
                }
                else
                {
                    button.Text = "O";
                    _zugfolge = true;
                }
            }
            else
            {
                listBox1.Items.Add(button.AccessibleDescription + " ist bereits belegt");

            }

        }

        private bool Wintest()
        {
            // Reihe 1 - 2 - 3
            if (button2.Text.Equals(button3.Text) && button3.Text.Equals(button4.Text))
            {
                return true;
            // Reihe 4 - 5 - 6
            }else
            if (button5.Text.Equals(button6.Text) && button6.Text.Equals(button7.Text))
            {
                return true;
            // Reihe 7 - 8 - 9
            }else
            if (button8.Text.Equals(button9.Text) && button9.Text.Equals(button10.Text))
            {
                return true;
            //Reihe 1 - 5 - 9
            }else
            if (button2.Text.Equals(button6.Text) && button6.Text.Equals(button10.Text))
            {
                return true;
            //Reihe 8 - 6 - 3
            }else
            if (button8.Text.Equals(button6.Text) && button6.Text.Equals(button4.Text))
            {
                return true;
            //Reihe 1 - 4 - 7
            }else
            if (button2.Text.Equals(button5.Text) && button5.Text.Equals(button8.Text))
            {
                return true;
            //Reihe 2 - 5 - 8
            }else
            if (button3.Text.Equals(button6.Text) && button6.Text.Equals(button9.Text))
            {
                return true;
            //Reihe 3 - 6 - 9
            }else
            if (button4.Text.Equals(button7.Text) && button7.Text.Equals(button10.Text))
            {
                return true;
            }
            else
            {
                return false;
            }



        }

        private void reset()
        {
            button2.Text = "1";
            button3.Text = "2";
            button4.Text = "3";
            button5.Text = "4";
            button6.Text = "5";
            button7.Text = "6";
            button8.Text = "7";
            button9.Text = "8";
            button10.Text = "9";
            _ende = true;
            listBox1.Items.Clear();
            button1.BackColor = Color.LightGray;
            textBox3.Clear();


        }

        private void button11_MouseClick(object sender, MouseEventArgs e)
        {
            reset();

        }
    }
}
