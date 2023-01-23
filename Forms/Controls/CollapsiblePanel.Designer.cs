
namespace BrilliantShiningScriptEditor.Forms.Controls
{
    partial class CollapsiblePanel
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
            this.tabContainer.SuspendLayout();
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
            this.tabContainer.Size = new System.Drawing.Size(323, 147);
            this.tabContainer.TabIndex = 0;
            this.tabContainer.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabContainer_Selected);
            // 
            // tabButton
            // 
            this.tabButton.Location = new System.Drawing.Point(4, 22);
            this.tabButton.Name = "tabButton";
            this.tabButton.Padding = new System.Windows.Forms.Padding(3);
            this.tabButton.Size = new System.Drawing.Size(315, 121);
            this.tabButton.TabIndex = 0;
            this.tabButton.Text = "tabPage1";
            this.tabButton.UseVisualStyleBackColor = true;
            // 
            // CollapsiblePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabContainer);
            this.Name = "CollapsiblePanel";
            this.Size = new System.Drawing.Size(329, 153);
            this.tabContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.TabPage tabButton;
    }
}
