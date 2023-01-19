using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonzoBuddo.Forms
{
    public partial class Article : Form
    {
        public Article(string title, string summary)
        {
            InitializeComponent();
            titleLabel.Text = title;
            summaryBox.Text = summary;
        }
    }
}
