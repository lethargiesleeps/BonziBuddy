namespace BonzoBuddo
{
    partial class BonziBuddyControlPanel
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
            this.jokeButton = new System.Windows.Forms.Button();
            this.weatherButton = new System.Windows.Forms.Button();
            this.cityText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // jokeButton
            // 
            this.jokeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.jokeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.jokeButton.Location = new System.Drawing.Point(10, 10);
            this.jokeButton.Margin = new System.Windows.Forms.Padding(2);
            this.jokeButton.Name = "jokeButton";
            this.jokeButton.Size = new System.Drawing.Size(153, 63);
            this.jokeButton.TabIndex = 0;
            this.jokeButton.Text = "Tell me a joke";
            this.jokeButton.UseVisualStyleBackColor = true;
            this.jokeButton.Click += new System.EventHandler(this.jokeButton_Click);
            // 
            // weatherButton
            // 
            this.weatherButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.weatherButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.weatherButton.Location = new System.Drawing.Point(10, 77);
            this.weatherButton.Margin = new System.Windows.Forms.Padding(2);
            this.weatherButton.Name = "weatherButton";
            this.weatherButton.Size = new System.Drawing.Size(153, 63);
            this.weatherButton.TabIndex = 1;
            this.weatherButton.Text = "What\'s the weather?";
            this.weatherButton.UseVisualStyleBackColor = true;
            this.weatherButton.Click += new System.EventHandler(this.weatherButton_Click);
            // 
            // cityText
            // 
            this.cityText.Location = new System.Drawing.Point(168, 109);
            this.cityText.Name = "cityText";
            this.cityText.PlaceholderText = "City";
            this.cityText.Size = new System.Drawing.Size(258, 31);
            this.cityText.TabIndex = 2;
            // 
            // BonziBuddyControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 873);
            this.Controls.Add(this.cityText);
            this.Controls.Add(this.weatherButton);
            this.Controls.Add(this.jokeButton);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "BonziBuddyControlPanel";
            this.Text = "Bonzi Buddy Control Panel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button jokeButton;
        private Button weatherButton;
        private TextBox cityText;
    }
}