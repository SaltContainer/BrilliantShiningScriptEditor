
namespace PokemonBDSPEditor.Forms
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.stripMain = new System.Windows.Forms.ToolStrip();
            this.tbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.tbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tabsMain = new System.Windows.Forms.TabControl();
            this.tabScript = new System.Windows.Forms.TabPage();
            this.grpScriptCommands = new System.Windows.Forms.GroupBox();
            this.dataScriptCommands = new System.Windows.Forms.DataGridView();
            this.grpScriptFile = new System.Windows.Forms.GroupBox();
            this.lbScript = new System.Windows.Forms.Label();
            this.comboScript = new System.Windows.Forms.ComboBox();
            this.btnScriptAdd = new System.Windows.Forms.Button();
            this.comboScriptFile = new System.Windows.Forms.ComboBox();
            this.lbScriptFile = new System.Windows.Forms.Label();
            this.btnScriptSave = new System.Windows.Forms.Button();
            this.btnScriptCompile = new System.Windows.Forms.Button();
            this.rtbScript = new System.Windows.Forms.RichTextBox();
            this.tabText = new System.Windows.Forms.TabPage();
            this.tabTrainer = new System.Windows.Forms.TabPage();
            this.stripMain.SuspendLayout();
            this.tabsMain.SuspendLayout();
            this.tabScript.SuspendLayout();
            this.grpScriptCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataScriptCommands)).BeginInit();
            this.grpScriptFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // stripMain
            // 
            this.stripMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.stripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnOpen,
            this.tbtnSave});
            this.stripMain.Location = new System.Drawing.Point(0, 0);
            this.stripMain.Name = "stripMain";
            this.stripMain.Size = new System.Drawing.Size(1108, 39);
            this.stripMain.TabIndex = 0;
            this.stripMain.Text = "toolStrip1";
            // 
            // tbtnOpen
            // 
            this.tbtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnOpen.Image = global::PokemonBDSPEditor.Properties.Resources.folder;
            this.tbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnOpen.Name = "tbtnOpen";
            this.tbtnOpen.Size = new System.Drawing.Size(36, 36);
            this.tbtnOpen.Text = "Open RomFS Folder";
            this.tbtnOpen.Click += new System.EventHandler(this.tbtnOpen_Click);
            // 
            // tbtnSave
            // 
            this.tbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnSave.Image = global::PokemonBDSPEditor.Properties.Resources.folder;
            this.tbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnSave.Name = "tbtnSave";
            this.tbtnSave.Size = new System.Drawing.Size(36, 36);
            this.tbtnSave.Text = "Export Changes";
            this.tbtnSave.Click += new System.EventHandler(this.tbtnSave_Click);
            // 
            // tabsMain
            // 
            this.tabsMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabsMain.Controls.Add(this.tabScript);
            this.tabsMain.Controls.Add(this.tabText);
            this.tabsMain.Controls.Add(this.tabTrainer);
            this.tabsMain.Location = new System.Drawing.Point(12, 42);
            this.tabsMain.Name = "tabsMain";
            this.tabsMain.SelectedIndex = 0;
            this.tabsMain.Size = new System.Drawing.Size(1084, 569);
            this.tabsMain.TabIndex = 1;
            // 
            // tabScript
            // 
            this.tabScript.Controls.Add(this.grpScriptCommands);
            this.tabScript.Controls.Add(this.grpScriptFile);
            this.tabScript.Controls.Add(this.rtbScript);
            this.tabScript.Location = new System.Drawing.Point(4, 22);
            this.tabScript.Name = "tabScript";
            this.tabScript.Padding = new System.Windows.Forms.Padding(3);
            this.tabScript.Size = new System.Drawing.Size(1076, 543);
            this.tabScript.TabIndex = 0;
            this.tabScript.Text = "Script Editor";
            this.tabScript.UseVisualStyleBackColor = true;
            // 
            // grpScriptCommands
            // 
            this.grpScriptCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpScriptCommands.Controls.Add(this.dataScriptCommands);
            this.grpScriptCommands.Location = new System.Drawing.Point(6, 117);
            this.grpScriptCommands.Name = "grpScriptCommands";
            this.grpScriptCommands.Size = new System.Drawing.Size(547, 420);
            this.grpScriptCommands.TabIndex = 6;
            this.grpScriptCommands.TabStop = false;
            this.grpScriptCommands.Text = "Commands";
            // 
            // dataScriptCommands
            // 
            this.dataScriptCommands.AllowUserToAddRows = false;
            this.dataScriptCommands.AllowUserToDeleteRows = false;
            this.dataScriptCommands.AllowUserToOrderColumns = true;
            this.dataScriptCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataScriptCommands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataScriptCommands.Location = new System.Drawing.Point(6, 19);
            this.dataScriptCommands.Name = "dataScriptCommands";
            this.dataScriptCommands.ReadOnly = true;
            this.dataScriptCommands.Size = new System.Drawing.Size(535, 395);
            this.dataScriptCommands.TabIndex = 0;
            // 
            // grpScriptFile
            // 
            this.grpScriptFile.Controls.Add(this.lbScript);
            this.grpScriptFile.Controls.Add(this.comboScript);
            this.grpScriptFile.Controls.Add(this.btnScriptAdd);
            this.grpScriptFile.Controls.Add(this.comboScriptFile);
            this.grpScriptFile.Controls.Add(this.lbScriptFile);
            this.grpScriptFile.Controls.Add(this.btnScriptSave);
            this.grpScriptFile.Controls.Add(this.btnScriptCompile);
            this.grpScriptFile.Location = new System.Drawing.Point(6, 6);
            this.grpScriptFile.Name = "grpScriptFile";
            this.grpScriptFile.Size = new System.Drawing.Size(547, 105);
            this.grpScriptFile.TabIndex = 5;
            this.grpScriptFile.TabStop = false;
            this.grpScriptFile.Text = "Script File Control";
            // 
            // lbScript
            // 
            this.lbScript.AutoSize = true;
            this.lbScript.Location = new System.Drawing.Point(6, 59);
            this.lbScript.Name = "lbScript";
            this.lbScript.Size = new System.Drawing.Size(34, 13);
            this.lbScript.TabIndex = 7;
            this.lbScript.Text = "Script";
            // 
            // comboScript
            // 
            this.comboScript.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboScript.FormattingEnabled = true;
            this.comboScript.Location = new System.Drawing.Point(9, 75);
            this.comboScript.Name = "comboScript";
            this.comboScript.Size = new System.Drawing.Size(349, 21);
            this.comboScript.TabIndex = 6;
            // 
            // btnScriptAdd
            // 
            this.btnScriptAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScriptAdd.Image = global::PokemonBDSPEditor.Properties.Resources.folder;
            this.btnScriptAdd.Location = new System.Drawing.Point(364, 41);
            this.btnScriptAdd.Name = "btnScriptAdd";
            this.btnScriptAdd.Size = new System.Drawing.Size(55, 55);
            this.btnScriptAdd.TabIndex = 5;
            this.btnScriptAdd.Text = "add";
            this.btnScriptAdd.UseVisualStyleBackColor = true;
            this.btnScriptAdd.Click += new System.EventHandler(this.btnScriptAdd_Click);
            // 
            // comboScriptFile
            // 
            this.comboScriptFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboScriptFile.FormattingEnabled = true;
            this.comboScriptFile.Location = new System.Drawing.Point(9, 34);
            this.comboScriptFile.Name = "comboScriptFile";
            this.comboScriptFile.Size = new System.Drawing.Size(349, 21);
            this.comboScriptFile.TabIndex = 1;
            this.comboScriptFile.SelectedIndexChanged += new System.EventHandler(this.comboScriptFile_SelectedIndexChanged);
            // 
            // lbScriptFile
            // 
            this.lbScriptFile.AutoSize = true;
            this.lbScriptFile.Location = new System.Drawing.Point(6, 18);
            this.lbScriptFile.Name = "lbScriptFile";
            this.lbScriptFile.Size = new System.Drawing.Size(53, 13);
            this.lbScriptFile.TabIndex = 2;
            this.lbScriptFile.Text = "Script File";
            // 
            // btnScriptSave
            // 
            this.btnScriptSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScriptSave.Image = global::PokemonBDSPEditor.Properties.Resources.folder;
            this.btnScriptSave.Location = new System.Drawing.Point(486, 41);
            this.btnScriptSave.Name = "btnScriptSave";
            this.btnScriptSave.Size = new System.Drawing.Size(55, 55);
            this.btnScriptSave.TabIndex = 4;
            this.btnScriptSave.Text = "save";
            this.btnScriptSave.UseVisualStyleBackColor = true;
            this.btnScriptSave.Click += new System.EventHandler(this.btnScriptSave_Click);
            // 
            // btnScriptCompile
            // 
            this.btnScriptCompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScriptCompile.Image = global::PokemonBDSPEditor.Properties.Resources.folder;
            this.btnScriptCompile.Location = new System.Drawing.Point(425, 41);
            this.btnScriptCompile.Name = "btnScriptCompile";
            this.btnScriptCompile.Size = new System.Drawing.Size(55, 55);
            this.btnScriptCompile.TabIndex = 3;
            this.btnScriptCompile.Text = "compile";
            this.btnScriptCompile.UseVisualStyleBackColor = true;
            this.btnScriptCompile.Click += new System.EventHandler(this.btnScriptCompile_Click);
            // 
            // rtbScript
            // 
            this.rtbScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbScript.Location = new System.Drawing.Point(559, 6);
            this.rtbScript.Name = "rtbScript";
            this.rtbScript.Size = new System.Drawing.Size(511, 531);
            this.rtbScript.TabIndex = 0;
            this.rtbScript.Text = "";
            // 
            // tabText
            // 
            this.tabText.Location = new System.Drawing.Point(4, 22);
            this.tabText.Name = "tabText";
            this.tabText.Padding = new System.Windows.Forms.Padding(3);
            this.tabText.Size = new System.Drawing.Size(1076, 543);
            this.tabText.TabIndex = 1;
            this.tabText.Text = "Text Editor";
            this.tabText.UseVisualStyleBackColor = true;
            // 
            // tabTrainer
            // 
            this.tabTrainer.Location = new System.Drawing.Point(4, 22);
            this.tabTrainer.Name = "tabTrainer";
            this.tabTrainer.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrainer.Size = new System.Drawing.Size(1076, 543);
            this.tabTrainer.TabIndex = 2;
            this.tabTrainer.Text = "Trainer Editor";
            this.tabTrainer.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 623);
            this.Controls.Add(this.tabsMain);
            this.Controls.Add(this.stripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1124, 662);
            this.Name = "FormMain";
            this.Text = "Pokémon BDSP Editor";
            this.stripMain.ResumeLayout(false);
            this.stripMain.PerformLayout();
            this.tabsMain.ResumeLayout(false);
            this.tabScript.ResumeLayout(false);
            this.grpScriptCommands.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataScriptCommands)).EndInit();
            this.grpScriptFile.ResumeLayout(false);
            this.grpScriptFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip stripMain;
        private System.Windows.Forms.ToolStripButton tbtnOpen;
        private System.Windows.Forms.ToolStripButton tbtnSave;
        private System.Windows.Forms.TabControl tabsMain;
        private System.Windows.Forms.TabPage tabScript;
        private System.Windows.Forms.TabPage tabText;
        private System.Windows.Forms.TabPage tabTrainer;
        private System.Windows.Forms.Button btnScriptSave;
        private System.Windows.Forms.Button btnScriptCompile;
        private System.Windows.Forms.Label lbScriptFile;
        private System.Windows.Forms.ComboBox comboScriptFile;
        private System.Windows.Forms.RichTextBox rtbScript;
        private System.Windows.Forms.GroupBox grpScriptCommands;
        private System.Windows.Forms.DataGridView dataScriptCommands;
        private System.Windows.Forms.GroupBox grpScriptFile;
        private System.Windows.Forms.Button btnScriptAdd;
        private System.Windows.Forms.Label lbScript;
        private System.Windows.Forms.ComboBox comboScript;
    }
}

