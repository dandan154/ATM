using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    class Account
    {

        private int balance;
        private int pin;
        private int accountNum;

        /*Constructor*/
        public Account(int bal, int p, int accNum)
        {
            this.balance = bal;
            this.pin = p;
            this.accountNum = accNum;
        }

        /*
         * Removes money from account balance if funds are avaliable
         * 
         * returns:
         * true if balance > value to take out
         * false if balance 
         * 
         */
        public Boolean decrementBalance(int amount)
        {
            int bal = balance;

            if (Program.getIsDataRace() == true)
            {
                System.Threading.Thread.Sleep(3000);
            }

            if (balance >= amount)
            {
                balance = bal - amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * Checks pin against integer entered into function
         *
         * returns:
         * true if they match
         * false if they don't
         */
        public Boolean checkPin(int pinEntered)
        {
            if (pinEntered == pin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //get and set functions for balance
        public int getBalance()
        {
            return balance;
        }
        public void setBalance(int newBalance)
        {
            balance = newBalance;
        }

        //get function for accountNum
        public int getAccountNum()
        {
            return accountNum;
        }

    }
}
