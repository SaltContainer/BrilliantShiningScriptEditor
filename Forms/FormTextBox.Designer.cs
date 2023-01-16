
namespace BrilliantShiningScriptEditor.Forms
{
    partial class FormTextBox
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
            this.btnYes = new System.Windows.Forms.Button();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.btnNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(12, 90);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(131, 28);
            this.btnYes.TabIndex = 0;
            this.btnYes.Text = "button1";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(12, 64);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(268, 20);
            this.txtAnswer.TabIndex = 1;
            // 
            // lbInfo
            // 
            this.lbInfo.Location = new System.Drawing.Point(12, 9);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(268, 52);
            this.lbInfo.TabIndex = 2;
            this.lbInfo.Text = "label1";
            this.lbInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnNo
            // 
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.Location = new System.Drawing.Point(149, 90);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(131, 28);
            this.btnNo.TabIndex = 3;
            this.btnNo.Text = "button2";
            this.btnNo.UseVisualStyleBackColor = true;
            // 
            // FormTextBox
            // 
            this.AcceptButton = this.btnYes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnNo;
            this.ClientSize = new System.Drawing.Size(292, 130);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.txtAnswer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTextBox";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTextBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Button btnNo;
    }
}