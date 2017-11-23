namespace ATMSimulator
{
    partial class CentralComputer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CentralComputer));
            this.btnRace = new System.Windows.Forms.Button();
            this.btnATM = new System.Windows.Forms.Button();
            this.lblDataRace = new System.Windows.Forms.Label();
            this.lblMain = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRace
            // 
            this.btnRace.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRace.Location = new System.Drawing.Point(136, 12);
            this.btnRace.Name = "btnRace";
            this.btnRace.Size = new System.Drawing.Size(121, 51);
            this.btnRace.TabIndex = 1;
            this.btnRace.Text = "Toggle Data Race";
            this.btnRace.UseVisualStyleBackColor = true;
            this.btnRace.Click += new System.EventHandler(this.btnRace_Click);
            // 
            // btnATM
            // 
            this.btnATM.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnATM.Location = new System.Drawing.Point(12, 12);
            this.btnATM.Name = "btnATM";
            this.btnATM.Size = new System.Drawing.Size(121, 51);
            this.btnATM.TabIndex = 2;
            this.btnATM.Text = "Create ATM";
            this.btnATM.UseVisualStyleBackColor = true;
            this.btnATM.Click += new System.EventHandler(this.btnATM_Click);
            // 
            // lblDataRace
            // 
            this.lblDataRace.AutoSize = true;
            this.lblDataRace.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataRace.Location = new System.Drawing.Point(154, 80);
            this.lblDataRace.Name = "lblDataRace";
            this.lblDataRace.Size = new System.Drawing.Size(0, 14);
            this.lblDataRace.TabIndex = 3;
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.Location = new System.Drawing.Point(33, 80);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(121, 14);
            this.lblMain.TabIndex = 4;
            this.lblMain.Text = "Data Race Status:";
            // 
            // CentralComputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 111);
            this.Controls.Add(this.lblMain);
            this.Controls.Add(this.lblDataRace);
            this.Controls.Add(this.btnATM);
            this.Controls.Add(this.btnRace);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CentralComputer";
            this.Text = "ATM Simulator";
            this.Load += new System.EventHandler(this.CentralComputer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRace;
        private System.Windows.Forms.Button btnATM;
        private System.Windows.Forms.Label lblDataRace;
        private System.Windows.Forms.Label lblMain;
    }
}

