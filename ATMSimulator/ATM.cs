using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMSimulator
{
    public partial class ATM : Form
    {
        /*---CONSTANTS---*/
        //ATM Form
        public const int FORM_SIZE = 400;       //Size (pixels) of each form axis
        public const int FORM_MARGIN_Y = 20;    //Size (pixels) of top vertical margin 

        //Keypad
        public const int KEYPAD_AXIS = 3;   //Number of Buttons on a single line of the keypad
        public const int KEYPAD_SIZE = 50;  //Size (pixels) of each keypad button 

        //Display Screen
        public const int MAX_ACCOUNT = 6;   //Max string length of Account Number
        public const int MAX_PIN = 4;       //Max string length of Pin Number

        public const int WITHDRAW_1 = 5;    //Amount withdrawn when btnLeftHigh is clicked
        public const int WITHDRAW_2 = 10;   //Amount withdrawn when btnLeftLow is clicked
        public const int WITHDRAW_3 = 20;   //Amount withdrawn when btnRightHigh is clicked

        /*---UI ELEMENTS---*/
        Button[] keypad = new Button[(KEYPAD_AXIS * KEYPAD_AXIS) + 1];

        /*---VARIABLES---*/
        private int curAccount; 
        private string curState = "account";

        public ATM()
        {
            InitializeComponent();
        }

        private void ATM_Load(object sender, EventArgs e)
        {
            InitializeForm();
            InitializeKeypad();
            stateDisplayChange();
            
        }

        /*Customise Input Keypad Appearance*/
        public void InitializeKeypad()
        {
            //keypad array reference
            int counter = 1;    

            //create offset to center keypad horizontally
            int offsetX = FORM_SIZE/2 - ((KEYPAD_AXIS * KEYPAD_SIZE)/2) - KEYPAD_SIZE/2;  

            //create offset to center keypad vertically 
            int offsetY = FORM_SIZE/2 - ((KEYPAD_AXIS * KEYPAD_SIZE)/2) + KEYPAD_SIZE/2;     


            //Create and customise keypad buttons 1 - 9
            for (int i = 0; i < KEYPAD_AXIS; i++)
            {
                for(int j = 0; j < KEYPAD_AXIS; j++)
                {
                    //Assign array value to new button
                    keypad[counter] = new Button();

                    //Set size and location of keypad button
                    keypad[counter].SetBounds(offsetX + (KEYPAD_SIZE * j), offsetY + (KEYPAD_SIZE * i), KEYPAD_SIZE, KEYPAD_SIZE);

                    //Display representative value on keypad button
                    keypad[counter].Text = Convert.ToString(counter);

                    //Change keypad button color
                    keypad[counter].BackColor = Color.Gainsboro;
                    keypad[counter].FlatAppearance.BorderColor = Color.Gainsboro;
                    keypad[counter].Font = new Font("Verdana", 10);

                   // keypad[counter].Font = MAIN_FONT; 

                    //Attach event handler to keypad button
                    keypad[counter].Click += new EventHandler(this.btnKeypad_Click);

                    //Add keypad button to ATM form 
                    Controls.Add(keypad[counter]);

                    //Increment button number
                    counter++;
                }
            }

            //Create and customise keypad button 0 
            keypad[0] = new Button();
            keypad[0].SetBounds(offsetX + KEYPAD_SIZE, offsetY + (KEYPAD_SIZE * KEYPAD_AXIS), KEYPAD_SIZE, KEYPAD_SIZE);
            keypad[0].Text = "0";
            keypad[0].BackColor = Color.Gainsboro;
            keypad[0].FlatAppearance.BorderColor = Color.Gainsboro;
            keypad[0].Font = new Font("Verdana", 10);
            Controls.Add(keypad[0]);
        }

        /*Customise ATM Form Appearance*/
        public void InitializeForm()
        {
            this.ClientSize = new Size(FORM_SIZE, FORM_SIZE);
            
        }

        /*Change ATM screen based on the current state*/
        public void stateDisplayChange()
        {
            if (curState == "account")
            {
                lblMain.Text = "Please Enter Your Account Number: ";
            }
            else if(curState == "pin")
            {
                lblMain.Text = "Please Enter Your Pin Number: ";
            }
            else if(curState == "menu")
            {
                lblMain.Visible = false;
                lblInput.Visible = false; 
                lblLeftHigh.Text = "Check Balance";
                lblLeftLow.Text = "Withdraw Cash";
                lblRightLow.Text = "Quit";
            }
            else if(curState == "balance")
            {
                lblMain.Visible = true;
                lblMain.Text = "Your Current Balance is: £" + Program.acc[curAccount].getBalance();
                lblRightLow.Text = "Back";
            }
            else if(curState == "withdraw")
            {
                lblMain.Visible = false;
                lblInput.Visible = false;
                lblLeftHigh.Text = "£" + WITHDRAW_1;
                lblLeftLow.Text = "£" + WITHDRAW_2;
                lblRightHigh.Text = "£" + WITHDRAW_3;
                lblRightLow.Text = "Back";
            }
        }

        /*Clears entire display of all text*/
        public void stateDisplayClear()
        {
            lblMain.Text = "";
            lblInput.Text = "";
            lblLeftHigh.Text = "";
            lblLeftLow.Text = "";
            lblRightHigh.Text = "";
            lblRightLow.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblInput.Text = "";
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            int input = 0;
            bool accountFound = false;

            if(lblInput.Text != "")
            {
                input = Convert.ToInt32(lblInput.Text);
            }

            if(curState == "account")
            {
                for (int i = 0; i < Program.ACCOUNT_NO; i++)
                {
                    if (Program.acc[i].getAccountNum() == input)
                    {
                        curAccount = i; 
                        curState = "pin";
                        accountFound = true;

                        stateDisplayClear();
                        stateDisplayChange();
                    }
                    else if(accountFound == false)
                    {
                        stateDisplayClear();
                        lblMain.Text = "Invalid Account, please try again: ";
                    }
                }
            }
            else if(curState == "pin")
            {
                if(Program.acc[curAccount].checkPin(input))
                {
                    curState = "menu";
                    stateDisplayClear();
                    stateDisplayChange();
                }
                else
                {
                    stateDisplayClear();
                    lblMain.Text = "Invalid Pin, Please try again: ";
                }
            }
        }
        private void btnKeypad_Click(object sender, EventArgs e)
        {
            Button tmp = sender as Button;

            if (curState == "account")
            {
                //Ensure input stays on screen 
                if (lblInput.Text.Length < MAX_ACCOUNT)
                {
                    //Append input with keypad value
                    lblInput.Text = lblInput.Text + tmp.Text;
                }
            }
            else if (curState == "pin")
            {
                if (lblInput.Text.Length < MAX_PIN)
                {
                    lblInput.Text = lblInput.Text + tmp.Text;
                }
            }

        }

        private void btnRightLow_Click(object sender, EventArgs e)
        {
            if (curState == "menu")
            {
                this.Close();
            }
            else if(curState == "balance" || curState == "withdraw")
            {
                curState = "menu";
                stateDisplayClear();
                stateDisplayChange();

            }

        }
        private void btnLeftHigh_Click(object sender, EventArgs e)
        {
            if(curState == "menu")
            {
                curState = "balance";
                stateDisplayClear();
                stateDisplayChange(); 
            }
            else if (curState == "withdraw")
            {
                Program.acc[curAccount].decrementBalance(WITHDRAW_1);
            }
        }
        private void btnLeftBottom_Click(object sender, EventArgs e)
        {
            if (curState == "menu")
            {
                curState = "withdraw";
                stateDisplayClear();
                stateDisplayChange();
            }
            else if (curState == "withdraw")
            {
                Program.acc[curAccount].decrementBalance(WITHDRAW_2);
            }
        }
        private void btnRightHigh_Click(object sender, EventArgs e)
        {
            if (curState == "withdraw")
            {
                Program.acc[curAccount].decrementBalance(WITHDRAW_3);
            }
        }

        private void withdrawFromAccount(int withdrawl)
        {
            if(!Program.acc[curAccount].decrementBalance(withdrawl))
            {
                stateDisplayClear();

            }
        }

    }
}
