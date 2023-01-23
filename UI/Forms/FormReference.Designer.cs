
namespace BrilliantShiningScriptEditor.UI.Forms
{
    partial class FormReference
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReference));
            this.tabsRef = new System.Windows.Forms.TabControl();
            this.tabCmd = new System.Windows.Forms.TabPage();
            this.lbCmdDescription = new System.Windows.Forms.Label();
            this.lbCmdName = new System.Windows.Forms.Label();
            this.comboCmdRef = new System.Windows.Forms.ComboBox();
            this.tabFlag = new System.Windows.Forms.TabPage();
            this.tabSys = new System.Windows.Forms.TabPage();
            this.tabWork = new System.Windows.Forms.TabPage();
            this.tabFiles = new System.Windows.Forms.TabPage();
            this.lbCmdLabel = new System.Windows.Forms.Label();
            this.tabsRef.SuspendLayout();
            this.tabCmd.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsRef
            // 
            this.tabsRef.Controls.Add(this.tabCmd);
            this.tabsRef.Controls.Add(this.tabFlag);
            this.tabsRef.Controls.Add(this.tabSys);
            this.tabsRef.Controls.Add(this.tabWork);
            this.tabsRef.Controls.Add(this.tabFiles);
            this.tabsRef.Location = new System.Drawing.Point(12, 12);
            this.tabsRef.Name = "tabsRef";
            this.tabsRef.SelectedIndex = 0;
            this.tabsRef.Size = new System.Drawing.Size(549, 426);
            this.tabsRef.TabIndex = 0;
            // 
            // tabCmd
            // 
            this.tabCmd.Controls.Add(this.lbCmdLabel);
            this.tabCmd.Controls.Add(this.lbCmdDescription);
            this.tabCmd.Controls.Add(this.lbCmdName);
            this.tabCmd.Controls.Add(this.comboCmdRef);
            this.tabCmd.Location = new System.Drawing.Point(4, 22);
            this.tabCmd.Name = "tabCmd";
            this.tabCmd.Padding = new System.Windows.Forms.Padding(3);
            this.tabCmd.Size = new System.Drawing.Size(541, 400);
            this.tabCmd.TabIndex = 0;
            this.tabCmd.Text = "Commands";
            this.tabCmd.UseVisualStyleBackColor = true;
            // 
            // lbCmdDescription
            // 
            this.lbCmdDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCmdDescription.Location = new System.Drawing.Point(6, 82);
            this.lbCmdDescription.Name = "lbCmdDescription";
            this.lbCmdDescription.Size = new System.Drawing.Size(532, 315);
            this.lbCmdDescription.TabIndex = 13;
            this.lbCmdDescription.Text = "Script";
            // 
            // lbCmdName
            // 
            this.lbCmdName.AutoSize = true;
            this.lbCmdName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCmdName.Location = new System.Drawing.Point(6, 11);
            this.lbCmdName.MaximumSize = new System.Drawing.Size(223, 64);
            this.lbCmdName.Name = "lbCmdName";
            this.lbCmdName.Size = new System.Drawing.Size(107, 18);
            this.lbCmdName.TabIndex = 12;
            this.lbCmdName.Text = "111 - _NAME";
            // 
            // comboCmdRef
            // 
            this.comboCmdRef.FormattingEnabled = true;
            this.comboCmdRef.Location = new System.Drawing.Point(314, 12);
            this.comboCmdRef.Name = "comboCmdRef";
            this.comboCmdRef.Size = new System.Drawing.Size(221, 21);
            this.comboCmdRef.TabIndex = 0;
            this.comboCmdRef.SelectedIndexChanged += new System.EventHandler(this.comboCmdRef_SelectedIndexChanged);
            // 
            // tabFlag
            // 
            this.tabFlag.Location = new System.Drawing.Point(4, 22);
            this.tabFlag.Name = "tabFlag";
            this.tabFlag.Padding = new System.Windows.Forms.Padding(3);
            this.tabFlag.Size = new System.Drawing.Size(541, 400);
            this.tabFlag.TabIndex = 1;
            this.tabFlag.Text = "Flags";
            this.tabFlag.UseVisualStyleBackColor = true;
            // 
            // tabSys
            // 
            this.tabSys.Location = new System.Drawing.Point(4, 22);
            this.tabSys.Name = "tabSys";
            this.tabSys.Size = new System.Drawing.Size(541, 400);
            this.tabSys.TabIndex = 2;
            this.tabSys.Text = "System Flags";
            this.tabSys.UseVisualStyleBackColor = true;
            // 
            // tabWork
            // 
            this.tabWork.Location = new System.Drawing.Point(4, 22);
            this.tabWork.Name = "tabWork";
            this.tabWork.Size = new System.Drawing.Size(541, 400);
            this.tabWork.TabIndex = 3;
            this.tabWork.Text = "Work Variables";
            this.tabWork.UseVisualStyleBackColor = true;
            // 
            // tabFiles
            // 
            this.tabFiles.Location = new System.Drawing.Point(4, 22);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.Size = new System.Drawing.Size(541, 400);
            this.tabFiles.TabIndex = 4;
            this.tabFiles.Text = "Script Files";
            this.tabFiles.UseVisualStyleBackColor = true;
            // 
            // lbCmdLabel
            // 
            this.lbCmdLabel.AutoSize = true;
            this.lbCmdLabel.Location = new System.Drawing.Point(251, 15);
            this.lbCmdLabel.Name = "lbCmdLabel";
            this.lbCmdLabel.Size = new System.Drawing.Size(57, 13);
            this.lbCmdLabel.TabIndex = 14;
            this.lbCmdLabel.Text = "Command:";
            // 
            // FormReference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 450);
            this.Controls.Add(this.tabsRef);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormReference";
            this.Text = "Data Reference";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormReference_FormClosing);
            this.tabsRef.ResumeLayout(false);
            this.tabCmd.ResumeLayout(false);
            this.tabCmd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabsRef;
        private System.Windows.Forms.TabPage tabCmd;
        private System.Windows.Forms.TabPage tabFlag;
        private System.Windows.Forms.ComboBox comboCmdRef;
        private System.Windows.Forms.Label lbCmdName;
        private System.Windows.Forms.Label lbCmdDescription;
        private System.Windows.Forms.TabPage tabSys;
        private System.Windows.Forms.TabPage tabWork;
        private System.Windows.Forms.TabPage tabFiles;
        private System.Windows.Forms.Label lbCmdLabel;
    }
}