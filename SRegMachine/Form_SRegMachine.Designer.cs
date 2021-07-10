
namespace SRegMachine
{
    partial class Form_SRegMachine
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SRegMachine));
            this.registerTB_RA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.registerTB_RB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.registerTB_RC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.registerTB_RD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.registerTB_RZ = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.registerTB_RY = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.registerTB_RX = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.registerTB_RW = new System.Windows.Forms.TextBox();
            this.instructions_RTB = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.system_FlagsTB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.system_PeekTB = new System.Windows.Forms.TextBox();
            this.run_delayedBTN = new System.Windows.Forms.Button();
            this.register_GP = new System.Windows.Forms.GroupBox();
            this.runDelayedTime_TB = new System.Windows.Forms.MaskedTextBox();
            this.run_GP = new System.Windows.Forms.GroupBox();
            this.fileSaveBTN = new System.Windows.Forms.Button();
            this.resetBTN = new System.Windows.Forms.Button();
            this.fileOpenBTN = new System.Windows.Forms.Button();
            this.run_stepBTN = new System.Windows.Forms.Button();
            this.run_fastBTN = new System.Windows.Forms.Button();
            this.stepTimer = new System.Windows.Forms.Timer(this.components);
            this.register_GP.SuspendLayout();
            this.run_GP.SuspendLayout();
            this.SuspendLayout();
            // 
            // registerTB_RA
            // 
            resources.ApplyResources(this.registerTB_RA, "registerTB_RA");
            this.registerTB_RA.Name = "registerTB_RA";
            this.registerTB_RA.Leave += new System.EventHandler(this.registerTB_RA_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // registerTB_RB
            // 
            resources.ApplyResources(this.registerTB_RB, "registerTB_RB");
            this.registerTB_RB.Name = "registerTB_RB";
            this.registerTB_RB.Leave += new System.EventHandler(this.registerTB_RA_TextChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // registerTB_RC
            // 
            resources.ApplyResources(this.registerTB_RC, "registerTB_RC");
            this.registerTB_RC.Name = "registerTB_RC";
            this.registerTB_RC.Leave += new System.EventHandler(this.registerTB_RA_TextChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // registerTB_RD
            // 
            resources.ApplyResources(this.registerTB_RD, "registerTB_RD");
            this.registerTB_RD.Name = "registerTB_RD";
            this.registerTB_RD.Leave += new System.EventHandler(this.registerTB_RA_TextChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // registerTB_RZ
            // 
            resources.ApplyResources(this.registerTB_RZ, "registerTB_RZ");
            this.registerTB_RZ.Name = "registerTB_RZ";
            this.registerTB_RZ.Leave += new System.EventHandler(this.registerTB_RA_TextChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // registerTB_RY
            // 
            resources.ApplyResources(this.registerTB_RY, "registerTB_RY");
            this.registerTB_RY.Name = "registerTB_RY";
            this.registerTB_RY.Leave += new System.EventHandler(this.registerTB_RA_TextChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // registerTB_RX
            // 
            resources.ApplyResources(this.registerTB_RX, "registerTB_RX");
            this.registerTB_RX.Name = "registerTB_RX";
            this.registerTB_RX.Leave += new System.EventHandler(this.registerTB_RA_TextChanged);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // registerTB_RW
            // 
            resources.ApplyResources(this.registerTB_RW, "registerTB_RW");
            this.registerTB_RW.Name = "registerTB_RW";
            this.registerTB_RW.Leave += new System.EventHandler(this.registerTB_RA_TextChanged);
            // 
            // instructions_RTB
            // 
            resources.ApplyResources(this.instructions_RTB, "instructions_RTB");
            this.instructions_RTB.Name = "instructions_RTB";
            this.instructions_RTB.TextChanged += new System.EventHandler(this.instructions_RTB_TextChanged);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // system_FlagsTB
            // 
            resources.ApplyResources(this.system_FlagsTB, "system_FlagsTB");
            this.system_FlagsTB.Name = "system_FlagsTB";
            this.system_FlagsTB.ReadOnly = true;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // system_PeekTB
            // 
            resources.ApplyResources(this.system_PeekTB, "system_PeekTB");
            this.system_PeekTB.Name = "system_PeekTB";
            this.system_PeekTB.ReadOnly = true;
            // 
            // run_delayedBTN
            // 
            resources.ApplyResources(this.run_delayedBTN, "run_delayedBTN");
            this.run_delayedBTN.Name = "run_delayedBTN";
            this.run_delayedBTN.UseVisualStyleBackColor = true;
            this.run_delayedBTN.Click += new System.EventHandler(this.run_delayedBTN_Click);
            // 
            // register_GP
            // 
            this.register_GP.Controls.Add(this.label9);
            this.register_GP.Controls.Add(this.system_FlagsTB);
            this.register_GP.Controls.Add(this.label10);
            this.register_GP.Controls.Add(this.label5);
            this.register_GP.Controls.Add(this.system_PeekTB);
            this.register_GP.Controls.Add(this.registerTB_RZ);
            this.register_GP.Controls.Add(this.label1);
            this.register_GP.Controls.Add(this.label6);
            this.register_GP.Controls.Add(this.registerTB_RA);
            this.register_GP.Controls.Add(this.registerTB_RY);
            this.register_GP.Controls.Add(this.registerTB_RB);
            this.register_GP.Controls.Add(this.label7);
            this.register_GP.Controls.Add(this.label2);
            this.register_GP.Controls.Add(this.registerTB_RX);
            this.register_GP.Controls.Add(this.registerTB_RC);
            this.register_GP.Controls.Add(this.label8);
            this.register_GP.Controls.Add(this.label3);
            this.register_GP.Controls.Add(this.registerTB_RW);
            this.register_GP.Controls.Add(this.registerTB_RD);
            this.register_GP.Controls.Add(this.label4);
            resources.ApplyResources(this.register_GP, "register_GP");
            this.register_GP.Name = "register_GP";
            this.register_GP.TabStop = false;
            // 
            // runDelayedTime_TB
            // 
            resources.ApplyResources(this.runDelayedTime_TB, "runDelayedTime_TB");
            this.runDelayedTime_TB.Name = "runDelayedTime_TB";
            this.runDelayedTime_TB.ValidatingType = typeof(System.DateTime);
            // 
            // run_GP
            // 
            this.run_GP.Controls.Add(this.fileSaveBTN);
            this.run_GP.Controls.Add(this.resetBTN);
            this.run_GP.Controls.Add(this.fileOpenBTN);
            this.run_GP.Controls.Add(this.run_stepBTN);
            this.run_GP.Controls.Add(this.run_fastBTN);
            this.run_GP.Controls.Add(this.run_delayedBTN);
            this.run_GP.Controls.Add(this.runDelayedTime_TB);
            resources.ApplyResources(this.run_GP, "run_GP");
            this.run_GP.Name = "run_GP";
            this.run_GP.TabStop = false;
            // 
            // fileSaveBTN
            // 
            resources.ApplyResources(this.fileSaveBTN, "fileSaveBTN");
            this.fileSaveBTN.Name = "fileSaveBTN";
            this.fileSaveBTN.UseVisualStyleBackColor = true;
            this.fileSaveBTN.Click += new System.EventHandler(this.fileSaveBTN_Click);
            // 
            // resetBTN
            // 
            resources.ApplyResources(this.resetBTN, "resetBTN");
            this.resetBTN.Name = "resetBTN";
            this.resetBTN.UseVisualStyleBackColor = true;
            this.resetBTN.Click += new System.EventHandler(this.resetBTN_Click);
            // 
            // fileOpenBTN
            // 
            resources.ApplyResources(this.fileOpenBTN, "fileOpenBTN");
            this.fileOpenBTN.Name = "fileOpenBTN";
            this.fileOpenBTN.UseVisualStyleBackColor = true;
            this.fileOpenBTN.Click += new System.EventHandler(this.fileOpenBTN_Click);
            // 
            // run_stepBTN
            // 
            resources.ApplyResources(this.run_stepBTN, "run_stepBTN");
            this.run_stepBTN.Name = "run_stepBTN";
            this.run_stepBTN.UseVisualStyleBackColor = true;
            this.run_stepBTN.Click += new System.EventHandler(this.run_stepBTN_Click);
            // 
            // run_fastBTN
            // 
            resources.ApplyResources(this.run_fastBTN, "run_fastBTN");
            this.run_fastBTN.Name = "run_fastBTN";
            this.run_fastBTN.UseVisualStyleBackColor = true;
            this.run_fastBTN.Click += new System.EventHandler(this.run_fastBTN_Click);
            // 
            // stepTimer
            // 
            this.stepTimer.Tick += new System.EventHandler(this.stepTimer_Tick);
            // 
            // Form_SRegMachine
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Controls.Add(this.run_GP);
            this.Controls.Add(this.register_GP);
            this.Controls.Add(this.instructions_RTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_SRegMachine";
            this.Load += new System.EventHandler(this.Form_SRegMachine_Load);
            this.register_GP.ResumeLayout(false);
            this.register_GP.PerformLayout();
            this.run_GP.ResumeLayout(false);
            this.run_GP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox registerTB_RA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox registerTB_RB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox registerTB_RC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox registerTB_RD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox registerTB_RZ;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox registerTB_RY;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox registerTB_RX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox registerTB_RW;
        private System.Windows.Forms.RichTextBox instructions_RTB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox system_FlagsTB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox system_PeekTB;
        private System.Windows.Forms.Button run_delayedBTN;
        private System.Windows.Forms.GroupBox register_GP;
        private System.Windows.Forms.MaskedTextBox runDelayedTime_TB;
        private System.Windows.Forms.GroupBox run_GP;
        private System.Windows.Forms.Button run_fastBTN;
        private System.Windows.Forms.Button resetBTN;
        private System.Windows.Forms.Button run_stepBTN;
        private System.Windows.Forms.Button fileOpenBTN;
        private System.Windows.Forms.Button fileSaveBTN;
        private System.Windows.Forms.Timer stepTimer;
    }
}

