using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BonzoBuddo.Helpers;

namespace BonzoBuddo.Forms.RecipeForms
{
    public partial class RecipeList : Form
    {
        private readonly BonziHelper _helper;
        private readonly Bonzi _bonzi;
        public RecipeList(BonziHelper helper, Bonzi bonzi)
        {
            InitializeComponent();
            _helper = helper;
            _bonzi = bonzi;
            AddRecipeTitles();
            
        }

        private void AddRecipeTitles()
        {
            if (RecipeHelper.Titles is null) return;
            foreach (var r in RecipeHelper.Titles)
                recipeListBox.Items.Add(r);
        }

        private void recipeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(recipeListBox.SelectedItem);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();

        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            var index = recipeListBox.SelectedIndex;
            var recipeDisplay = new RecipeDisplay(
                RecipeHelper.Titles![index],
                RecipeHelper.Ingredients![index],
                RecipeHelper.Servings![index],
                RecipeHelper.Ingredients[index],
                _helper,
                _bonzi);
        }
    }
}
