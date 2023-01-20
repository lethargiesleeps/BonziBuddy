namespace BonzoBuddo.Forms
{
    partial class DictionaryForm
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
            this.wordLabel = new System.Windows.Forms.Label();
            this.wordBox = new System.Windows.Forms.TextBox();
            this.thesaurusBox = new System.Windows.Forms.CheckBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wordLabel
            // 
            this.wordLabel.AutoSize = true;
            this.wordLabel.Location = new System.Drawing.Point(12, 21);
            this.wordLabel.Name = "wordLabel";
            this.wordLabel.Size = new System.Drawing.Size(65, 24);
            this.wordLabel.TabIndex = 0;
            this.wordLabel.Text = "Word: ";
            // 
            // wordBox
            // 
            this.wordBox.Location = new System.Drawing.Point(74, 18);
            this.wordBox.Name = "wordBox";
            this.wordBox.PlaceholderText = "Enter word to search";
            this.wordBox.Size = new System.Drawing.Size(430, 31);
            this.wordBox.TabIndex = 1;
            // 
            // thesaurusBox
            // 
            this.thesaurusBox.AutoSize = true;
            this.thesaurusBox.Location = new System.Drawing.Point(527, 19);
            this.thesaurusBox.Name = "thesaurusBox";
            this.thesaurusBox.Size = new System.Drawing.Size(114, 28);
            this.thesaurusBox.TabIndex = 3;
            this.thesaurusBox.Text = "Thesaurus";
            this.thesaurusBox.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(691, 9);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(114, 48);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(833, 9);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(114, 48);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // DictionaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 69);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.thesaurusBox);
            this.Controls.Add(this.wordBox);
            this.Controls.Add(this.wordLabel);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DictionaryForm";
            this.ShowInTaskbar = false;
            this.Text = "Dictionary";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label wordLabel;
        private TextBox wordBox;
        private CheckBox thesaurusBox;
        private Button submitButton;
        private Button cancelButton;
    }
}