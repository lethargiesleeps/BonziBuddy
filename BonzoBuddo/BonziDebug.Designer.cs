namespace BonzoBuddo
{
    partial class BonziDebug
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
            this.animationsText = new System.Windows.Forms.TextBox();
            this.descText = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // animationsText
            // 
            this.animationsText.Location = new System.Drawing.Point(11, 54);
            this.animationsText.Multiline = true;
            this.animationsText.Name = "animationsText";
            this.animationsText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.animationsText.Size = new System.Drawing.Size(318, 429);
            this.animationsText.TabIndex = 0;
            // 
            // descText
            // 
            this.descText.Location = new System.Drawing.Point(351, 54);
            this.descText.Name = "descText";
            this.descText.Size = new System.Drawing.Size(481, 27);
            this.descText.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(351, 112);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(481, 371);
            this.textBox1.TabIndex = 2;
            // 
            // BonziDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 808);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.descText);
            this.Controls.Add(this.animationsText);
            this.Name = "BonziDebug";
            this.Text = "BonziDebug";
            this.Load += new System.EventHandler(this.BonziDebug_Load);
            this.Shown += new System.EventHandler(this.BonziDebug_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox animationsText;
        private TextBox descText;
        private TextBox textBox1;
    }
}