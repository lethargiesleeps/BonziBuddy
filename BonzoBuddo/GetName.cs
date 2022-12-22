using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BonzoBuddo.BonziAI;
using BonzoBuddo.BonziAI.Tools;

namespace BonzoBuddo
{
    public partial class GetName : Form
    {
        private BonziBuddyControlPanel _cp;

        public GetName(BonziBuddyControlPanel cp)
        {
            InitializeComponent();
            _cp = cp;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            _cp.GetBonzi().GetBonziData().Name = nameText.Text;
            
            _cp.GetAgent().Characters["Bonzi"].Speak(Phrases.BonziIntro(_cp.GetBonzi().GetBonziData().Name)["Greeting"]);
            _cp.GetAgent().Characters["Bonzi"].Speak(Phrases.BonziIntro(_cp.GetBonzi().GetBonziData().Name)["FirstTime"]);
            _cp.GetAgent().Characters["Bonzi"].Speak(Phrases.BonziIntro(_cp.GetBonzi().GetBonziData().Name)["Intro"]);
            _cp.GetAgent().Characters["Bonzi"].Play("Confused");
            
            _cp.GetAgent().Characters["Bonzi"].Speak(Phrases.BonziIntro(_cp.GetBonzi().GetBonziData().Name)["Smart"]);
            _cp.GetAgent().Characters["Bonzi"].Play("Idle1_1");
            this.Close();
        }
    }
}
