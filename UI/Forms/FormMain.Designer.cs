
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
            this.tbtnScriptCompile = new System.Windows.Forms.ToolStripButton();
            this.tbtnScriptSave = new System.Windows.Forms.ToolStripButton();
            this.tbtnSafeMode = new System.Windows.Forms.ToolStripButton();
            this.tsepSecond = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnReference = new System.Windows.Forms.ToolStripButton();
            this.tsepThird = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnError = new System.Windows.Forms.ToolStripButton();
            this.webEditor = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.grpScriptFile = new System.Windows.Forms.GroupBox();
            this.lbScriptInfo = new System.Windows.Forms.Label();
            this.treeFiles = new System.Windows.Forms.TreeView();
            this.imgTree = new System.Windows.Forms.ImageList(this.components);
            this.ttFormMain = new System.Windows.Forms.ToolTip(this.components);
            this.cntxtScriptFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cntxtitemScriptFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxtitemScriptFileRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxtitemScriptFileAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxtScript = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cntxtitemScriptOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxtitemScriptRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxtitemScriptDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.splitEditor = new System.Windows.Forms.SplitContainer();
            this.gridErrors = new System.Windows.Forms.DataGridView();
            this.colImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.colLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webEditor)).BeginInit();
            this.grpScriptFile.SuspendLayout();
            this.cntxtScriptFile.SuspendLayout();
            this.cntxtScript.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitEditor)).BeginInit();
            this.splitEditor.Panel1.SuspendLayout();
            this.splitEditor.Panel2.SuspendLayout();
            this.splitEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridErrors)).BeginInit();
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
            this.tbtnScriptCompile,
            this.tbtnScriptSave,
            this.tbtnSafeMode,
            this.tsepSecond,
            this.tbtnReference,
            this.tsepThird,
            this.tbtnError});
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
            // tbtnScriptCompile
            // 
            this.tbtnScriptCompile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnScriptCompile.Enabled = false;
            this.tbtnScriptCompile.Image = global::BrilliantShiningScriptEditor.Properties.Resources.script_compile;
            this.tbtnScriptCompile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnScriptCompile.Name = "tbtnScriptCompile";
            this.tbtnScriptCompile.Size = new System.Drawing.Size(36, 36);
            this.tbtnScriptCompile.Text = "toolStripButton1";
            this.tbtnScriptCompile.ToolTipText = "Compile Script";
            this.tbtnScriptCompile.Click += new System.EventHandler(this.tbtnScriptCompile_Click);
            // 
            // tbtnScriptSave
            // 
            this.tbtnScriptSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnScriptSave.Enabled = false;
            this.tbtnScriptSave.Image = global::BrilliantShiningScriptEditor.Properties.Resources.script_save;
            this.tbtnScriptSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnScriptSave.Name = "tbtnScriptSave";
            this.tbtnScriptSave.Size = new System.Drawing.Size(36, 36);
            this.tbtnScriptSave.Text = "toolStripButton2";
            this.tbtnScriptSave.ToolTipText = "Save Script into memory";
            this.tbtnScriptSave.Click += new System.EventHandler(this.tbtnScriptSave_Click);
            // 
            // tbtnSafeMode
            // 
            this.tbtnSafeMode.Checked = true;
            this.tbtnSafeMode.CheckOnClick = true;
            this.tbtnSafeMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tbtnSafeMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtnSafeMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnSafeMode.Name = "tbtnSafeMode";
            this.tbtnSafeMode.Size = new System.Drawing.Size(33, 36);
            this.tbtnSafeMode.Text = "Safe";
            this.tbtnSafeMode.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.tbtnSafeMode.ToolTipText = "Safe Mode";
            // 
            // tsepSecond
            // 
            this.tsepSecond.Name = "tsepSecond";
            this.tsepSecond.Size = new System.Drawing.Size(6, 39);
            // 
            // tbtnReference
            // 
            this.tbtnReference.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnReference.Image = global::BrilliantShiningScriptEditor.Properties.Resources.info;
            this.tbtnReference.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnReference.Name = "tbtnReference";
            this.tbtnReference.Size = new System.Drawing.Size(36, 36);
            this.tbtnReference.Text = "tbtnReference";
            this.tbtnReference.ToolTipText = "Open Reference Window";
            this.tbtnReference.Click += new System.EventHandler(this.tbtnReference_Click);
            // 
            // tsepThird
            // 
            this.tsepThird.Name = "tsepThird";
            this.tsepThird.Size = new System.Drawing.Size(6, 39);
            // 
            // tbtnError
            // 
            this.tbtnError.Checked = true;
            this.tbtnError.CheckOnClick = true;
            this.tbtnError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tbtnError.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnError.Image = global::BrilliantShiningScriptEditor.Properties.Resources.error;
            this.tbtnError.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnError.Name = "tbtnError";
            this.tbtnError.Size = new System.Drawing.Size(36, 36);
            this.tbtnError.Text = "toolStripButton1";
            this.tbtnError.ToolTipText = "Toggle Error List Panel";
            this.tbtnError.Click += new System.EventHandler(this.tbtnError_Click);
            // 
            // webEditor
            // 
            this.webEditor.AllowExternalDrop = true;
            this.webEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webEditor.CreationProperties = null;
            this.webEditor.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webEditor.Location = new System.Drawing.Point(0, 0);
            this.webEditor.Name = "webEditor";
            this.webEditor.Size = new System.Drawing.Size(828, 426);
            this.webEditor.TabIndex = 7;
            this.webEditor.ZoomFactor = 1D;
            this.webEditor.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.webEditor_NavigationCompleted);
            // 
            // grpScriptFile
            // 
            this.grpScriptFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpScriptFile.Controls.Add(this.lbScriptInfo);
            this.grpScriptFile.Controls.Add(this.treeFiles);
            this.grpScriptFile.Location = new System.Drawing.Point(846, 42);
            this.grpScriptFile.Name = "grpScriptFile";
            this.grpScriptFile.Size = new System.Drawing.Size(250, 569);
            this.grpScriptFile.TabIndex = 5;
            this.grpScriptFile.TabStop = false;
            this.grpScriptFile.Text = "Script File Explorer";
            // 
            // lbScriptInfo
            // 
            this.lbScriptInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbScriptInfo.Location = new System.Drawing.Point(6, 432);
            this.lbScriptInfo.Name = "lbScriptInfo";
            this.lbScriptInfo.Size = new System.Drawing.Size(238, 134);
            this.lbScriptInfo.TabIndex = 15;
            this.lbScriptInfo.Text = "Loaded Script:\r\nNone";
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
            this.treeFiles.Size = new System.Drawing.Size(238, 407);
            this.treeFiles.TabIndex = 14;
            this.treeFiles.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeFiles_BeforeCollapse);
            this.treeFiles.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeFiles_BeforeExpand);
            this.treeFiles.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFiles_NodeMouseClick);
            this.treeFiles.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFiles_NodeMouseDoubleClick);
            this.treeFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeFiles_MouseDown);
            // 
            // imgTree
            // 
            this.imgTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTree.ImageStream")));
            this.imgTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imgTree.Images.SetKeyName(0, "script_base.png");
            this.imgTree.Images.SetKeyName(1, "script_stack.png");
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
            // splitEditor
            // 
            this.splitEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitEditor.IsSplitterFixed = true;
            this.splitEditor.Location = new System.Drawing.Point(12, 42);
            this.splitEditor.Name = "splitEditor";
            this.splitEditor.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitEditor.Panel1
            // 
            this.splitEditor.Panel1.Controls.Add(this.webEditor);
            // 
            // splitEditor.Panel2
            // 
            this.splitEditor.Panel2.Controls.Add(this.gridErrors);
            this.splitEditor.Size = new System.Drawing.Size(828, 569);
            this.splitEditor.SplitterDistance = 424;
            this.splitEditor.SplitterWidth = 8;
            this.splitEditor.TabIndex = 9;
            // 
            // gridErrors
            // 
            this.gridErrors.AllowUserToAddRows = false;
            this.gridErrors.AllowUserToDeleteRows = false;
            this.gridErrors.AllowUserToResizeColumns = false;
            this.gridErrors.AllowUserToResizeRows = false;
            this.gridErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridErrors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImg,
            this.colLine,
            this.colMsg});
            this.gridErrors.Location = new System.Drawing.Point(0, 0);
            this.gridErrors.Name = "gridErrors";
            this.gridErrors.ReadOnly = true;
            this.gridErrors.RowHeadersVisible = false;
            this.gridErrors.Size = new System.Drawing.Size(828, 140);
            this.gridErrors.TabIndex = 1;
            // 
            // colImg
            // 
            this.colImg.DataPropertyName = "Image";
            this.colImg.HeaderText = "";
            this.colImg.Name = "colImg";
            this.colImg.ReadOnly = true;
            this.colImg.Width = 30;
            // 
            // colLine
            // 
            this.colLine.DataPropertyName = "Line";
            this.colLine.HeaderText = "Line";
            this.colLine.Name = "colLine";
            this.colLine.ReadOnly = true;
            this.colLine.Width = 35;
            // 
            // colMsg
            // 
            this.colMsg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMsg.DataPropertyName = "Message";
            this.colMsg.HeaderText = "Message";
            this.colMsg.Name = "colMsg";
            this.colMsg.ReadOnly = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 623);
            this.Controls.Add(this.splitEditor);
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
            this.cntxtScriptFile.ResumeLayout(false);
            this.cntxtScript.ResumeLayout(false);
            this.splitEditor.Panel1.ResumeLayout(false);
            this.splitEditor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitEditor)).EndInit();
            this.splitEditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridErrors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip stripMain;
        private System.Windows.Forms.ToolStripButton tbtnOpen;
        private System.Windows.Forms.ToolStripButton tbtnSave;
        private System.Windows.Forms.GroupBox grpScriptFile;
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
        private System.Windows.Forms.SplitContainer splitEditor;
        private System.Windows.Forms.DataGridView gridErrors;
        private System.Windows.Forms.DataGridViewImageColumn colImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMsg;
        private System.Windows.Forms.ToolStripSeparator tsepSecond;
        private System.Windows.Forms.ToolStripButton tbtnError;
        private System.Windows.Forms.ToolStripButton tbtnScriptCompile;
        private System.Windows.Forms.ToolStripButton tbtnScriptSave;
        private System.Windows.Forms.ToolStripButton tbtnSafeMode;
        private System.Windows.Forms.ToolStripSeparator tsepThird;
        private System.Windows.Forms.Label lbScriptInfo;
    }
}

