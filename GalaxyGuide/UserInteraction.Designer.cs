namespace GalaxyGuide
{
    partial class UserInteraction
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnFileSelect = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtInputCommand = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.outputConsole = new MyListBox();
            this.SuspendLayout();
            // 
            // btnFileSelect
            // 
            this.btnFileSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileSelect.Location = new System.Drawing.Point(585, 35);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(75, 26);
            this.btnFileSelect.TabIndex = 0;
            this.btnFileSelect.Text = "File";
            this.btnFileSelect.UseVisualStyleBackColor = true;
            this.btnFileSelect.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(22, 38);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(557, 23);
            this.txtFileName.TabIndex = 4;
            // 
            // txtInputCommand
            // 
            this.txtInputCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputCommand.Location = new System.Drawing.Point(22, 397);
            this.txtInputCommand.Name = "txtInputCommand";
            this.txtInputCommand.Size = new System.Drawing.Size(710, 23);
            this.txtInputCommand.TabIndex = 2;
            this.txtInputCommand.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtInputCommand_PreviewKeyDown);
            // 
            // btnRun
            // 
            this.btnRun.Enabled = false;
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(666, 35);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(66, 26);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // outputConsole
            // 
            this.outputConsole.FormattingEnabled = true;
            this.outputConsole.Location = new System.Drawing.Point(22, 68);
            this.outputConsole.Name = "outputConsole";
            this.outputConsole.Size = new System.Drawing.Size(710, 316);
            this.outputConsole.TabIndex = 5;
            // 
            // UserInteraction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 429);
            this.Controls.Add(this.outputConsole);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtInputCommand);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnFileSelect);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(778, 468);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(778, 468);
            this.Name = "UserInteraction";
            this.Text = "UserInteraction";
            this.Load += new System.EventHandler(this.UserInteraction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtInputCommand;
        private System.Windows.Forms.Button btnRun;
        private MyListBox outputConsole;
    }
}