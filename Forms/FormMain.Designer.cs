
namespace BrilliantShiningScriptEditor.Forms
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.stripMain = new System.Windows.Forms.ToolStrip();
            this.tbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.tbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsepFirst = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnReference = new System.Windows.Forms.ToolStripButton();
            this.webEditor = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.grpScriptFile = new System.Windows.Forms.GroupBox();
            this.checkScriptSafe = new System.Windows.Forms.CheckBox();
            this.lbScript = new System.Windows.Forms.Label();
            this.comboScript = new System.Windows.Forms.ComboBox();
            this.comboScriptFile = new System.Windows.Forms.ComboBox();
            this.lbScriptFile = new System.Windows.Forms.Label();
            this.btnScriptAdd = new System.Windows.Forms.Button();
            this.btnScriptRemove = new System.Windows.Forms.Button();
            this.btnScriptCompile = new System.Windows.Forms.Button();
            this.btnScriptSave = new System.Windows.Forms.Button();
            this.ttFormMain = new System.Windows.Forms.ToolTip(this.components);
            this.stripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webEditor)).BeginInit();
            this.grpScriptFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // stripMain
            // 
            this.stripMain.Enabled = false;
            this.stripMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.stripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnOpen,
            this.tbtnSave,
            this.tsepFirst,
            this.tbtnReference});
            this.stripMain.Location = new System.Drawing.Point(0, 0);
            this.stripMain.Name = "stripMain";
            this.stripMain.Size = new System.Drawing.Size(1108, 39);
            this.stripMain.TabIndex = 0;
            this.stripMain.Text = "toolStrip1";
            // 
            // tbtnOpen
            // 
            this.tbtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnOpen.Image = global::BrilliantShiningScriptEditor.Properties.Resources.folder;
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
            this.tbtnSave.Image = global::BrilliantShiningScriptEditor.Properties.Resources.save;
            this.tbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnSave.Name = "tbtnSave";
            this.tbtnSave.Size = new System.Drawing.Size(36, 36);
            this.tbtnSave.Text = "Export Changes";
            this.tbtnSave.Click += new System.EventHandler(this.tbtnSave_Click);
            // 
            // tsepFirst
            // 
            this.tsepFirst.Name = "tsepFirst";
            this.tsepFirst.Size = new System.Drawing.Size(6, 39);
            // 
            // tbtnReference
            // 
            this.tbtnReference.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnReference.Image = global::BrilliantShiningScriptEditor.Properties.Resources.info;
            this.tbtnReference.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnReference.Name = "tbtnReference";
            this.tbtnReference.Size = new System.Drawing.Size(36, 36);
            this.tbtnReference.Text = "tbtnReference";
            this.tbtnReference.Click += new System.EventHandler(this.tbtnReference_Click);
            // 
            // webEditor
            // 
            this.webEditor.AllowExternalDrop = true;
            this.webEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webEditor.CreationProperties = null;
            this.webEditor.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webEditor.Location = new System.Drawing.Point(12, 42);
            this.webEditor.Name = "webEditor";
            this.webEditor.Size = new System.Drawing.Size(828, 569);
            this.webEditor.TabIndex = 7;
            this.webEditor.ZoomFactor = 1D;
            this.webEditor.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.webEditor_NavigationCompleted);
            // 
            // grpScriptFile
            // 
            this.grpScriptFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpScriptFile.Controls.Add(this.checkScriptSafe);
            this.grpScriptFile.Controls.Add(this.lbScript);
            this.grpScriptFile.Controls.Add(this.comboScript);
            this.grpScriptFile.Controls.Add(this.comboScriptFile);
            this.grpScriptFile.Controls.Add(this.lbScriptFile);
            this.grpScriptFile.Controls.Add(this.btnScriptAdd);
            this.grpScriptFile.Controls.Add(this.btnScriptRemove);
            this.grpScriptFile.Controls.Add(this.btnScriptCompile);
            this.grpScriptFile.Controls.Add(this.btnScriptSave);
            this.grpScriptFile.Location = new System.Drawing.Point(846, 42);
            this.grpScriptFile.Name = "grpScriptFile";
            this.grpScriptFile.Size = new System.Drawing.Size(250, 569);
            this.grpScriptFile.TabIndex = 5;
            this.grpScriptFile.TabStop = false;
            this.grpScriptFile.Text = "Script File Control";
            // 
            // checkScriptSafe
            // 
            this.checkScriptSafe.AutoSize = true;
            this.checkScriptSafe.Checked = true;
            this.checkScriptSafe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkScriptSafe.Location = new System.Drawing.Point(160, 202);
            this.checkScriptSafe.Name = "checkScriptSafe";
            this.checkScriptSafe.Size = new System.Drawing.Size(78, 17);
            this.checkScriptSafe.TabIndex = 13;
            this.checkScriptSafe.Text = "Safe Mode";
            this.checkScriptSafe.UseVisualStyleBackColor = true;
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
            this.btnScriptAdd.Image = global::BrilliantShiningScriptEditor.Properties.Resources.script_add;
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
            this.btnScriptRemove.Image = global::BrilliantShiningScriptEditor.Properties.Resources.script_remove;
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
            this.btnScriptCompile.Image = global::BrilliantShiningScriptEditor.Properties.Resources.script_compile;
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
            this.btnScriptSave.Image = global::BrilliantShiningScriptEditor.Properties.Resources.script_save;
            this.btnScriptSave.Location = new System.Drawing.Point(189, 130);
            this.btnScriptSave.Name = "btnScriptSave";
            this.btnScriptSave.Size = new System.Drawing.Size(55, 55);
            this.btnScriptSave.TabIndex = 4;
            this.btnScriptSave.UseVisualStyleBackColor = true;
            this.btnScriptSave.Click += new System.EventHandler(this.btnScriptSave_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 623);
            this.Controls.Add(this.webEditor);
            this.Controls.Add(this.grpScriptFile);
            this.Controls.Add(this.stripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1124, 662);
            this.Name = "FormMain";
            this.Text = "Brilliant Shining Script Editor";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.stripMain.ResumeLayout(false);
            this.stripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webEditor)).EndInit();
            this.grpScriptFile.ResumeLayout(false);
            this.grpScriptFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip stripMain;
        private System.Windows.Forms.ToolStripButton tbtnOpen;
        private System.Windows.Forms.ToolStripButton tbtnSave;
        private System.Windows.Forms.Button btnScriptSave;
        private System.Windows.Forms.Button btnScriptCompile;
        private System.Windows.Forms.Label lbScriptFile;
        private System.Windows.Forms.ComboBox comboScriptFile;
        private System.Windows.Forms.GroupBox grpScriptFile;
        private System.Windows.Forms.Button btnScriptAdd;
        private System.Windows.Forms.Label lbScript;
        private System.Windows.Forms.ComboBox comboScript;
        private System.Windows.Forms.Button btnScriptRemove;
        private System.Windows.Forms.CheckBox checkScriptSafe;
        private Microsoft.Web.WebView2.WinForms.WebView2 webEditor;
        private System.Windows.Forms.ToolTip ttFormMain;
        private System.Windows.Forms.ToolStripSeparator tsepFirst;
        private System.Windows.Forms.ToolStripButton tbtnReference;
    }
}

