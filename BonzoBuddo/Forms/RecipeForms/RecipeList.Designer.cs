namespace BonzoBuddo.Forms.RecipeForms
{
    partial class RecipeList
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
            this.recipeListBox = new System.Windows.Forms.ListBox();
            this.viewButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // recipeListBox
            // 
            this.recipeListBox.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.recipeListBox.FormattingEnabled = true;
            this.recipeListBox.ItemHeight = 31;
            this.recipeListBox.Location = new System.Drawing.Point(13, 14);
            this.recipeListBox.Margin = new System.Windows.Forms.Padding(4);
            this.recipeListBox.Name = "recipeListBox";
            this.recipeListBox.Size = new System.Drawing.Size(445, 686);
            this.recipeListBox.TabIndex = 0;
            this.recipeListBox.SelectedIndexChanged += new System.EventHandler(this.recipeListBox_SelectedIndexChanged);
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(468, 14);
            this.viewButton.Margin = new System.Windows.Forms.Padding(4);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(153, 81);
            this.viewButton.TabIndex = 1;
            this.viewButton.Text = "View Info";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(468, 103);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(153, 81);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // RecipeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 715);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.viewButton);
            this.Controls.Add(this.recipeListBox);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RecipeList";
            this.ShowInTaskbar = false;
            this.Text = "Recipes";
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox recipeListBox;
        private Button viewButton;
        private Button cancelButton;
    }
}