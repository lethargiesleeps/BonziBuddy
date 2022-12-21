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
using BonzoBuddo.BonziAI.Tools;
using DoubleAgent.AxControl;

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
                Debug.WriteLine(a);

            _agent.Characters[_agentName].TTSModeID = _ttsID;
            _agent.Characters[_agentName].MoveTo(Convert.ToInt16(Screen.PrimaryScreen.Bounds.Right - 700),
                Convert.ToInt16(Screen.PrimaryScreen.Bounds.Bottom - 500), 500);
            _agent.Characters[_agentName].SetSize(250, 250);
            _agent.Characters[_agentName].Show();
            

        }

        private void jokeButton_Click(object sender, EventArgs e)
        {
            _bonzi.SetSpeechPattern(SpeechType.Joke);
            _agent.Characters[_agentName].Play("Read");
            _agent.Characters[_agentName].Speak(_bonzi.GetPhrase());
        }

        private void weatherButton_Click(object sender, EventArgs e)
        {
            
            var city = cityText.Text;
            if (string.IsNullOrEmpty(city) || string.IsNullOrWhiteSpace(city))
                city = "New York City";
            _bonzi.SetSpeechPattern(SpeechType.Weather);
            
            _agent.Characters[_agentName].Speak(Phrases.AsyncWarning());
            _agent.Characters[_agentName].Play("Think");
            _agent.Characters[_agentName].Speak(_bonzi.GetCurrentWeather(city));
            cityText.Text = "";
        }
    }
}
