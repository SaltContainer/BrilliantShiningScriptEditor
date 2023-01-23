
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
            this.lbCmdLabel = new System.Windows.Forms.Label();
            this.lbCmdDescription = new System.Windows.Forms.Label();
            this.lbCmdName = new System.Windows.Forms.Label();
            this.comboCmdRef = new System.Windows.Forms.ComboBox();
            this.tabFlag = new System.Windows.Forms.TabPage();
            this.tabSys = new System.Windows.Forms.TabPage();
            this.tabWork = new System.Windows.Forms.TabPage();
            this.tabFiles = new System.Windows.Forms.TabPage();
            this.lbFlagName = new System.Windows.Forms.Label();
            this.lbSysName = new System.Windows.Forms.Label();
            this.lbWorkName = new System.Windows.Forms.Label();
            this.lbFileName = new System.Windows.Forms.Label();
            this.lbFlagLabel = new System.Windows.Forms.Label();
            this.lbSysLabel = new System.Windows.Forms.Label();
            this.lbWorkLabel = new System.Windows.Forms.Label();
            this.lbFileLabel = new System.Windows.Forms.Label();
            this.comboFlagRef = new System.Windows.Forms.ComboBox();
            this.comboSysRef = new System.Windows.Forms.ComboBox();
            this.comboWorkRef = new System.Windows.Forms.ComboBox();
            this.comboFileRef = new System.Windows.Forms.ComboBox();
            this.lbFlagDescription = new System.Windows.Forms.Label();
            this.lbSysDescription = new System.Windows.Forms.Label();
            this.lbWorkDescription = new System.Windows.Forms.Label();
            this.lbFileDescription = new System.Windows.Forms.Label();
            this.tabsRef.SuspendLayout();
            this.tabCmd.SuspendLayout();
            this.tabFlag.SuspendLayout();
            this.tabSys.SuspendLayout();
            this.tabWork.SuspendLayout();
            this.tabFiles.SuspendLayout();
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
            this.tabCmd.Controls.Add(this.lbCmdDescription);
            this.tabCmd.Controls.Add(this.comboCmdRef);
            this.tabCmd.Controls.Add(this.lbCmdLabel);
            this.tabCmd.Controls.Add(this.lbCmdName);
            this.tabCmd.Location = new System.Drawing.Point(4, 22);
            this.tabCmd.Name = "tabCmd";
            this.tabCmd.Padding = new System.Windows.Forms.Padding(3);
            this.tabCmd.Size = new System.Drawing.Size(541, 400);
            this.tabCmd.TabIndex = 0;
            this.tabCmd.Text = "Commands";
            this.tabCmd.UseVisualStyleBackColor = true;
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
            // lbCmdDescription
            // 
            this.lbCmdDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCmdDescription.Location = new System.Drawing.Point(9, 85);
            this.lbCmdDescription.Name = "lbCmdDescription";
            this.lbCmdDescription.Size = new System.Drawing.Size(526, 315);
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
            this.tabFlag.Controls.Add(this.lbFlagDescription);
            this.tabFlag.Controls.Add(this.comboFlagRef);
            this.tabFlag.Controls.Add(this.lbFlagLabel);
            this.tabFlag.Controls.Add(this.lbFlagName);
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
            this.tabSys.Controls.Add(this.lbSysDescription);
            this.tabSys.Controls.Add(this.comboSysRef);
            this.tabSys.Controls.Add(this.lbSysLabel);
            this.tabSys.Controls.Add(this.lbSysName);
            this.tabSys.Location = new System.Drawing.Point(4, 22);
            this.tabSys.Name = "tabSys";
            this.tabSys.Size = new System.Drawing.Size(541, 400);
            this.tabSys.TabIndex = 2;
            this.tabSys.Text = "System Flags";
            this.tabSys.UseVisualStyleBackColor = true;
            // 
            // tabWork
            // 
            this.tabWork.Controls.Add(this.lbWorkDescription);
            this.tabWork.Controls.Add(this.comboWorkRef);
            this.tabWork.Controls.Add(this.lbWorkLabel);
            this.tabWork.Controls.Add(this.lbWorkName);
            this.tabWork.Location = new System.Drawing.Point(4, 22);
            this.tabWork.Name = "tabWork";
            this.tabWork.Size = new System.Drawing.Size(541, 400);
            this.tabWork.TabIndex = 3;
            this.tabWork.Text = "Work Variables";
            this.tabWork.UseVisualStyleBackColor = true;
            // 
            // tabFiles
            // 
            this.tabFiles.Controls.Add(this.lbFileDescription);
            this.tabFiles.Controls.Add(this.comboFileRef);
            this.tabFiles.Controls.Add(this.lbFileLabel);
            this.tabFiles.Controls.Add(this.lbFileName);
            this.tabFiles.Location = new System.Drawing.Point(4, 22);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.Size = new System.Drawing.Size(541, 400);
            this.tabFiles.TabIndex = 4;
            this.tabFiles.Text = "Script Files";
            this.tabFiles.UseVisualStyleBackColor = true;
            // 
            // lbFlagName
            // 
            this.lbFlagName.AutoSize = true;
            this.lbFlagName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFlagName.Location = new System.Drawing.Point(6, 11);
            this.lbFlagName.MaximumSize = new System.Drawing.Size(223, 64);
            this.lbFlagName.Name = "lbFlagName";
            this.lbFlagName.Size = new System.Drawing.Size(107, 18);
            this.lbFlagName.TabIndex = 13;
            this.lbFlagName.Text = "111 - _NAME";
            // 
            // lbSysName
            // 
            this.lbSysName.AutoSize = true;
            this.lbSysName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSysName.Location = new System.Drawing.Point(6, 11);
            this.lbSysName.MaximumSize = new System.Drawing.Size(223, 64);
            this.lbSysName.Name = "lbSysName";
            this.lbSysName.Size = new System.Drawing.Size(107, 18);
            this.lbSysName.TabIndex = 13;
            this.lbSysName.Text = "111 - _NAME";
            // 
            // lbWorkName
            // 
            this.lbWorkName.AutoSize = true;
            this.lbWorkName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWorkName.Location = new System.Drawing.Point(6, 11);
            this.lbWorkName.MaximumSize = new System.Drawing.Size(223, 64);
            this.lbWorkName.Name = "lbWorkName";
            this.lbWorkName.Size = new System.Drawing.Size(107, 18);
            this.lbWorkName.TabIndex = 13;
            this.lbWorkName.Text = "111 - _NAME";
            // 
            // lbFileName
            // 
            this.lbFileName.AutoSize = true;
            this.lbFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFileName.Location = new System.Drawing.Point(6, 11);
            this.lbFileName.MaximumSize = new System.Drawing.Size(223, 64);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Size = new System.Drawing.Size(107, 18);
            this.lbFileName.TabIndex = 13;
            this.lbFileName.Text = "111 - _NAME";
            // 
            // lbFlagLabel
            // 
            this.lbFlagLabel.AutoSize = true;
            this.lbFlagLabel.Location = new System.Drawing.Point(278, 15);
            this.lbFlagLabel.Name = "lbFlagLabel";
            this.lbFlagLabel.Size = new System.Drawing.Size(30, 13);
            this.lbFlagLabel.TabIndex = 15;
            this.lbFlagLabel.Text = "Flag:";
            // 
            // lbSysLabel
            // 
            this.lbSysLabel.AutoSize = true;
            this.lbSysLabel.Location = new System.Drawing.Point(241, 15);
            this.lbSysLabel.Name = "lbSysLabel";
            this.lbSysLabel.Size = new System.Drawing.Size(67, 13);
            this.lbSysLabel.TabIndex = 15;
            this.lbSysLabel.Text = "System Flag:";
            // 
            // lbWorkLabel
            // 
            this.lbWorkLabel.AutoSize = true;
            this.lbWorkLabel.Location = new System.Drawing.Point(231, 15);
            this.lbWorkLabel.Name = "lbWorkLabel";
            this.lbWorkLabel.Size = new System.Drawing.Size(77, 13);
            this.lbWorkLabel.TabIndex = 15;
            this.lbWorkLabel.Text = "Work Variable:";
            // 
            // lbFileLabel
            // 
            this.lbFileLabel.AutoSize = true;
            this.lbFileLabel.Location = new System.Drawing.Point(252, 15);
            this.lbFileLabel.Name = "lbFileLabel";
            this.lbFileLabel.Size = new System.Drawing.Size(56, 13);
            this.lbFileLabel.TabIndex = 15;
            this.lbFileLabel.Text = "Script File:";
            // 
            // comboFlagRef
            // 
            this.comboFlagRef.FormattingEnabled = true;
            this.comboFlagRef.Location = new System.Drawing.Point(314, 12);
            this.comboFlagRef.Name = "comboFlagRef";
            this.comboFlagRef.Size = new System.Drawing.Size(221, 21);
            this.comboFlagRef.TabIndex = 16;
            this.comboFlagRef.SelectedIndexChanged += new System.EventHandler(this.comboFlagRef_SelectedIndexChanged);
            // 
            // comboSysRef
            // 
            this.comboSysRef.FormattingEnabled = true;
            this.comboSysRef.Location = new System.Drawing.Point(314, 12);
            this.comboSysRef.Name = "comboSysRef";
            this.comboSysRef.Size = new System.Drawing.Size(221, 21);
            this.comboSysRef.TabIndex = 16;
            this.comboSysRef.SelectedIndexChanged += new System.EventHandler(this.comboSysRef_SelectedIndexChanged);
            // 
            // comboWorkRef
            // 
            this.comboWorkRef.FormattingEnabled = true;
            this.comboWorkRef.Location = new System.Drawing.Point(314, 12);
            this.comboWorkRef.Name = "comboWorkRef";
            this.comboWorkRef.Size = new System.Drawing.Size(221, 21);
            this.comboWorkRef.TabIndex = 16;
            this.comboWorkRef.SelectedIndexChanged += new System.EventHandler(this.comboWorkRef_SelectedIndexChanged);
            // 
            // comboFileRef
            // 
            this.comboFileRef.FormattingEnabled = true;
            this.comboFileRef.Location = new System.Drawing.Point(314, 12);
            this.comboFileRef.Name = "comboFileRef";
            this.comboFileRef.Size = new System.Drawing.Size(221, 21);
            this.comboFileRef.TabIndex = 16;
            this.comboFileRef.SelectedIndexChanged += new System.EventHandler(this.comboFileRef_SelectedIndexChanged);
            // 
            // lbFlagDescription
            // 
            this.lbFlagDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFlagDescription.Location = new System.Drawing.Point(9, 85);
            this.lbFlagDescription.Name = "lbFlagDescription";
            this.lbFlagDescription.Size = new System.Drawing.Size(526, 315);
            this.lbFlagDescription.TabIndex = 17;
            this.lbFlagDescription.Text = "Script";
            // 
            // lbSysDescription
            // 
            this.lbSysDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSysDescription.Location = new System.Drawing.Point(9, 85);
            this.lbSysDescription.Name = "lbSysDescription";
            this.lbSysDescription.Size = new System.Drawing.Size(526, 315);
            this.lbSysDescription.TabIndex = 17;
            this.lbSysDescription.Text = "Script";
            // 
            // lbWorkDescription
            // 
            this.lbWorkDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbWorkDescription.Location = new System.Drawing.Point(9, 85);
            this.lbWorkDescription.Name = "lbWorkDescription";
            this.lbWorkDescription.Size = new System.Drawing.Size(526, 315);
            this.lbWorkDescription.TabIndex = 17;
            this.lbWorkDescription.Text = "Script";
            // 
            // lbFileDescription
            // 
            this.lbFileDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFileDescription.Location = new System.Drawing.Point(9, 85);
            this.lbFileDescription.Name = "lbFileDescription";
            this.lbFileDescription.Size = new System.Drawing.Size(526, 315);
            this.lbFileDescription.TabIndex = 17;
            this.lbFileDescription.Text = "Script";
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
            this.tabFlag.ResumeLayout(false);
            this.tabFlag.PerformLayout();
            this.tabSys.ResumeLayout(false);
            this.tabSys.PerformLayout();
            this.tabWork.ResumeLayout(false);
            this.tabWork.PerformLayout();
            this.tabFiles.ResumeLayout(false);
            this.tabFiles.PerformLayout();
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
        private System.Windows.Forms.Label lbFlagDescription;
        private System.Windows.Forms.ComboBox comboFlagRef;
        private System.Windows.Forms.Label lbFlagLabel;
        private System.Windows.Forms.Label lbFlagName;
        private System.Windows.Forms.Label lbSysDescription;
        private System.Windows.Forms.ComboBox comboSysRef;
        private System.Windows.Forms.Label lbSysLabel;
        private System.Windows.Forms.Label lbSysName;
        private System.Windows.Forms.Label lbWorkDescription;
        private System.Windows.Forms.ComboBox comboWorkRef;
        private System.Windows.Forms.Label lbWorkLabel;
        private System.Windows.Forms.Label lbWorkName;
        private System.Windows.Forms.Label lbFileDescription;
        private System.Windows.Forms.ComboBox comboFileRef;
        private System.Windows.Forms.Label lbFileLabel;
        private System.Windows.Forms.Label lbFileName;
    }
}