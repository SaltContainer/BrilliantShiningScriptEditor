
namespace BrilliantShiningScriptEditor.UI.Controls
{
    partial class CollapsibleErrorList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.tabButton = new System.Windows.Forms.TabPage();
            this.gridErrors = new System.Windows.Forms.DataGridView();
            this.colImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.colLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabContainer.SuspendLayout();
            this.tabButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // tabContainer
            // 
            this.tabContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabContainer.Controls.Add(this.tabButton);
            this.tabContainer.Location = new System.Drawing.Point(3, 3);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(728, 273);
            this.tabContainer.TabIndex = 0;
            this.tabContainer.SelectedIndexChanged += new System.EventHandler(this.tabContainer_SelectedIndexChanged);
            this.tabContainer.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabContainer_Selecting);
            this.tabContainer.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabContainer_Selected);
            // 
            // tabButton
            // 
            this.tabButton.Controls.Add(this.gridErrors);
            this.tabButton.Location = new System.Drawing.Point(4, 22);
            this.tabButton.Name = "tabButton";
            this.tabButton.Padding = new System.Windows.Forms.Padding(3);
            this.tabButton.Size = new System.Drawing.Size(720, 247);
            this.tabButton.TabIndex = 0;
            this.tabButton.Text = "tabPage1";
            this.tabButton.UseVisualStyleBackColor = true;
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
            this.gridErrors.Location = new System.Drawing.Point(6, 6);
            this.gridErrors.Name = "gridErrors";
            this.gridErrors.ReadOnly = true;
            this.gridErrors.Size = new System.Drawing.Size(708, 235);
            this.gridErrors.TabIndex = 0;
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
            // CollapsibleErrorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabContainer);
            this.Name = "CollapsibleErrorList";
            this.Size = new System.Drawing.Size(731, 276);
            this.tabContainer.ResumeLayout(false);
            this.tabButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridErrors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.TabPage tabButton;
        private System.Windows.Forms.DataGridView gridErrors;
        private System.Windows.Forms.DataGridViewImageColumn colImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMsg;
    }
}
