namespace BrilliantShiningScriptEditor.UI.Forms
{
    partial class FormSettings
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
            this.grpArgSyntax = new System.Windows.Forms.GroupBox();
            this.radioArgSyntaxAssembly = new System.Windows.Forms.RadioButton();
            this.radioArgSyntaxFunction = new System.Windows.Forms.RadioButton();
            this.grpTypeSyntax = new System.Windows.Forms.GroupBox();
            this.radioTypeSyntaxTyped = new System.Windows.Forms.RadioButton();
            this.radioTypeSyntaxSymbol = new System.Windows.Forms.RadioButton();
            this.grpCommentSyntax = new System.Windows.Forms.GroupBox();
            this.radioCommentSyntaxSemiColon = new System.Windows.Forms.RadioButton();
            this.radioCommentSyntaxTriBrackets = new System.Windows.Forms.RadioButton();
            this.radioCommentSyntaxDoubleSlash = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpArgSyntax.SuspendLayout();
            this.grpTypeSyntax.SuspendLayout();
            this.grpCommentSyntax.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpArgSyntax
            // 
            this.grpArgSyntax.Controls.Add(this.radioArgSyntaxAssembly);
            this.grpArgSyntax.Controls.Add(this.radioArgSyntaxFunction);
            this.grpArgSyntax.Location = new System.Drawing.Point(12, 12);
            this.grpArgSyntax.Name = "grpArgSyntax";
            this.grpArgSyntax.Size = new System.Drawing.Size(165, 70);
            this.grpArgSyntax.TabIndex = 0;
            this.grpArgSyntax.TabStop = false;
            this.grpArgSyntax.Text = "Argument Syntax";
            // 
            // radioArgSyntaxAssembly
            // 
            this.radioArgSyntaxAssembly.AutoSize = true;
            this.radioArgSyntaxAssembly.Checked = true;
            this.radioArgSyntaxAssembly.Location = new System.Drawing.Point(16, 19);
            this.radioArgSyntaxAssembly.Name = "radioArgSyntaxAssembly";
            this.radioArgSyntaxAssembly.Size = new System.Drawing.Size(69, 17);
            this.radioArgSyntaxAssembly.TabIndex = 0;
            this.radioArgSyntaxAssembly.TabStop = true;
            this.radioArgSyntaxAssembly.Text = "Assembly";
            this.radioArgSyntaxAssembly.UseVisualStyleBackColor = true;
            // 
            // radioArgSyntaxFunction
            // 
            this.radioArgSyntaxFunction.AutoSize = true;
            this.radioArgSyntaxFunction.Location = new System.Drawing.Point(16, 42);
            this.radioArgSyntaxFunction.Name = "radioArgSyntaxFunction";
            this.radioArgSyntaxFunction.Size = new System.Drawing.Size(66, 17);
            this.radioArgSyntaxFunction.TabIndex = 1;
            this.radioArgSyntaxFunction.TabStop = true;
            this.radioArgSyntaxFunction.Text = "Function";
            this.radioArgSyntaxFunction.UseVisualStyleBackColor = true;
            // 
            // grpTypeSyntax
            // 
            this.grpTypeSyntax.Controls.Add(this.radioTypeSyntaxTyped);
            this.grpTypeSyntax.Controls.Add(this.radioTypeSyntaxSymbol);
            this.grpTypeSyntax.Location = new System.Drawing.Point(12, 88);
            this.grpTypeSyntax.Name = "grpTypeSyntax";
            this.grpTypeSyntax.Size = new System.Drawing.Size(165, 70);
            this.grpTypeSyntax.TabIndex = 1;
            this.grpTypeSyntax.TabStop = false;
            this.grpTypeSyntax.Text = "Type Syntax";
            // 
            // radioTypeSyntaxTyped
            // 
            this.radioTypeSyntaxTyped.AutoSize = true;
            this.radioTypeSyntaxTyped.Checked = true;
            this.radioTypeSyntaxTyped.Location = new System.Drawing.Point(16, 19);
            this.radioTypeSyntaxTyped.Name = "radioTypeSyntaxTyped";
            this.radioTypeSyntaxTyped.Size = new System.Drawing.Size(55, 17);
            this.radioTypeSyntaxTyped.TabIndex = 0;
            this.radioTypeSyntaxTyped.TabStop = true;
            this.radioTypeSyntaxTyped.Text = "Typed";
            this.radioTypeSyntaxTyped.UseVisualStyleBackColor = true;
            // 
            // radioTypeSyntaxSymbol
            // 
            this.radioTypeSyntaxSymbol.AutoSize = true;
            this.radioTypeSyntaxSymbol.Location = new System.Drawing.Point(16, 42);
            this.radioTypeSyntaxSymbol.Name = "radioTypeSyntaxSymbol";
            this.radioTypeSyntaxSymbol.Size = new System.Drawing.Size(59, 17);
            this.radioTypeSyntaxSymbol.TabIndex = 1;
            this.radioTypeSyntaxSymbol.TabStop = true;
            this.radioTypeSyntaxSymbol.Text = "Symbol";
            this.radioTypeSyntaxSymbol.UseVisualStyleBackColor = true;
            // 
            // grpCommentSyntax
            // 
            this.grpCommentSyntax.Controls.Add(this.radioCommentSyntaxSemiColon);
            this.grpCommentSyntax.Controls.Add(this.radioCommentSyntaxTriBrackets);
            this.grpCommentSyntax.Controls.Add(this.radioCommentSyntaxDoubleSlash);
            this.grpCommentSyntax.Location = new System.Drawing.Point(12, 164);
            this.grpCommentSyntax.Name = "grpCommentSyntax";
            this.grpCommentSyntax.Size = new System.Drawing.Size(165, 96);
            this.grpCommentSyntax.TabIndex = 2;
            this.grpCommentSyntax.TabStop = false;
            this.grpCommentSyntax.Text = "Comment Syntax";
            // 
            // radioCommentSyntaxSemiColon
            // 
            this.radioCommentSyntaxSemiColon.AutoSize = true;
            this.radioCommentSyntaxSemiColon.Checked = true;
            this.radioCommentSyntaxSemiColon.Location = new System.Drawing.Point(16, 19);
            this.radioCommentSyntaxSemiColon.Name = "radioCommentSyntaxSemiColon";
            this.radioCommentSyntaxSemiColon.Size = new System.Drawing.Size(72, 17);
            this.radioCommentSyntaxSemiColon.TabIndex = 0;
            this.radioCommentSyntaxSemiColon.TabStop = true;
            this.radioCommentSyntaxSemiColon.Text = ";Comment";
            this.radioCommentSyntaxSemiColon.UseVisualStyleBackColor = true;
            // 
            // radioCommentSyntaxTriBrackets
            // 
            this.radioCommentSyntaxTriBrackets.AutoSize = true;
            this.radioCommentSyntaxTriBrackets.Location = new System.Drawing.Point(16, 42);
            this.radioCommentSyntaxTriBrackets.Name = "radioCommentSyntaxTriBrackets";
            this.radioCommentSyntaxTriBrackets.Size = new System.Drawing.Size(81, 17);
            this.radioCommentSyntaxTriBrackets.TabIndex = 1;
            this.radioCommentSyntaxTriBrackets.TabStop = true;
            this.radioCommentSyntaxTriBrackets.Text = "<Comment>";
            this.radioCommentSyntaxTriBrackets.UseVisualStyleBackColor = true;
            // 
            // radioCommentSyntaxDoubleSlash
            // 
            this.radioCommentSyntaxDoubleSlash.AutoSize = true;
            this.radioCommentSyntaxDoubleSlash.Location = new System.Drawing.Point(16, 65);
            this.radioCommentSyntaxDoubleSlash.Name = "radioCommentSyntaxDoubleSlash";
            this.radioCommentSyntaxDoubleSlash.Size = new System.Drawing.Size(79, 17);
            this.radioCommentSyntaxDoubleSlash.TabIndex = 2;
            this.radioCommentSyntaxDoubleSlash.TabStop = true;
            this.radioCommentSyntaxDoubleSlash.Text = "//Comment";
            this.radioCommentSyntaxDoubleSlash.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(98, 266);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 30);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 266);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormSettings
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(189, 306);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpArgSyntax);
            this.Controls.Add(this.grpTypeSyntax);
            this.Controls.Add(this.grpCommentSyntax);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(205, 345);
            this.MinimumSize = new System.Drawing.Size(205, 345);
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.grpArgSyntax.ResumeLayout(false);
            this.grpArgSyntax.PerformLayout();
            this.grpTypeSyntax.ResumeLayout(false);
            this.grpTypeSyntax.PerformLayout();
            this.grpCommentSyntax.ResumeLayout(false);
            this.grpCommentSyntax.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpArgSyntax;
        private System.Windows.Forms.GroupBox grpTypeSyntax;
        private System.Windows.Forms.GroupBox grpCommentSyntax;
        private System.Windows.Forms.RadioButton radioArgSyntaxAssembly;
        private System.Windows.Forms.RadioButton radioArgSyntaxFunction;
        private System.Windows.Forms.RadioButton radioTypeSyntaxTyped;
        private System.Windows.Forms.RadioButton radioTypeSyntaxSymbol;
        private System.Windows.Forms.RadioButton radioCommentSyntaxSemiColon;
        private System.Windows.Forms.RadioButton radioCommentSyntaxTriBrackets;
        private System.Windows.Forms.RadioButton radioCommentSyntaxDoubleSlash;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}