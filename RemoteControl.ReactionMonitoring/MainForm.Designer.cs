
namespace RemoteControl.ReactionMonitoring
{
    partial class MainForm
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
            this.labelCmdDir = new System.Windows.Forms.Label();
            this.labelResponseDir = new System.Windows.Forms.Label();
            this.textBoxCmdDir = new System.Windows.Forms.TextBox();
            this.textBoxResponseDir = new System.Windows.Forms.TextBox();
            this.buttonGetReactions = new System.Windows.Forms.Button();
            this.labelReactions = new System.Windows.Forms.Label();
            this.comboBoxReaction = new System.Windows.Forms.ComboBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonResume = new System.Windows.Forms.Button();
            this.textBoxResponse = new System.Windows.Forms.TextBox();
            this.labelResponse = new System.Windows.Forms.Label();
            this.labelTimeout = new System.Windows.Forms.Label();
            this.numericUpDownTimeout = new System.Windows.Forms.NumericUpDown();
            this.buttonBrowseCommandDir = new System.Windows.Forms.Button();
            this.buttonBrowseResponseDir = new System.Windows.Forms.Button();
            this.buttonInit = new System.Windows.Forms.Button();
            this.numericUpDownCommandTimeout = new System.Windows.Forms.NumericUpDown();
            this.labelCommandTimeout = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCommandTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCmdDir
            // 
            this.labelCmdDir.AutoSize = true;
            this.labelCmdDir.Location = new System.Drawing.Point(13, 13);
            this.labelCmdDir.Name = "labelCmdDir";
            this.labelCmdDir.Size = new System.Drawing.Size(102, 13);
            this.labelCmdDir.TabIndex = 10;
            this.labelCmdDir.Text = "Command Directory:";
            // 
            // labelResponseDir
            // 
            this.labelResponseDir.AutoSize = true;
            this.labelResponseDir.Location = new System.Drawing.Point(13, 54);
            this.labelResponseDir.Name = "labelResponseDir";
            this.labelResponseDir.Size = new System.Drawing.Size(103, 13);
            this.labelResponseDir.TabIndex = 10;
            this.labelResponseDir.Text = "Response Directory:";
            // 
            // textBoxCmdDir
            // 
            this.textBoxCmdDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCmdDir.Location = new System.Drawing.Point(16, 29);
            this.textBoxCmdDir.Name = "textBoxCmdDir";
            this.textBoxCmdDir.Size = new System.Drawing.Size(673, 20);
            this.textBoxCmdDir.TabIndex = 0;
            this.textBoxCmdDir.TextChanged += new System.EventHandler(this.textBoxCmdDir_TextChanged);
            // 
            // textBoxResponseDir
            // 
            this.textBoxResponseDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResponseDir.Location = new System.Drawing.Point(16, 70);
            this.textBoxResponseDir.Name = "textBoxResponseDir";
            this.textBoxResponseDir.Size = new System.Drawing.Size(672, 20);
            this.textBoxResponseDir.TabIndex = 1;
            this.textBoxResponseDir.TextChanged += new System.EventHandler(this.textBoxResponseDir_TextChanged);
            // 
            // buttonGetReactions
            // 
            this.buttonGetReactions.Location = new System.Drawing.Point(125, 204);
            this.buttonGetReactions.Name = "buttonGetReactions";
            this.buttonGetReactions.Size = new System.Drawing.Size(273, 23);
            this.buttonGetReactions.TabIndex = 3;
            this.buttonGetReactions.Text = "Get Reactions";
            this.buttonGetReactions.UseVisualStyleBackColor = true;
            this.buttonGetReactions.Click += new System.EventHandler(this.buttonGetReactions_Click);
            // 
            // labelReactions
            // 
            this.labelReactions.AutoSize = true;
            this.labelReactions.Location = new System.Drawing.Point(14, 219);
            this.labelReactions.Name = "labelReactions";
            this.labelReactions.Size = new System.Drawing.Size(104, 13);
            this.labelReactions.TabIndex = 10;
            this.labelReactions.Text = "Available Reactions:";
            // 
            // comboBoxReaction
            // 
            this.comboBoxReaction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxReaction.FormattingEnabled = true;
            this.comboBoxReaction.Location = new System.Drawing.Point(16, 235);
            this.comboBoxReaction.Name = "comboBoxReaction";
            this.comboBoxReaction.Size = new System.Drawing.Size(698, 21);
            this.comboBoxReaction.TabIndex = 4;
            this.comboBoxReaction.SelectedIndexChanged += new System.EventHandler(this.comboBoxReaction_SelectedIndexChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(124, 308);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(64, 64);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(334, 308);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(64, 64);
            this.buttonStop.TabIndex = 8;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(194, 308);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(64, 64);
            this.buttonPause.TabIndex = 6;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonResume
            // 
            this.buttonResume.Location = new System.Drawing.Point(264, 308);
            this.buttonResume.Name = "buttonResume";
            this.buttonResume.Size = new System.Drawing.Size(64, 64);
            this.buttonResume.TabIndex = 7;
            this.buttonResume.Text = "Resume";
            this.buttonResume.UseVisualStyleBackColor = true;
            this.buttonResume.Click += new System.EventHandler(this.buttonResume_Click);
            // 
            // textBoxResponse
            // 
            this.textBoxResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResponse.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxResponse.Location = new System.Drawing.Point(16, 382);
            this.textBoxResponse.Multiline = true;
            this.textBoxResponse.Name = "textBoxResponse";
            this.textBoxResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResponse.Size = new System.Drawing.Size(698, 114);
            this.textBoxResponse.TabIndex = 9;
            this.textBoxResponse.TextChanged += new System.EventHandler(this.textBoxResponse_TextChanged);
            // 
            // labelResponse
            // 
            this.labelResponse.AutoSize = true;
            this.labelResponse.Location = new System.Drawing.Point(14, 366);
            this.labelResponse.Name = "labelResponse";
            this.labelResponse.Size = new System.Drawing.Size(58, 13);
            this.labelResponse.TabIndex = 10;
            this.labelResponse.Text = "Response:";
            // 
            // labelTimeout
            // 
            this.labelTimeout.AutoSize = true;
            this.labelTimeout.Location = new System.Drawing.Point(13, 95);
            this.labelTimeout.Name = "labelTimeout";
            this.labelTimeout.Size = new System.Drawing.Size(145, 13);
            this.labelTimeout.TabIndex = 10;
            this.labelTimeout.Text = "Communication Timeout [ms]:";
            // 
            // numericUpDownTimeout
            // 
            this.numericUpDownTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownTimeout.Location = new System.Drawing.Point(16, 111);
            this.numericUpDownTimeout.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDownTimeout.Name = "numericUpDownTimeout";
            this.numericUpDownTimeout.Size = new System.Drawing.Size(698, 20);
            this.numericUpDownTimeout.TabIndex = 2;
            // 
            // buttonBrowseCommandDir
            // 
            this.buttonBrowseCommandDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseCommandDir.Location = new System.Drawing.Point(695, 29);
            this.buttonBrowseCommandDir.Name = "buttonBrowseCommandDir";
            this.buttonBrowseCommandDir.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowseCommandDir.TabIndex = 11;
            this.buttonBrowseCommandDir.Text = "...";
            this.buttonBrowseCommandDir.UseVisualStyleBackColor = true;
            this.buttonBrowseCommandDir.Click += new System.EventHandler(this.buttonBrowseCommandDir_Click);
            // 
            // buttonBrowseResponseDir
            // 
            this.buttonBrowseResponseDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseResponseDir.Location = new System.Drawing.Point(694, 70);
            this.buttonBrowseResponseDir.Name = "buttonBrowseResponseDir";
            this.buttonBrowseResponseDir.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowseResponseDir.TabIndex = 12;
            this.buttonBrowseResponseDir.Text = "...";
            this.buttonBrowseResponseDir.UseVisualStyleBackColor = true;
            this.buttonBrowseResponseDir.Click += new System.EventHandler(this.buttonBrowseResponseDir_Click);
            // 
            // buttonInit
            // 
            this.buttonInit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInit.Location = new System.Drawing.Point(17, 139);
            this.buttonInit.Name = "buttonInit";
            this.buttonInit.Size = new System.Drawing.Size(697, 23);
            this.buttonInit.TabIndex = 13;
            this.buttonInit.Text = "Initialize";
            this.buttonInit.UseVisualStyleBackColor = true;
            this.buttonInit.Click += new System.EventHandler(this.buttonInit_Click);
            // 
            // numericUpDownCommandTimeout
            // 
            this.numericUpDownCommandTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownCommandTimeout.Location = new System.Drawing.Point(16, 278);
            this.numericUpDownCommandTimeout.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownCommandTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDownCommandTimeout.Name = "numericUpDownCommandTimeout";
            this.numericUpDownCommandTimeout.Size = new System.Drawing.Size(698, 20);
            this.numericUpDownCommandTimeout.TabIndex = 14;
            // 
            // labelCommandTimeout
            // 
            this.labelCommandTimeout.AutoSize = true;
            this.labelCommandTimeout.Location = new System.Drawing.Point(13, 262);
            this.labelCommandTimeout.Name = "labelCommandTimeout";
            this.labelCommandTimeout.Size = new System.Drawing.Size(120, 13);
            this.labelCommandTimeout.TabIndex = 15;
            this.labelCommandTimeout.Text = "Command Timeout [ms]:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 508);
            this.Controls.Add(this.numericUpDownCommandTimeout);
            this.Controls.Add(this.labelCommandTimeout);
            this.Controls.Add(this.buttonInit);
            this.Controls.Add(this.buttonBrowseResponseDir);
            this.Controls.Add(this.buttonBrowseCommandDir);
            this.Controls.Add(this.numericUpDownTimeout);
            this.Controls.Add(this.labelTimeout);
            this.Controls.Add(this.labelResponse);
            this.Controls.Add(this.textBoxResponse);
            this.Controls.Add(this.buttonResume);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.comboBoxReaction);
            this.Controls.Add(this.labelReactions);
            this.Controls.Add(this.buttonGetReactions);
            this.Controls.Add(this.textBoxResponseDir);
            this.Controls.Add(this.textBoxCmdDir);
            this.Controls.Add(this.labelResponseDir);
            this.Controls.Add(this.labelCmdDir);
            this.MinimumSize = new System.Drawing.Size(425, 519);
            this.Name = "MainForm";
            this.Text = "Remote Control Reaction Monitoring";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCommandTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCmdDir;
        private System.Windows.Forms.Label labelResponseDir;
        private System.Windows.Forms.TextBox textBoxCmdDir;
        private System.Windows.Forms.TextBox textBoxResponseDir;
        private System.Windows.Forms.Button buttonGetReactions;
        private System.Windows.Forms.Label labelReactions;
        private System.Windows.Forms.ComboBox comboBoxReaction;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonResume;
        private System.Windows.Forms.TextBox textBoxResponse;
        private System.Windows.Forms.Label labelResponse;
        private System.Windows.Forms.Label labelTimeout;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeout;
        private System.Windows.Forms.Button buttonBrowseCommandDir;
        private System.Windows.Forms.Button buttonBrowseResponseDir;
        private System.Windows.Forms.Button buttonInit;
        private System.Windows.Forms.NumericUpDown numericUpDownCommandTimeout;
        private System.Windows.Forms.Label labelCommandTimeout;
    }
}

