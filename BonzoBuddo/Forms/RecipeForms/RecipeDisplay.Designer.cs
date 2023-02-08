namespace BonzoBuddo.Forms.RecipeForms
{
    partial class RecipeDisplay
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.servingLabel = new System.Windows.Forms.Label();
            this.ingredientInstructionTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ingredientText = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cancelButton = new System.Windows.Forms.Button();
            this.instructionText = new System.Windows.Forms.TextBox();
            this.ingredientInstructionTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(75, 31);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "label1";
            // 
            // servingLabel
            // 
            this.servingLabel.AutoSize = true;
            this.servingLabel.Location = new System.Drawing.Point(12, 50);
            this.servingLabel.Name = "servingLabel";
            this.servingLabel.Size = new System.Drawing.Size(57, 24);
            this.servingLabel.TabIndex = 1;
            this.servingLabel.Text = "label1";
            // 
            // ingredientInstructionTab
            // 
            this.ingredientInstructionTab.Controls.Add(this.tabPage1);
            this.ingredientInstructionTab.Controls.Add(this.tabPage2);
            this.ingredientInstructionTab.Location = new System.Drawing.Point(12, 95);
            this.ingredientInstructionTab.Name = "ingredientInstructionTab";
            this.ingredientInstructionTab.SelectedIndex = 0;
            this.ingredientInstructionTab.Size = new System.Drawing.Size(871, 573);
            this.ingredientInstructionTab.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ingredientText);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(863, 536);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ingredientText
            // 
            this.ingredientText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ingredientText.Location = new System.Drawing.Point(6, 6);
            this.ingredientText.Multiline = true;
            this.ingredientText.Name = "ingredientText";
            this.ingredientText.ReadOnly = true;
            this.ingredientText.Size = new System.Drawing.Size(851, 524);
            this.ingredientText.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.instructionText);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(863, 536);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(747, 674);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(132, 68);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // instructionText
            // 
            this.instructionText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.instructionText.Location = new System.Drawing.Point(6, 6);
            this.instructionText.Multiline = true;
            this.instructionText.Name = "instructionText";
            this.instructionText.ReadOnly = true;
            this.instructionText.Size = new System.Drawing.Size(851, 524);
            this.instructionText.TabIndex = 0;
            // 
            // RecipeDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 757);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.ingredientInstructionTab);
            this.Controls.Add(this.servingLabel);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RecipeDisplay";
            this.ShowInTaskbar = false;
            this.Text = "RecipeDisplay";
            this.ingredientInstructionTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label titleLabel;
        private Label servingLabel;
        private TabControl ingredientInstructionTab;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox ingredientText;
        private Button cancelButton;
        private TextBox instructionText;
    }
}