using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BonzoBuddo.Helpers;

namespace BonzoBuddo
{
    public partial class BonziDebug : Form
    {
        private BonziHelper _helper;
        public BonziDebug(BonziHelper helper)
        {
            InitializeComponent();
            _helper = helper;
            var x = _helper.Agent.Characters[_helper.AgentName];
            ListAnimations();
            ListDescription();
            textBox1.Text += x.ExtraData;
            textBox1.Text += $"\n{x.Name}";
        }

        public void ListAnimations()
        {
            foreach (var s in _helper.Agent.Characters[_helper.AgentName].Animations)
            {
                animationsText.Text += $"{s}\n";
            }
        }

        public void ListDescription()
        {
            descText.Text = _helper.Agent.Characters[_helper.AgentName].Description;
        }

        private void BonziDebug_Load(object sender, EventArgs e)
        {

        }

        private void BonziDebug_Shown(object sender, EventArgs e)
        {
            _helper.Speak("Torment me daddy");
            _helper.Play("Confused");
        }
    }
}
