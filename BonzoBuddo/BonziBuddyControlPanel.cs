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
using BonzoBuddo.BonziAI;
using BonzoBuddo.BonziAI.Interfaces;
using BonzoBuddo.BonziAI.Speech;
using BonzoBuddo.BonziAI.Tools;
using DoubleAgent.AxControl;
using DoubleAgent.Control;

namespace BonzoBuddo
{
    public partial class BonziBuddyControlPanel : Form
    {
        private Bonzi _bonzi;
        private DoubleAgent.AxControl.AxControl _agent;
        private string _acsPath = "C:\\agents\\Bonzi.acs";
        private string _agentName = "Bonzi";
        private string _ttsID = "{CA141FD0-AC7F-11D1-97A3-006008273000}";
        public BonziBuddyControlPanel()
        {
            InitializeComponent();
            _bonzi = new Bonzi();
            _agent = new AxControl();
            _agent.CreateControl();
            _agent.Characters.Load(_agentName, _acsPath);
            foreach(var a in _agent.Characters[_agentName].Animations)
                Dev.Log(a);
            _agent.Characters[_agentName].TTSModeID = _ttsID;
            _agent.Characters[_agentName].MoveTo(Convert.ToInt16(Screen.PrimaryScreen.Bounds.Right - 700),
                Convert.ToInt16(Screen.PrimaryScreen.Bounds.Bottom - 500), 500);
            _agent.Characters[_agentName].SetSize(250, 250);
            _agent.Characters[_agentName].Show();
            if (!_bonzi.GetInitializationStatus())
            {
                
                _agent.Characters[_agentName].Play("Wave");
                _agent.Characters[_agentName].Speak(_bonzi.Greet()[0]);
                _agent.Characters[_agentName].Speak(_bonzi.Greet()[1]);
                _agent.Characters[_agentName].Play("Greet");
                _agent.Characters[_agentName].Speak(_bonzi.Greet()[2]);
                _agent.Characters[_agentName].Speak(_bonzi.Greet()[3]);
                GetName form = new GetName(this);
                form.Show();
            }
            else
            {
                
                
                _agent.Characters[_agentName].Play("Wave");
                _agent.Characters[_agentName].Speak(_bonzi.Greet()[0]);
                
            }
            

        }

        private void jokeButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int selection = rnd.Next(1,51);

            if (selection == 1)
            {
                _bonzi.PlayBadJoke(MessageBox.Show("You have been infected with numerous malware.", "Bonzi Buddy",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error), _agent.Characters[_agentName]);
                
            }
            else
            {
                _bonzi.SetSpeechPattern(SpeechType.Joke);
                _agent.Characters[_agentName].Play("Read");
                _agent.Characters[_agentName].Speak(_bonzi.GetPhrase());
            }

            
        }

        private void weatherButton_Click(object sender, EventArgs e)
        {
            
            
            _bonzi.SetSpeechPattern(SpeechType.Weather);
            _agent.Characters[_agentName].Speak(Phrases.AsyncWarning());
            _agent.Characters[_agentName].Play("Think");
            if (string.IsNullOrWhiteSpace(cityText.Text) || string.IsNullOrEmpty(cityText.Text))
            {
                
                _agent.Characters[_agentName].GestureAt(Convert.ToInt16(MousePosition.X), Convert.ToInt16(BonziBuddyControlPanel.MousePosition.Y));


            }
                
            
            _agent.Characters[_agentName].Speak(_bonzi.GetCurrentWeather(cityText.Text));
            cityText.Text = "";
        }

        public Bonzi GetBonzi() => _bonzi;
        public AxControl GetAgent() => _agent;
    }
}
