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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BonziBuddyControlPanel));
            this.jokeButton = new System.Windows.Forms.Button();
            this.weatherButton = new System.Windows.Forms.Button();
            this.cityText = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.bonziLabel = new System.Windows.Forms.Label();
            this.insultButton = new System.Windows.Forms.Button();
            this.factButton = new System.Windows.Forms.Button();
            this.newsButton = new System.Windows.Forms.Button();
            this.songButton = new System.Windows.Forms.Button();
            this.virusButton = new System.Windows.Forms.Button();
            this.showHideButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // jokeButton
            // 
            this.jokeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.jokeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.jokeButton.Location = new System.Drawing.Point(11, 154);
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
            this.weatherButton.Location = new System.Drawing.Point(198, 154);
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
            this.cityText.Location = new System.Drawing.Point(116, 52);
            this.cityText.Name = "cityText";
            this.cityText.PlaceholderText = "City";
            this.cityText.Size = new System.Drawing.Size(258, 31);
            this.cityText.TabIndex = 101;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(61, 24);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "Name:";
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(12, 55);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(46, 24);
            this.labelCity.TabIndex = 4;
            this.labelCity.Text = "City:";
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(116, 12);
            this.nameText.Name = "nameText";
            this.nameText.PlaceholderText = "City";
            this.nameText.Size = new System.Drawing.Size(258, 31);
            this.nameText.TabIndex = 100;
            this.nameText.Text = "Name";
            // 
            // submitButton
            // 
            this.submitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.submitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.submitButton.Location = new System.Drawing.Point(400, 12);
            this.submitButton.Margin = new System.Windows.Forms.Padding(2);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(153, 71);
            this.submitButton.TabIndex = 102;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // bonziLabel
            // 
            this.bonziLabel.AutoSize = true;
            this.bonziLabel.BackColor = System.Drawing.Color.Transparent;
            this.bonziLabel.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.bonziLabel.Location = new System.Drawing.Point(179, 25);
            this.bonziLabel.Name = "bonziLabel";
            this.bonziLabel.Size = new System.Drawing.Size(374, 84);
            this.bonziLabel.TabIndex = 7;
            this.bonziLabel.Text = "Bonzi Buddy";
            this.bonziLabel.Visible = false;
            this.bonziLabel.Click += new System.EventHandler(this.bonziLabel_Click);
            // 
            // insultButton
            // 
            this.insultButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.insultButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.insultButton.Location = new System.Drawing.Point(572, 154);
            this.insultButton.Margin = new System.Windows.Forms.Padding(2);
            this.insultButton.Name = "insultButton";
            this.insultButton.Size = new System.Drawing.Size(153, 63);
            this.insultButton.TabIndex = 103;
            this.insultButton.Text = "I hate you Bonzi!";
            this.insultButton.UseVisualStyleBackColor = true;
            this.insultButton.Click += new System.EventHandler(this.insultButton_Click);
            // 
            // factButton
            // 
            this.factButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.factButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.factButton.Location = new System.Drawing.Point(385, 154);
            this.factButton.Margin = new System.Windows.Forms.Padding(2);
            this.factButton.Name = "factButton";
            this.factButton.Size = new System.Drawing.Size(153, 63);
            this.factButton.TabIndex = 104;
            this.factButton.Text = "Tell me a fact";
            this.factButton.UseVisualStyleBackColor = true;
            // 
            // newsButton
            // 
            this.newsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.newsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.newsButton.Location = new System.Drawing.Point(11, 265);
            this.newsButton.Margin = new System.Windows.Forms.Padding(2);
            this.newsButton.Name = "newsButton";
            this.newsButton.Size = new System.Drawing.Size(153, 63);
            this.newsButton.TabIndex = 105;
            this.newsButton.Text = "What\'s the news Bonzi?";
            this.newsButton.UseVisualStyleBackColor = true;
            // 
            // songButton
            // 
            this.songButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.songButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.songButton.Location = new System.Drawing.Point(198, 265);
            this.songButton.Margin = new System.Windows.Forms.Padding(2);
            this.songButton.Name = "songButton";
            this.songButton.Size = new System.Drawing.Size(153, 63);
            this.songButton.TabIndex = 106;
            this.songButton.Text = "Sing me a song";
            this.songButton.UseVisualStyleBackColor = true;
            // 
            // virusButton
            // 
            this.virusButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.virusButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.virusButton.Location = new System.Drawing.Point(385, 265);
            this.virusButton.Margin = new System.Windows.Forms.Padding(2);
            this.virusButton.Name = "virusButton";
            this.virusButton.Size = new System.Drawing.Size(153, 63);
            this.virusButton.TabIndex = 107;
            this.virusButton.Text = "Are you spyware?";
            this.virusButton.UseVisualStyleBackColor = true;
            // 
            // showHideButton
            // 
            this.showHideButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.showHideButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.showHideButton.Location = new System.Drawing.Point(572, 265);
            this.showHideButton.Margin = new System.Windows.Forms.Padding(2);
            this.showHideButton.Name = "showHideButton";
            this.showHideButton.Size = new System.Drawing.Size(153, 63);
            this.showHideButton.TabIndex = 108;
            this.showHideButton.Text = "Go away Bonzi";
            this.showHideButton.UseVisualStyleBackColor = true;
            this.showHideButton.Click += new System.EventHandler(this.showHideButton_Click);
            // 
            // BonziBuddyControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(738, 873);
            this.Controls.Add(this.showHideButton);
            this.Controls.Add(this.virusButton);
            this.Controls.Add(this.songButton);
            this.Controls.Add(this.newsButton);
            this.Controls.Add(this.factButton);
            this.Controls.Add(this.insultButton);
            this.Controls.Add(this.bonziLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.labelName);
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
        private Label labelName;
        private Label labelCity;
        private TextBox nameText;
        private Button submitButton;
        private Label bonziLabel;
        private Button insultButton;
        private Button factButton;
        private Button newsButton;
        private Button songButton;
        private Button virusButton;
        private Button showHideButton;
    }
}