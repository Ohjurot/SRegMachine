using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRegMachine
{
    public partial class Form_SRegMachine : Form {
        // Register machine
        private Lib.RegisterMachine m_regMachine;
        private bool m_needCompile = true;

        public Form_SRegMachine(string loadFile) {
            InitializeComponent();

            // If not null
            if (loadFile != null) {
                // Open stream
                System.IO.Stream inStream = System.IO.File.Open(loadFile, System.IO.FileMode.Open);
                // Open reader
                System.IO.StreamReader reader = new System.IO.StreamReader(inStream);

                // Get text
                instructions_RTB.Text = reader.ReadToEnd();

                // Close
                reader.Close();
                inStream.Close();
            }
        }

        // Compile script
        private bool compileScript() {
            // Compile if require
            if (m_needCompile) {
                // Load
                loadState();

                // Parse and update
                m_needCompile = !m_regMachine.parse(instructions_RTB.Text);
                if (!m_needCompile) {
                    updateState();
                }
            }

            // Return result
            return !m_needCompile;
        }

        // Update state from register machine
        private void updateState() {
            // Registers
            registerTB_RA.Text = m_regMachine.register[0].ToString();
            registerTB_RB.Text = m_regMachine.register[1].ToString();
            registerTB_RC.Text = m_regMachine.register[2].ToString();
            registerTB_RD.Text = m_regMachine.register[3].ToString();
            registerTB_RW.Text = m_regMachine.register[4].ToString();
            registerTB_RX.Text = m_regMachine.register[5].ToString();
            registerTB_RY.Text = m_regMachine.register[6].ToString();
            registerTB_RZ.Text = m_regMachine.register[7].ToString();

            // Flags
            system_FlagsTB.Text = "";
            if (m_regMachine.negFlag) system_FlagsTB.Text += "neg ";
            if (m_regMachine.ovFlag) system_FlagsTB.Text += "ov ";
            if (m_regMachine.zeroFlag) system_FlagsTB.Text += "zero ";

            // PC Peek
            system_PeekTB.Text = m_regMachine.pcPeek();
        }

        private void loadState() {
            UInt16.TryParse(registerTB_RA.Text, out m_regMachine.register[0]);
            UInt16.TryParse(registerTB_RB.Text, out m_regMachine.register[1]);
            UInt16.TryParse(registerTB_RC.Text, out m_regMachine.register[2]);
            UInt16.TryParse(registerTB_RD.Text, out m_regMachine.register[3]);
            UInt16.TryParse(registerTB_RW.Text, out m_regMachine.register[4]);
            UInt16.TryParse(registerTB_RX.Text, out m_regMachine.register[5]);
            UInt16.TryParse(registerTB_RY.Text, out m_regMachine.register[6]);
            UInt16.TryParse(registerTB_RZ.Text, out m_regMachine.register[7]);
        }

        private void Form_SRegMachine_Load(object sender, EventArgs e) {
            // Create register machine
            m_regMachine = new Lib.RegisterMachine();
        }

        private void fileOpenBTN_Click(object sender, EventArgs e) {
            // Check is discard can happen
            if(instructions_RTB.Text.Length != 0) { 
                if(MessageBox.Show(null, "Opening another file will discard all unsaved changes!\nContinue?", "SRegMachine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No){
                    return;
                }
            } 
            
            // Create open file dialog
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.RestoreDirectory = true;
            ofd.Filter = "SReg Assembler File (*.sra)|*.sra";
            ofd.Title = "Open Assembler File";

            // Show 
            if(ofd.ShowDialog() == DialogResult.OK) {
                // Open file
                System.IO.Stream inStream =  ofd.OpenFile();
                // Create Reader
                System.IO.StreamReader reader = new System.IO.StreamReader(inStream);
                // Read all lines
                instructions_RTB.Text = reader.ReadToEnd();

                // Close
                reader.Close();
                inStream.Close();
            }
        }

        private void fileSaveBTN_Click(object sender, EventArgs e) {
            // Create save file dialog
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.RestoreDirectory = true;
            sfd.Filter = "SReg Assembler File (*.sra)|*.sra";
            sfd.Title = "Save Assembler File";

            // Show 
            if (sfd.ShowDialog() == DialogResult.OK) {
                // Get stream
                System.IO.Stream outStream = sfd.OpenFile();
                // Store file
                System.IO.StreamWriter writer = new System.IO.StreamWriter(outStream);
                // Write lines
                writer.Write(instructions_RTB.Text);

                // Close
                writer.Close();
                outStream.Close();
            }
        }

        private void run_fastBTN_Click(object sender, EventArgs e) {
            // Compile
            if (compileScript()) {
                // Execute
                while (m_regMachine.stepInstruction()) ;
                // Update
                updateState();
            }
        }

        private void instructions_RTB_TextChanged(object sender, EventArgs e) {
            m_needCompile = true;
        }

        private void run_delayedBTN_Click(object sender, EventArgs e) {
            if (compileScript()) {
                // Extract text
                string text = runDelayedTime_TB.Text.Replace(" ms", "");

                // Check timing
                UInt16 delayTime = 0;
                if (UInt16.TryParse(text, out delayTime)) {
                    // Setup timer
                    stepTimer.Interval = delayTime;
                    stepTimer.Enabled = true;

                    // Diable buttons
                    runDelayedTime_TB.Enabled = false;
                    run_stepBTN.Enabled = false;
                    run_delayedBTN.Enabled = false;
                    run_fastBTN.Enabled = false;
                }
            }
        }

        private void resetBTN_Click(object sender, EventArgs e) {
            // Reset timer
            stepTimer.Enabled = false;
            
            // Reset machine
            m_needCompile = true;
            m_regMachine.reset();
            loadState();

            // Clear peek
            system_PeekTB.Text = "";

            // Enable buttons
            runDelayedTime_TB.Enabled = true;
            run_stepBTN.Enabled = true;
            run_delayedBTN.Enabled = true;
            run_fastBTN.Enabled = true;

            // Compile
            compileScript();
        }

        private void stepTimer_Tick(object sender, EventArgs e) {
            // Step
            if (!m_regMachine.stepInstruction()) {
                updateState();
            }

            // Update
            updateState();
        }

        private void run_stepBTN_Click(object sender, EventArgs e) {
            // Compile
            if (compileScript()) {
                // Step and update
                m_regMachine.stepInstruction();
                updateState();
            }
        }

        private void registerTB_RA_TextChanged(object sender, EventArgs e) {
            loadState();
        }
    }
}
