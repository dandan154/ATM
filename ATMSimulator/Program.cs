using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMSimulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public const int ACCOUNT_NO = 3;
        public static Account[] acc = new Account[ACCOUNT_NO];

        public static bool isDataRace = true; 

        /*Sets up example ATM example accounts*/
        public static void initializeAccounts()
        {
            acc[0] = new Account(300, 1111, 111111);
            acc[1] = new Account(750, 2222, 222222);
            acc[2] = new Account(3000, 3333, 333333);
        }

        public static void changeDataRace()
        {
            if(isDataRace == true)
            {
                isDataRace = false;
            }
            else
            {
                isDataRace = true;
            }
        }

        public static bool getIsDataRace()
        {
            return isDataRace;
        }

        [STAThread]
        static void Main()
        {
            initializeAccounts();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CentralComputer());
        }
    }
}
