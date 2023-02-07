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

    public partial class RecipeDisplay : Form
    {

        private readonly BonziHelper _helper;
        private readonly Bonzi _bonzi;
        public RecipeDisplay(string title, string ingredients, string servings, string instructions, BonziHelper helper, Bonzi bonzi)
        {
            InitializeComponent();
            _helper = helper;
            _bonzi = bonzi;
            Text = title;
            Debug.WriteLine(title);
            Debug.WriteLine(ingredients);
            Debug.WriteLine(servings);
            Debug.WriteLine(instructions);
            _helper.Stop();
            _helper.Speak($"Here is how you make {title}.");

            
            
        }

        
    }
}
