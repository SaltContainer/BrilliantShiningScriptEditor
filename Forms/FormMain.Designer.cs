
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
            this.editorScript = new EasyScintilla.SimpleEditor();
            this.grpScriptFile = new System.Windows.Forms.GroupBox();
            this.grpScriptCommand = new System.Windows.Forms.GroupBox();
            this.checkScriptSafe = new System.Windows.Forms.CheckBox();
            this.lbScriptCommand = new System.Windows.Forms.Label();
            this.comboScriptCommand = new System.Windows.Forms.ComboBox();
            this.lbScriptCommandDescription = new System.Windows.Forms.Label();
            this.lbScriptCommandName = new System.Windows.Forms.Label();
            this.lbScript = new System.Windows.Forms.Label();
            this.comboScript = new System.Windows.Forms.ComboBox();
            this.comboScriptFile = new System.Windows.Forms.ComboBox();
            this.lbScriptFile = new System.Windows.Forms.Label();
            this.btnScriptAdd = new System.Windows.Forms.Button();
            this.btnScriptRemove = new System.Windows.Forms.Button();
            this.btnScriptCompile = new System.Windows.Forms.Button();
            this.btnScriptSave = new System.Windows.Forms.Button();
            this.tabText = new System.Windows.Forms.TabPage();
            this.stripMain.SuspendLayout();
            this.tabsMain.SuspendLayout();
            this.tabScript.SuspendLayout();
            this.grpScriptFile.SuspendLayout();
            this.grpScriptCommand.SuspendLayout();
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
            this.tbtnSave.Enabled = false;
            this.tbtnSave.Image = global::PokemonBDSPEditor.Properties.Resources.save;
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
            this.tabsMain.Location = new System.Drawing.Point(12, 42);
            this.tabsMain.Name = "tabsMain";
            this.tabsMain.SelectedIndex = 0;
            this.tabsMain.Size = new System.Drawing.Size(1084, 569);
            this.tabsMain.TabIndex = 1;
            // 
            // tabScript
            // 
            this.tabScript.Controls.Add(this.editorScript);
            this.tabScript.Controls.Add(this.grpScriptFile);
            this.tabScript.Location = new System.Drawing.Point(4, 22);
            this.tabScript.Name = "tabScript";
            this.tabScript.Padding = new System.Windows.Forms.Padding(3);
            this.tabScript.Size = new System.Drawing.Size(1076, 543);
            this.tabScript.TabIndex = 0;
            this.tabScript.Text = "Script Editor";
            this.tabScript.UseVisualStyleBackColor = true;
            // 
            // editorScript
            // 
            this.editorScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorScript.AutoCIgnoreCase = true;
            this.editorScript.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editorScript.Enabled = false;
            this.editorScript.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            this.editorScript.Location = new System.Drawing.Point(7, 7);
            this.editorScript.Name = "editorScript";
            this.editorScript.ScrollWidth = 700;
            this.editorScript.Size = new System.Drawing.Size(807, 530);
            this.editorScript.Styler = null;
            this.editorScript.TabIndex = 6;
            this.editorScript.UseTabs = true;
            // 
            // grpScriptFile
            // 
            this.grpScriptFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpScriptFile.Controls.Add(this.grpScriptCommand);
            this.grpScriptFile.Controls.Add(this.lbScript);
            this.grpScriptFile.Controls.Add(this.comboScript);
            this.grpScriptFile.Controls.Add(this.comboScriptFile);
            this.grpScriptFile.Controls.Add(this.lbScriptFile);
            this.grpScriptFile.Controls.Add(this.btnScriptAdd);
            this.grpScriptFile.Controls.Add(this.btnScriptRemove);
            this.grpScriptFile.Controls.Add(this.btnScriptCompile);
            this.grpScriptFile.Controls.Add(this.btnScriptSave);
            this.grpScriptFile.Location = new System.Drawing.Point(820, 6);
            this.grpScriptFile.Name = "grpScriptFile";
            this.grpScriptFile.Size = new System.Drawing.Size(250, 531);
            this.grpScriptFile.TabIndex = 5;
            this.grpScriptFile.TabStop = false;
            this.grpScriptFile.Text = "Script File Control";
            // 
            // grpScriptCommand
            // 
            this.grpScriptCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpScriptCommand.Controls.Add(this.checkScriptSafe);
            this.grpScriptCommand.Controls.Add(this.lbScriptCommand);
            this.grpScriptCommand.Controls.Add(this.comboScriptCommand);
            this.grpScriptCommand.Controls.Add(this.lbScriptCommandDescription);
            this.grpScriptCommand.Controls.Add(this.lbScriptCommandName);
            this.grpScriptCommand.Location = new System.Drawing.Point(9, 210);
            this.grpScriptCommand.Name = "grpScriptCommand";
            this.grpScriptCommand.Size = new System.Drawing.Size(235, 315);
            this.grpScriptCommand.TabIndex = 14;
            this.grpScriptCommand.TabStop = false;
            this.grpScriptCommand.Text = "Command Reference";
            // 
            // checkScriptSafe
            // 
            this.checkScriptSafe.AutoSize = true;
            this.checkScriptSafe.Checked = true;
            this.checkScriptSafe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkScriptSafe.Location = new System.Drawing.Point(151, 18);
            this.checkScriptSafe.Name = "checkScriptSafe";
            this.checkScriptSafe.Size = new System.Drawing.Size(78, 17);
            this.checkScriptSafe.TabIndex = 13;
            this.checkScriptSafe.Text = "Safe Mode";
            this.checkScriptSafe.UseVisualStyleBackColor = true;
            // 
            // lbScriptCommand
            // 
            this.lbScriptCommand.AutoSize = true;
            this.lbScriptCommand.Location = new System.Drawing.Point(6, 25);
            this.lbScriptCommand.Name = "lbScriptCommand";
            this.lbScriptCommand.Size = new System.Drawing.Size(54, 13);
            this.lbScriptCommand.TabIndex = 10;
            this.lbScriptCommand.Text = "Command";
            // 
            // comboScriptCommand
            // 
            this.comboScriptCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboScriptCommand.FormattingEnabled = true;
            this.comboScriptCommand.Location = new System.Drawing.Point(6, 41);
            this.comboScriptCommand.Name = "comboScriptCommand";
            this.comboScriptCommand.Size = new System.Drawing.Size(223, 21);
            this.comboScriptCommand.TabIndex = 9;
            this.comboScriptCommand.SelectedIndexChanged += new System.EventHandler(this.comboScriptCommand_SelectedIndexChanged);
            // 
            // lbScriptCommandDescription
            // 
            this.lbScriptCommandDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbScriptCommandDescription.Location = new System.Drawing.Point(6, 129);
            this.lbScriptCommandDescription.Name = "lbScriptCommandDescription";
            this.lbScriptCommandDescription.Size = new System.Drawing.Size(223, 183);
            this.lbScriptCommandDescription.TabIndex = 12;
            this.lbScriptCommandDescription.Text = "Script";
            // 
            // lbScriptCommandName
            // 
            this.lbScriptCommandName.AutoSize = true;
            this.lbScriptCommandName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbScriptCommandName.Location = new System.Drawing.Point(6, 65);
            this.lbScriptCommandName.MaximumSize = new System.Drawing.Size(223, 64);
            this.lbScriptCommandName.Name = "lbScriptCommandName";
            this.lbScriptCommandName.Size = new System.Drawing.Size(107, 18);
            this.lbScriptCommandName.TabIndex = 11;
            this.lbScriptCommandName.Text = "111 - _NAME";
            this.lbScriptCommandName.SizeChanged += new System.EventHandler(this.lbScriptCommandName_SizeChanged);
            // 
            // lbScript
            // 
            this.lbScript.AutoSize = true;
            this.lbScript.Location = new System.Drawing.Point(6, 68);
            this.lbScript.Name = "lbScript";
            this.lbScript.Size = new System.Drawing.Size(34, 13);
            this.lbScript.TabIndex = 7;
            this.lbScript.Text = "Script";
            // 
            // comboScript
            // 
            this.comboScript.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboScript.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboScript.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboScript.FormattingEnabled = true;
            this.comboScript.Location = new System.Drawing.Point(6, 84);
            this.comboScript.Name = "comboScript";
            this.comboScript.Size = new System.Drawing.Size(238, 21);
            this.comboScript.TabIndex = 6;
            this.comboScript.SelectedIndexChanged += new System.EventHandler(this.comboScript_SelectedIndexChanged);
            // 
            // comboScriptFile
            // 
            this.comboScriptFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboScriptFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboScriptFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboScriptFile.FormattingEnabled = true;
            this.comboScriptFile.Location = new System.Drawing.Point(6, 34);
            this.comboScriptFile.Name = "comboScriptFile";
            this.comboScriptFile.Size = new System.Drawing.Size(238, 21);
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
            // btnScriptAdd
            // 
            this.btnScriptAdd.Enabled = false;
            this.btnScriptAdd.Image = global::PokemonBDSPEditor.Properties.Resources.script_add;
            this.btnScriptAdd.Location = new System.Drawing.Point(6, 130);
            this.btnScriptAdd.Name = "btnScriptAdd";
            this.btnScriptAdd.Size = new System.Drawing.Size(55, 55);
            this.btnScriptAdd.TabIndex = 5;
            this.btnScriptAdd.UseVisualStyleBackColor = true;
            this.btnScriptAdd.Click += new System.EventHandler(this.btnScriptAdd_Click);
            // 
            // btnScriptRemove
            // 
            this.btnScriptRemove.Enabled = false;
            this.btnScriptRemove.Image = global::PokemonBDSPEditor.Properties.Resources.script_remove;
            this.btnScriptRemove.Location = new System.Drawing.Point(67, 130);
            this.btnScriptRemove.Name = "btnScriptRemove";
            this.btnScriptRemove.Size = new System.Drawing.Size(55, 55);
            this.btnScriptRemove.TabIndex = 8;
            this.btnScriptRemove.UseVisualStyleBackColor = true;
            this.btnScriptRemove.Click += new System.EventHandler(this.btnScriptRemove_Click);
            // 
            // btnScriptCompile
            // 
            this.btnScriptCompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScriptCompile.Enabled = false;
            this.btnScriptCompile.Image = global::PokemonBDSPEditor.Properties.Resources.script_compile;
            this.btnScriptCompile.Location = new System.Drawing.Point(128, 130);
            this.btnScriptCompile.Name = "btnScriptCompile";
            this.btnScriptCompile.Size = new System.Drawing.Size(55, 55);
            this.btnScriptCompile.TabIndex = 3;
            this.btnScriptCompile.UseVisualStyleBackColor = true;
            this.btnScriptCompile.Click += new System.EventHandler(this.btnScriptCompile_Click);
            // 
            // btnScriptSave
            // 
            this.btnScriptSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScriptSave.Enabled = false;
            this.btnScriptSave.Image = global::PokemonBDSPEditor.Properties.Resources.script_save;
            this.btnScriptSave.Location = new System.Drawing.Point(189, 130);
            this.btnScriptSave.Name = "btnScriptSave";
            this.btnScriptSave.Size = new System.Drawing.Size(55, 55);
            this.btnScriptSave.TabIndex = 4;
            this.btnScriptSave.UseVisualStyleBackColor = true;
            this.btnScriptSave.Click += new System.EventHandler(this.btnScriptSave_Click);
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
            this.grpScriptFile.ResumeLayout(false);
            this.grpScriptFile.PerformLayout();
            this.grpScriptCommand.ResumeLayout(false);
            this.grpScriptCommand.PerformLayout();
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
        private System.Windows.Forms.Button btnScriptSave;
        private System.Windows.Forms.Button btnScriptCompile;
        private System.Windows.Forms.Label lbScriptFile;
        private System.Windows.Forms.ComboBox comboScriptFile;
        private System.Windows.Forms.GroupBox grpScriptFile;
        private System.Windows.Forms.Button btnScriptAdd;
        private System.Windows.Forms.Label lbScript;
        private System.Windows.Forms.ComboBox comboScript;
        private System.Windows.Forms.Button btnScriptRemove;
        private System.Windows.Forms.GroupBox grpScriptCommand;
        private System.Windows.Forms.Label lbScriptCommand;
        private System.Windows.Forms.ComboBox comboScriptCommand;
        private System.Windows.Forms.Label lbScriptCommandDescription;
        private System.Windows.Forms.Label lbScriptCommandName;
        private System.Windows.Forms.CheckBox checkScriptSafe;
        private EasyScintilla.SimpleEditor editorScript;
    }
}

