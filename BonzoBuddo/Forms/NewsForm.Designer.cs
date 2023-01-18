namespace BonzoBuddo.Forms
{
    partial class NewsForm
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
            this.keywordLabels = new System.Windows.Forms.Label();
            this.keywordsBox = new System.Windows.Forms.TextBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryBox = new System.Windows.Forms.ComboBox();
            this.countryLabel = new System.Windows.Forms.Label();
            this.countryBox = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // keywordLabels
            // 
            this.keywordLabels.AutoSize = true;
            this.keywordLabels.Location = new System.Drawing.Point(15, 27);
            this.keywordLabels.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.keywordLabels.Name = "keywordLabels";
            this.keywordLabels.Size = new System.Drawing.Size(93, 24);
            this.keywordLabels.TabIndex = 0;
            this.keywordLabels.Text = "Keywords:";
            // 
            // keywordsBox
            // 
            this.keywordsBox.Location = new System.Drawing.Point(118, 23);
            this.keywordsBox.Margin = new System.Windows.Forms.Padding(4);
            this.keywordsBox.Name = "keywordsBox";
            this.keywordsBox.PlaceholderText = "Leave blank for no keywords.";
            this.keywordsBox.Size = new System.Drawing.Size(406, 31);
            this.keywordsBox.TabIndex = 1;
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(15, 110);
            this.categoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(88, 24);
            this.categoryLabel.TabIndex = 2;
            this.categoryLabel.Text = "Category:";
            // 
            // categoryBox
            // 
            this.categoryBox.FormattingEnabled = true;
            this.categoryBox.Location = new System.Drawing.Point(118, 107);
            this.categoryBox.Margin = new System.Windows.Forms.Padding(4);
            this.categoryBox.Name = "categoryBox";
            this.categoryBox.Size = new System.Drawing.Size(406, 32);
            this.categoryBox.TabIndex = 3;
            this.categoryBox.Text = "Select \'None\' for random article.";
            this.categoryBox.SelectedIndexChanged += new System.EventHandler(this.categoryBox_SelectedIndexChanged);
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Location = new System.Drawing.Point(15, 200);
            this.countryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(83, 24);
            this.countryLabel.TabIndex = 4;
            this.countryLabel.Text = "Country: ";
            // 
            // countryBox
            // 
            this.countryBox.FormattingEnabled = true;
            this.countryBox.Location = new System.Drawing.Point(118, 196);
            this.countryBox.Margin = new System.Windows.Forms.Padding(4);
            this.countryBox.Name = "countryBox";
            this.countryBox.Size = new System.Drawing.Size(406, 32);
            this.countryBox.TabIndex = 5;
            this.countryBox.Text = "Select \'None\' to use your default country.";
            this.countryBox.SelectedIndexChanged += new System.EventHandler(this.countryBox_SelectedIndexChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(15, 455);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(129, 73);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(150, 455);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(129, 73);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(395, 455);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(129, 73);
            this.submitButton.TabIndex = 8;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // NewsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 540);
            this.ControlBox = false;
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.countryBox);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.categoryBox);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.keywordsBox);
            this.Controls.Add(this.keywordLabels);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NewsForm";
            this.ShowInTaskbar = false;
            this.Text = "News";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label keywordLabels;
        private TextBox keywordsBox;
        private Label categoryLabel;
        private ComboBox categoryBox;
        private Label countryLabel;
        private ComboBox countryBox;
        private Button cancelButton;
        private Button clearButton;
        private Button submitButton;
    }
}