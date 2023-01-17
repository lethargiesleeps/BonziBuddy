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
        private BonziHelper _helper;
        private System.Windows.Forms.Control[] _disposableControls;
        private System.Windows.Forms.Control[] _controls;

        private int _debugCounter;
        #endregion

        /// <summary>
        /// Constructor for Control Panel. Contains all instantiation and loading logic.
        /// Determines if program has been used before, also sets visibility of all UI controls to be used.
        /// Contains instantiation of main Bonzi object.
        /// </summary>
        public BonziBuddyControlPanel()
        {
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
                bonziLabel,
                factButton,
                insultButton,
                virusButton,
                newsButton,

            };
            _agent = new AxControl();
            _agent.CreateControl();
            _agent.Characters.Load(_agentName, _acsPath);
            _agent.Characters[_agentName].TTSModeID = _ttsID;
            _agent.Characters[_agentName].MoveTo(Convert.ToInt16(Screen.PrimaryScreen.Bounds.Right - 700),
                Convert.ToInt16(Screen.PrimaryScreen.Bounds.Bottom - 500), 500);
            _agent.Characters[_agentName].SetSize(250, 250);
            _agent.Characters[_agentName].Show();
            _helper = new BonziHelper(_agent, _agentName);
            
            if (!_bonzi.Initialized)
            {
                UIHelper.ToggleControlVisibility(_controls, false);
                UIHelper.ToggleControlVisibility(_disposableControls, true);
                _bonzi.SetSpeechPattern(SpeechType.Greeting);
                _helper.Play("Greet");
                foreach(var s in _bonzi.Speak().GetPhraseList())
                    _helper.Speak(s);
            }
            else
            {
                _bonzi.SetSpeechPattern(SpeechType.Greeting);
                UIHelper.ToggleControlVisibility(_controls, true);
                UIHelper.ToggleControlVisibility(_disposableControls, false);
                _helper.Play("Wave");
                _helper.Speak(_bonzi.Speak().GetRandomPhrase());

                //If random phrase is specific, can maybe refactor to own helper class later.
                if(RandomNumberHelper.CurrentValue == 4)
                    _helper.Play("Giggle");

            }

        }

        /// <summary>
        /// Makes Bonzi tell a joke.
        /// </summary>
        /// <param name="sender">The joke button.</param>
        /// <param name="e"></param>
        private void jokeButton_Click(object sender, EventArgs e)
        {
            _bonzi.SetSpeechPattern(SpeechType.Joke);
            _helper.Speak(Phrases.JokeExtras()["First"]);
            RandomNumberHelper.SetIndex(4);
            switch (RandomNumberHelper.CurrentValue)
            {
                case 0:
                    _helper.Play("Explain");
                    break;
                case 1:
                    _helper.Play("Explain2");
                    break;
                case 2:
                    _helper.Play("Explain3");
                    break;
                case 3:
                    _helper.Play("Explain4");
                    break;
            }
            _helper.Speak(_bonzi.Speak().GetPhrase());
            RandomNumberHelper.SetIndex(2);
            switch (RandomNumberHelper.CurrentValue)
            {
                case 0:
                    _helper.Play("Giggle");
                    break;
                case 1:
                    _helper.Play("PleasedSoft");
                    break;
            }
            //_helper.Speak(Phrases.JokeExtras()["Last"]);
        }

        /// <summary>
        /// Makes Bonzi get the weather and play different animations based on the result.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void weatherButton_Click(object sender, EventArgs e)
        {
            _helper.Speak(Phrases.Prompts()["GetWeather"]);
            _helper.Play("Think");
            //TODO: Refactor try catches for weather api calls so if HTTP request doesnt work Bonzi says a message instead of app throwing exception.
            try
            {
                _bonzi.SetSpeechPattern(SpeechType.Weather);
                _helper.Speak(_bonzi.Speak().GetPhrase());

                //If its really hot out, Bonzi puts on sunglasses.
                if(_bonzi.Data != null && _bonzi.Speak().GetPhrase().Equals(
                       Phrases.WeatherForecasts(_bonzi.Data.City, 
                           ApiHelper.GetWeather(_bonzi.Data.City, WeatherUnits.Celcius)
                       )["Hot"])
                   )
                    _helper.Play("Idle1_24");
               
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine(ex.Message);
                _agent.Characters[_agentName].Speak(Phrases.ErrorMessages()["NoWeather"]);

            }

        }

        /// <summary>
        /// Used only when program is launched for the first time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            _bonzi.Data = _bonzi.Load();
            _helper.Speak(_bonzi.Speak().GetPhraseDictionary()["Greeting"]);
            _helper.Speak(_bonzi.Speak().GetPhraseDictionary()["FirstTime"]);
            _helper.Speak(_bonzi.Speak().GetPhraseDictionary()["Intro"]);
            _helper.Speak(_bonzi.Speak().GetPhraseDictionary()["Smart"]);
            _helper.Play("Confused");


        }

        /// <summary>
        /// Insults Bonzi and makes him sad.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insultButton_Click(object sender, EventArgs e)
        {
            _bonzi.SetSpeechPattern(SpeechType.Insulted);
            _agent.Characters[_agentName].Play("Sad");
            _agent.Characters[_agentName].Speak(_bonzi.Speak().GetRandomPhrase());
        }

        /// <summary>
        /// Opens up the debug panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bonziLabel_Click(object sender, EventArgs e)
        {
            _debugCounter++;
            if (_debugCounter == 5)
            {
                _helper.Play("Sad");
                _helper.Speak("Just break me will you...");
                BonziDebug debug = new BonziDebug(_helper);
                debug.Show(this);
                _debugCounter = 0;
            }
        }

        private void showHideButton_Click(object sender, EventArgs e)
        {
            if (!_bonzi.IsHidden)
            {
                _helper.Hide();
                showHideButton.Text = "Come back Bonzi!";
                _bonzi.IsHidden = true;
            }
            else
            {
                _helper.Show();
                showHideButton.Text = "Go away Bonzi";
                _bonzi.IsHidden = false;
            }
        }
    }
}
