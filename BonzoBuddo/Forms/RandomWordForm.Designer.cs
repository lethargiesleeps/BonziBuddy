namespace BonzoBuddo.Forms
{
    partial class RandomWordForm
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
            this.dictionaryBox = new System.Windows.Forms.CheckBox();
            this.thesaurusBox = new System.Windows.Forms.CheckBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dictionaryBox
            // 
            this.dictionaryBox.AutoSize = true;
            this.dictionaryBox.Location = new System.Drawing.Point(13, 28);
            this.dictionaryBox.Margin = new System.Windows.Forms.Padding(4);
            this.dictionaryBox.Name = "dictionaryBox";
            this.dictionaryBox.Size = new System.Drawing.Size(111, 28);
            this.dictionaryBox.TabIndex = 0;
            this.dictionaryBox.Text = "Definition";
            this.dictionaryBox.UseVisualStyleBackColor = true;
            this.dictionaryBox.CheckedChanged += new System.EventHandler(this.dictionaryBox_CheckedChanged);
            // 
            // thesaurusBox
            // 
            this.thesaurusBox.AutoSize = true;
            this.thesaurusBox.Enabled = false;
            this.thesaurusBox.Location = new System.Drawing.Point(132, 28);
            this.thesaurusBox.Margin = new System.Windows.Forms.Padding(4);
            this.thesaurusBox.Name = "thesaurusBox";
            this.thesaurusBox.Size = new System.Drawing.Size(114, 28);
            this.thesaurusBox.TabIndex = 1;
            this.thesaurusBox.Text = "Thesaurus";
            this.thesaurusBox.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(331, 12);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(112, 59);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(458, 12);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 59);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // RandomWordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 84);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.thesaurusBox);
            this.Controls.Add(this.dictionaryBox);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RandomWordForm";
            this.RightToLeftLayout = true;
            this.Text = "Random Word";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox dictionaryBox;
        private CheckBox thesaurusBox;
        private Button submitButton;
        private Button cancelButton;
    }
}