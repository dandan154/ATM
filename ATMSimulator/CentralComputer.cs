using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMSimulator
{
    
    public partial class CentralComputer : Form
    {
        
        public CentralComputer()
        {
            InitializeComponent();
           
        }

        private void CentralComputer_Load(object sender, EventArgs e)
        {
            lblDataRace.Text = "ACTIVE";
            lblDataRace.ForeColor = Color.Green; 
        }

        public void runATM()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ATM());
        }


        private void btnATM_Click(object sender, EventArgs e)
        {
            Thread ATM_t = new Thread(runATM);
            ATM_t.Start();
        }

        private void btnRace_Click(object sender, EventArgs e)
        {
            if(Program.getIsDataRace() == true)
            {
                Program.changeDataRace();
                lblDataRace.Text = "INACTIVE";
                lblDataRace.ForeColor = Color.Red;
            }
            else
            {
                Program.changeDataRace();
                lblDataRace.Text = "ACTIVE";
                lblDataRace.ForeColor = Color.Green;
            }
        }
    }
}
