
namespace BrilliantShiningScriptEditor.UI.Forms
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
            this.treeFiles = new System.Windows.Forms.TreeView();
            this.imgTree = new System.Windows.Forms.ImageList(this.components);
            this.checkScriptSafe = new System.Windows.Forms.CheckBox();
            this.btnScriptCompile = new System.Windows.Forms.Button();
            this.btnScriptSave = new System.Windows.Forms.Button();
            this.ttFormMain = new System.Windows.Forms.ToolTip(this.components);
            this.cntxtScriptFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cntxtitemScriptFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxtitemScriptFileRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxtitemScriptFileAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxtScript = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cntxtitemScriptOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxtitemScriptRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxtitemScriptDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.clpErrErrorList = new BrilliantShiningScriptEditor.UI.Controls.CollapsibleErrorList();
            this.stripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webEditor)).BeginInit();
            this.grpScriptFile.SuspendLayout();
            this.cntxtScriptFile.SuspendLayout();
            this.cntxtScript.SuspendLayout();
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
            this.webEditor.Size = new System.Drawing.Size(828, 339);
            this.webEditor.TabIndex = 7;
            this.webEditor.ZoomFactor = 1D;
            this.webEditor.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.webEditor_NavigationCompleted);
            // 
            // grpScriptFile
            // 
            this.grpScriptFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpScriptFile.Controls.Add(this.treeFiles);
            this.grpScriptFile.Controls.Add(this.checkScriptSafe);
            this.grpScriptFile.Controls.Add(this.btnScriptCompile);
            this.grpScriptFile.Controls.Add(this.btnScriptSave);
            this.grpScriptFile.Location = new System.Drawing.Point(846, 42);
            this.grpScriptFile.Name = "grpScriptFile";
            this.grpScriptFile.Size = new System.Drawing.Size(250, 569);
            this.grpScriptFile.TabIndex = 5;
            this.grpScriptFile.TabStop = false;
            this.grpScriptFile.Text = "Script File Control";
            // 
            // treeFiles
            // 
            this.treeFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeFiles.Enabled = false;
            this.treeFiles.ImageIndex = 0;
            this.treeFiles.ImageList = this.imgTree;
            this.treeFiles.Location = new System.Drawing.Point(6, 19);
            this.treeFiles.Name = "treeFiles";
            this.treeFiles.SelectedImageIndex = 0;
            this.treeFiles.Size = new System.Drawing.Size(238, 483);
            this.treeFiles.TabIndex = 14;
            this.treeFiles.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFiles_NodeMouseClick);
            this.treeFiles.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFiles_NodeMouseDoubleClick);
            // 
            // imgTree
            // 
            this.imgTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTree.ImageStream")));
            this.imgTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imgTree.Images.SetKeyName(0, "script_base.png");
            this.imgTree.Images.SetKeyName(1, "script_stack.png");
            // 
            // checkScriptSafe
            // 
            this.checkScriptSafe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkScriptSafe.AutoSize = true;
            this.checkScriptSafe.Checked = true;
            this.checkScriptSafe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkScriptSafe.Location = new System.Drawing.Point(148, 528);
            this.checkScriptSafe.Name = "checkScriptSafe";
            this.checkScriptSafe.Size = new System.Drawing.Size(78, 17);
            this.checkScriptSafe.TabIndex = 13;
            this.checkScriptSafe.Text = "Safe Mode";
            this.checkScriptSafe.UseVisualStyleBackColor = true;
            // 
            // btnScriptCompile
            // 
            this.btnScriptCompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScriptCompile.Enabled = false;
            this.btnScriptCompile.Image = global::BrilliantShiningScriptEditor.Properties.Resources.script_compile;
            this.btnScriptCompile.Location = new System.Drawing.Point(6, 508);
            this.btnScriptCompile.Name = "btnScriptCompile";
            this.btnScriptCompile.Size = new System.Drawing.Size(55, 55);
            this.btnScriptCompile.TabIndex = 3;
            this.btnScriptCompile.UseVisualStyleBackColor = true;
            this.btnScriptCompile.Click += new System.EventHandler(this.btnScriptCompile_Click);
            // 
            // btnScriptSave
            // 
            this.btnScriptSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScriptSave.Enabled = false;
            this.btnScriptSave.Image = global::BrilliantShiningScriptEditor.Properties.Resources.script_save;
            this.btnScriptSave.Location = new System.Drawing.Point(67, 508);
            this.btnScriptSave.Name = "btnScriptSave";
            this.btnScriptSave.Size = new System.Drawing.Size(55, 55);
            this.btnScriptSave.TabIndex = 4;
            this.btnScriptSave.UseVisualStyleBackColor = true;
            this.btnScriptSave.Click += new System.EventHandler(this.btnScriptSave_Click);
            // 
            // cntxtScriptFile
            // 
            this.cntxtScriptFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cntxtitemScriptFileOpen,
            this.cntxtitemScriptFileRename,
            this.cntxtitemScriptFileAdd});
            this.cntxtScriptFile.Name = "cntxtScriptFile";
            this.cntxtScriptFile.Size = new System.Drawing.Size(130, 70);
            this.cntxtScriptFile.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cntxtScriptFile_ItemClicked);
            // 
            // cntxtitemScriptFileOpen
            // 
            this.cntxtitemScriptFileOpen.Enabled = false;
            this.cntxtitemScriptFileOpen.Image = global::BrilliantShiningScriptEditor.Properties.Resources.script_base;
            this.cntxtitemScriptFileOpen.Name = "cntxtitemScriptFileOpen";
            this.cntxtitemScriptFileOpen.Size = new System.Drawing.Size(129, 22);
            this.cntxtitemScriptFileOpen.Text = "Open";
            // 
            // cntxtitemScriptFileRename
            // 
            this.cntxtitemScriptFileRename.Name = "cntxtitemScriptFileRename";
            this.cntxtitemScriptFileRename.Size = new System.Drawing.Size(129, 22);
            this.cntxtitemScriptFileRename.Text = "Rename";
            // 
            // cntxtitemScriptFileAdd
            // 
            this.cntxtitemScriptFileAdd.Image = global::BrilliantShiningScriptEditor.Properties.Resources.script_add;
            this.cntxtitemScriptFileAdd.Name = "cntxtitemScriptFileAdd";
            this.cntxtitemScriptFileAdd.Size = new System.Drawing.Size(129, 22);
            this.cntxtitemScriptFileAdd.Text = "Add Script";
            // 
            // cntxtScript
            // 
            this.cntxtScript.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cntxtitemScriptOpen,
            this.cntxtitemScriptRename,
            this.cntxtitemScriptDelete});
            this.cntxtScript.Name = "cntxtScriptFile";
            this.cntxtScript.Size = new System.Drawing.Size(118, 70);
            this.cntxtScript.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cntxtScript_ItemClicked);
            // 
            // cntxtitemScriptOpen
            // 
            this.cntxtitemScriptOpen.Image = global::BrilliantShiningScriptEditor.Properties.Resources.script_base;
            this.cntxtitemScriptOpen.Name = "cntxtitemScriptOpen";
            this.cntxtitemScriptOpen.Size = new System.Drawing.Size(117, 22);
            this.cntxtitemScriptOpen.Text = "Open";
            // 
            // cntxtitemScriptRename
            // 
            this.cntxtitemScriptRename.Name = "cntxtitemScriptRename";
            this.cntxtitemScriptRename.Size = new System.Drawing.Size(117, 22);
            this.cntxtitemScriptRename.Text = "Rename";
            // 
            // cntxtitemScriptDelete
            // 
            this.cntxtitemScriptDelete.Image = global::BrilliantShiningScriptEditor.Properties.Resources.script_remove;
            this.cntxtitemScriptDelete.Name = "cntxtitemScriptDelete";
            this.cntxtitemScriptDelete.Size = new System.Drawing.Size(117, 22);
            this.cntxtitemScriptDelete.Text = "Delete";
            // 
            // clpErrErrorList
            // 
            this.clpErrErrorList.ButtonText = "Error List";
            this.clpErrErrorList.IntendedSize = new System.Drawing.Size(828, 224);
            this.clpErrErrorList.Location = new System.Drawing.Point(12, 387);
            this.clpErrErrorList.Name = "clpErrErrorList";
            this.clpErrErrorList.Size = new System.Drawing.Size(828, 224);
            this.clpErrErrorList.TabIndex = 8;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 623);
            this.Controls.Add(this.clpErrErrorList);
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
            this.cntxtScriptFile.ResumeLayout(false);
            this.cntxtScript.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip stripMain;
        private System.Windows.Forms.ToolStripButton tbtnOpen;
        private System.Windows.Forms.ToolStripButton tbtnSave;
        private System.Windows.Forms.Button btnScriptSave;
        private System.Windows.Forms.Button btnScriptCompile;
        private System.Windows.Forms.GroupBox grpScriptFile;
        private System.Windows.Forms.CheckBox checkScriptSafe;
        private Microsoft.Web.WebView2.WinForms.WebView2 webEditor;
        private System.Windows.Forms.ToolTip ttFormMain;
        private System.Windows.Forms.ToolStripSeparator tsepFirst;
        private System.Windows.Forms.ToolStripButton tbtnReference;
        private System.Windows.Forms.TreeView treeFiles;
        private System.Windows.Forms.ImageList imgTree;
        private System.Windows.Forms.ContextMenuStrip cntxtScriptFile;
        private System.Windows.Forms.ToolStripMenuItem cntxtitemScriptFileOpen;
        private System.Windows.Forms.ToolStripMenuItem cntxtitemScriptFileRename;
        private System.Windows.Forms.ToolStripMenuItem cntxtitemScriptFileAdd;
        private System.Windows.Forms.ContextMenuStrip cntxtScript;
        private System.Windows.Forms.ToolStripMenuItem cntxtitemScriptOpen;
        private System.Windows.Forms.ToolStripMenuItem cntxtitemScriptRename;
        private System.Windows.Forms.ToolStripMenuItem cntxtitemScriptDelete;
        private Controls.CollapsibleErrorList clpErrErrorList;
    }
}

