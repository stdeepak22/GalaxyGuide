using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalaxyGuide
{
    public partial class UserInteraction : Form
    {
        public UserInteraction()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileName = string.Empty;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openFileDialog1.FileName;
            }
            else
            {
                txtFileName.Text = string.Empty;
            }

            btnRun.Enabled = !string.IsNullOrEmpty(txtFileName.Text);
        }       

        private void UserInteraction_Load(object sender, EventArgs e)
        {
            LogMsg(outputConsole, "Enter the command in text box and hit <enter>.");            
        }
                
        Action<ILogWriter, string> LogMsg = (writer, s) =>
        {
            writer.WriteLog(s);
        };

        int lastIndex = 0;
        int totalItems = 0;
        private void txtInputCommand_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var userInput = txtInputCommand.Text;
                LogMsg(outputConsole, userInput);
                LogMsg(outputConsole, UserQueries.HandleInput(userInput));
                txtInputCommand.Clear();
                lastIndex = outputConsole.Items.Count;
            }
            else if(e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                totalItems = outputConsole.Items.Count;
                lastIndex = e.KeyCode == Keys.Up ? lastIndex - 1 : lastIndex + 1;

                if(lastIndex  < 0)
                {
                    lastIndex = 0;
                }
                else if (lastIndex >= totalItems)
                {
                    lastIndex = totalItems -1;
                }
                txtInputCommand.Text = outputConsole.Items[lastIndex].ToString();                
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var allLines = File.ReadAllLines(txtFileName.Text);
            var logFile = new TextFileWriter(txtFileName.Text);
            foreach (var oneLine in allLines)
            {
                LogMsg(outputConsole, oneLine);
                var output = UserQueries.HandleInput(oneLine);
                LogMsg(outputConsole, output);
                LogMsg(logFile, output);
            }
            logFile.Close();
        }
    }
}
