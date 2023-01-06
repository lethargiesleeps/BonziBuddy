using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using BonzoBuddo.BonziAI.Speech;
using BonzoBuddo.Helpers;
using DoubleAgent.AxControl;
using DoubleAgent.Control;

namespace BonzoBuddo
{
    /// <summary>
    /// Primary form of Bonzi progrram
    /// </summary>
    public partial class BonziBuddyControlPanel : Form
    {

        #region PrivateFields

        private DoubleAgent.AxControl.AxControl _agent;
        private string _acsPath = "C:\\agents\\Bonzi.acs";
        private string _agentName = "Bonzi";
        private string _ttsID = "{CA141FD0-AC7F-11D1-97A3-006008273000}";
        private Bonzi _bonzi;
        private System.Windows.Forms.Control[] _disposableControls;
        private System.Windows.Forms.Control[] _controls;

        #endregion

        /// <summary>
        /// Constructor for Control Panel. Contains all instantiation and loading logic.
        /// </summary>
        public BonziBuddyControlPanel()
        {

            //TODO: 2. If they don't create them, then greet user and make them go through registration
            //TODO: 3. If they do, load user data from file, then greet user
            //TODO: 4. Jokes
            //TODO: 5. Facts
            //TODO: 6. Weather
            //TODO: 7. XML comments

            InitializeComponent();
            _bonzi = new Bonzi();
            _disposableControls = new System.Windows.Forms.Control[]
            {
                cityText,
                labelCity,
                nameText,
                labelName,
                submitButton
            };
            _controls = new System.Windows.Forms.Control[]
            {
                weatherButton,
                jokeButton,
                bonziLabel
            };
            _agent = new AxControl();
            _agent.CreateControl();
            _agent.Characters.Load(_agentName, _acsPath);
            _agent.Characters[_agentName].TTSModeID = _ttsID;
            _agent.Characters[_agentName].MoveTo(Convert.ToInt16(Screen.PrimaryScreen.Bounds.Right - 700),
                Convert.ToInt16(Screen.PrimaryScreen.Bounds.Bottom - 500), 500);
            _agent.Characters[_agentName].SetSize(250, 250);
            _agent.Characters[_agentName].Show();
            
            if (!_bonzi.Initialized)
            {
                UIHelper.ToggleControlVisibility(_controls, false);
                UIHelper.ToggleControlVisibility(_disposableControls, true);
                _bonzi.SetSpeechPattern(SpeechType.Greeting);
                _agent.Characters[_agentName].Play("Greet");
                foreach(var s in _bonzi.Speak().GetPhraseList())
                    _agent.Characters[_agentName].Speak(s);
                

            }
            else
            {
                _bonzi.SetSpeechPattern(SpeechType.Greeting);
                UIHelper.ToggleControlVisibility(_controls, true);
                UIHelper.ToggleControlVisibility(_disposableControls, false);
                _agent.Characters[_agentName].Play("Wave");
                _agent.Characters[_agentName].Speak(_bonzi.Speak().GetRandomPhrase());
                if(RandomNumberHelper.CurrentValue == 4)
                    _agent.Characters[_agentName].Play("Giggle");

            }

        }

        private void jokeButton_Click(object sender, EventArgs e)
        {

        }

        private void weatherButton_Click(object sender, EventArgs e)
        {
            _agent.Characters[_agentName].Speak(Phrases.Prompts()["GetWeather"]);
            _agent.Characters[_agentName].Play("Think");
            try
            {
                _bonzi.SetSpeechPattern(SpeechType.Weather);
                
                _agent.Characters[_agentName].Speak(_bonzi.Speak().GetPhrase());
                if(_bonzi.Speak().GetPhrase().Equals(Phrases.WeatherForecasts(_bonzi.Data.City, ApiHelper.GetWeather(_bonzi.Data.City, WeatherUnits.Celcius))["Hot"]))
                    _agent.Characters[_agentName].Play("Idle1_24");
                else if(_bonzi.Speak().GetPhrase().Equals(Phrases.WeatherForecasts(_bonzi.Data.City, ApiHelper.GetWeather(_bonzi.Data.City, WeatherUnits.Celcius))["Cold"]))
                    _agent.Characters[_agentName].Play("Confused");

            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine(ex.Message);
                _agent.Characters[_agentName].Speak(Phrases.ErrorMessages()["NoWeather"]);

            }

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            _bonzi.Temporary = nameText.Text;
            _bonzi.SetSpeechPattern(SpeechType.Greeting);
            _bonzi.Data.Name = nameText.Text;
            _bonzi.Data.City = cityText.Text;
            _bonzi.Data.DateCreated = DateTime.Now;
            _bonzi.Data.LastAccessed = DateTime.Now;
            
            UIHelper.ToggleControlVisibility(_controls, true);
            UIHelper.ToggleControlVisibility(_disposableControls, false);
            _bonzi.Save();
            Thread.Sleep(100);
            _agent.Characters[_agentName].Speak(_bonzi.Speak().GetPhraseDictionary()["Greeting"]);
            _agent.Characters[_agentName].Speak(_bonzi.Speak().GetPhraseDictionary()["FirstTime"]);
            _agent.Characters[_agentName].Speak(_bonzi.Speak().GetPhraseDictionary()["Intro"]);
            _agent.Characters[_agentName].Speak(_bonzi.Speak().GetPhraseDictionary()["Smart"]);
            _agent.Characters[_agentName].Play("Giggle");


        }

        private void insultButton_Click(object sender, EventArgs e)
        {
            
            _bonzi.SetSpeechPattern(SpeechType.Insulted);
            _agent.Characters[_agentName].Play("Sad");
            _agent.Characters[_agentName].Speak(_bonzi.Speak().GetRandomPhrase());

        }
    }
}
