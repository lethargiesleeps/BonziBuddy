using System.Diagnostics;
using BonzoBuddo.BonziAI.Speech;
using BonzoBuddo.Forms;
using BonzoBuddo.Helpers;
using DoubleAgent.AxControl;
using DoubleAgent.Control;
using DoubleAgent.Control.Native;
using Control = System.Windows.Forms.Control;

namespace BonzoBuddo;

/// <summary>
///     Primary form of Bonzi progrram
/// </summary>
public partial class BonziBuddyControlPanel : Form
{
    //TODO: Documentation

    private readonly AxControl _agent;
    private const string AcsPath = "C:\\agents\\Bonzi.acs";
    private const string AgentName = "Bonzi";
    private const string TtsId = "{CA141FD0-AC7F-11D1-97A3-006008273000}";
    private readonly Bonzi _bonzi;
    private readonly BonziHelper _helper;
    private readonly Control[] _disposableControls;
    private readonly Control[] _controls;
    private int _debugCounter;
    private bool _formDisplayedInit;
    private bool _formHiding;
    private UserInput _input;
    private CtlCommandEvent? _event;
    private CtlCommandEventHandler? _handler;
    /// <summary>
    ///     Constructor for Control Panel. Contains all instantiation and loading logic.
    ///     Determines if program has been used before, also sets visibility of all UI controls to be used.
    ///     Contains instantiation of main Bonzi object.
    /// </summary>
    public BonziBuddyControlPanel()
    {
        InitializeComponent();
        _bonzi = new Bonzi();
        _disposableControls = new Control[]
        {
            cityText,
            labelCity,
            nameText,
            labelName,
            submitButton
        };
        _controls = new Control[]
        {
            weatherButton,
            jokeButton,
            bonziLabel,
            factButton,
            insultButton,
            virusButton,
            newsButton,
            showHideButton,
            songButton,
            dictionaryButton,
            recipeButton,
            triviaButton,
            riddleButton,
            babyButton,
            mortgageButton
        };
        _agent = new AxControl();
        _agent.CreateControl();
        _agent.Characters.Load(AgentName, AcsPath);
        _agent.Characters[AgentName].TTSModeID = TtsId;
        _agent.Characters[AgentName].MoveTo(Convert.ToInt16(Screen.PrimaryScreen.Bounds.Right - 700),
            Convert.ToInt16(Screen.PrimaryScreen.Bounds.Bottom - 500), 500);
        _agent.Characters[AgentName].SetSize(250, 250);
        _agent.Characters[AgentName].Show();

        _helper = UiHelper.CreateCommandMenu(new BonziHelper(_agent, AgentName));
        _input = new UserInput(null);
        

        if (!_bonzi.Initialized)
        {
            UiHelper.ToggleControlVisibility(_controls, false);
            UiHelper.ToggleControlVisibility(_disposableControls, true);
            _bonzi.SetSpeechPattern(SpeechType.Greeting);
            _helper.Play("Greet");
            foreach (var s in _bonzi.Speak()!.GetPhraseList()!)
                _helper.Speak(s);
        }
        else
        {
            _agent.CtlCommand += agent_CtlCommand;
            this.Hide();
            _bonzi.SetSpeechPattern(SpeechType.Greeting);
            UiHelper.ToggleControlVisibility(_controls, true);
            UiHelper.ToggleControlVisibility(_disposableControls, false);
            _helper.Play("Wave");
            _helper.Speak(_bonzi.Speak()!.GetRandomPhrase());

            //If random phrase is specific, can maybe refactor to own helper class later.
            if (RandomNumberHelper.CurrentValue == 4)
                _helper.Play("Giggle");
        }

        


    }

    /// <summary>
    /// Fires relevant commands for when user click on item in command menu.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">CtlCommandEvent args, use EventArgs.Empty</param>
    private void agent_CtlCommand(object sender, CtlCommandEvent e)
    {
        switch (e.UserInput.Name)
        {
            case "Joke":
                jokeButton_Click(sender, EventArgs.Empty);
                break;
            case "Fact":
                factButton_Click(sender, EventArgs.Empty);
                break;
            case "Weather":
                weatherButton_Click(sender, EventArgs.Empty);
                break;
            case "News":
                newsButton_Click(sender, EventArgs.Empty);
                break;
            case "Dictionary":
                dictionaryButton_Click(sender, EventArgs.Empty);
                break;
            case "Random Word":
                randomWordButton_Click(sender, EventArgs.Empty);
                break;
            case "Show Panel":
                if (!_formDisplayedInit)
                {
                    Show();
                    _formDisplayedInit = true;
                    _helper.Speak(Phrases.Prompts(_bonzi.Data!.Name!)["OpenPanel"]);
                    _helper.Play("Idle1_7");
                }
                else
                {
                    if (_formHiding)
                    {
                        _helper.Stop();
                        _formHiding = false;
                        WindowState = FormWindowState.Normal;
                        _helper.Speak(Phrases.Prompts(_bonzi.Data!.Name!)["OpenPanel"]);
                        _helper.Play("Idle1_7");
                    }
                    else
                    {
                        _helper.Stop();
                        _formHiding = true;
                        WindowState = FormWindowState.Minimized;
                        _helper.Speak(Phrases.Prompts(_bonzi.Data!.Name!)["ClosePanel"]);
                        _helper.Play("Idle1_24");
                    }
                    Debug.WriteLine($"INIT: {_formDisplayedInit}\nCURRENT: {_formHiding}");
                }
                break;
            default:
                songButton_Click(sender, EventArgs.Empty);
                break;
        }
    }

    /// <summary>
    ///     Makes Bonzi tell a fact.
    /// </summary>
    /// <param name="sender">The fact button</param>
    /// <param name="e"></param>
    private void factButton_Click(object sender, EventArgs e)
    {
        _helper.Stop();
        _bonzi.SetSpeechPattern(SpeechType.Fact);
        _helper.Play("ReadLookUp");
        _helper.Play("ReadReturn");
        _helper.Speak(_bonzi.Speak()!.GetPhrase());
        _helper.Play("Explain2");
        _helper.Speak(_bonzi.Speak()!.GetRandomPhrase());
    }

    /// <summary>
    ///     Makes Bonzi tell a joke.
    /// </summary>
    /// <param name="sender">The joke button.</param>
    /// <param name="e"></param>
    private void jokeButton_Click(object sender, EventArgs e)
    {
        _helper.Stop();
        _bonzi.SetSpeechPattern(SpeechType.Joke);
        _helper.Speak(_bonzi.Speak()!.GetPhraseDictionary()!["First"]);
        RandomNumberHelper.SetIndex(5);
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
            case 4:
                _helper.Play("Surprised");
                break;
        }

        _helper.Speak(_bonzi.Speak()!.GetPhrase());
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
    }

    /// <summary>
    ///     Makes Bonzi get the weather and play different animations based on the result.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void weatherButton_Click(object sender, EventArgs e)
    {
        _helper.Stop();
        _helper.Speak(Phrases.Prompts(_bonzi.Data!.Name!)["GetWeather"]);
        _helper.Play("Think");
        try
        {
            _bonzi.SetSpeechPattern(SpeechType.Weather);
            _helper.Speak(_bonzi.Speak()!.GetPhrase());

            //If its really hot out, Bonzi puts on sunglasses.
            if (_bonzi.Data != null && _bonzi.Speak()!.GetPhrase().Equals(
                    Phrases.WeatherForecasts(_bonzi.Data.City!,
                        ApiHelper.GetWeather(_bonzi.Data.City!, WeatherUnits.Celcius)
                    )!["Hot"])
               )
                _helper.Play("Idle1_24");
        }
        catch (HttpRequestException ex)
        {
            Debug.WriteLine(ex.Message);
            _agent.Characters[AgentName].Speak(Phrases.ErrorMessages()["NoWeather"]);
        }
    }

    /// <summary>
    ///     Used only when program is launched for the first time.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void submitButton_Click(object sender, EventArgs e)
    {
        _helper.Stop();
        _bonzi.Temporary = nameText.Text;
        _bonzi.SetSpeechPattern(SpeechType.Greeting);
        _bonzi.Data!.Name = nameText.Text;
        _bonzi.Data.City = cityText.Text;
        _bonzi.Data.DateCreated = DateTime.Now;
        _bonzi.Data.LastAccessed = DateTime.Now;
        UiHelper.ToggleControlVisibility(_controls, true);
        UiHelper.ToggleControlVisibility(_disposableControls, false);
        _bonzi.Save();
        _bonzi.Data = _bonzi.Load();
        _helper.Speak(_bonzi.Speak()!.GetPhraseDictionary()!["Greeting"]);
        _helper.Speak(_bonzi.Speak()!.GetPhraseDictionary()!["FirstTime"]);
        _helper.Speak(_bonzi.Speak()!.GetPhraseDictionary()!["Intro"]);
        _helper.Speak(_bonzi.Speak()!.GetPhraseDictionary()!["Smart"]);
        _helper.Play("Confused");
    }

    /// <summary>
    ///     Insults Bonzi and makes him sad.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void insultButton_Click(object sender, EventArgs e)
    {
        _bonzi.SetSpeechPattern(SpeechType.Insulted);
        _agent.Characters[AgentName].Play("Sad");
        _agent.Characters[AgentName].Speak(_bonzi.Speak()!.GetRandomPhrase());
    }

    /// <summary>
    ///     Opens up the debug panel.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void bonziLabel_Click(object sender, EventArgs e)
    {
        _debugCounter++;
        if (_debugCounter != 5) return;
        _helper.Play("Sad");
        _helper.Speak("Just break me will you...");
        var debug = new BonziDebug(_helper);
        debug.Show(this);
        _debugCounter = 0;
    }

    private void showHideButton_Click(object sender, EventArgs e)
    {
        _helper.Stop();
        if (!_bonzi.IsHidden)
        {
            _bonzi.IsHidden = true;
            _bonzi.SetSpeechPattern(SpeechType.ShowHide);
            _helper.Play("Sad");
            _helper.Speak(_bonzi.Speak()!.GetRandomPhrase());
            _helper.Hide();
            showHideButton.Text = "Come back Bonzi!";
        }
        else
        {
            _bonzi.IsHidden = false;
            _bonzi.SetSpeechPattern(SpeechType.ShowHide);
            _helper.Show();
            _helper.Play("Greet");
            _helper.Speak(_bonzi.Speak()!.GetRandomPhrase());
            showHideButton.Text = "Go away Bonzi";
        }
    }

    private void songButton_Click(object sender, EventArgs e)
    {
        _helper.Speak("I'm afraid I can't do that just yet.");
    }

    private void newsButton_Click(object sender, EventArgs e)
    {
        _helper.Stop();

        _helper.Speak(Phrases.Prompts(_bonzi.Data!.Name!)["GetNews"]);
        _helper.Play("GestureUp");
        var news = new NewsForm(_helper, _bonzi);
        news.Show();
    }

    private void dictionaryButton_Click(object sender, EventArgs e)
    {
        _helper.Stop();
        var dictionary = new DictionaryForm(_helper, _bonzi);
        _helper.Speak(Phrases.Prompts(_bonzi.Data!.Name!)["GetDictionary"]);
        _helper.Play("Idle1_8");
        dictionary.Show();
    }

    

    private void randomWordButton_Click(object sender, EventArgs e)
    {
        _helper.Stop();
        var randomWord = new RandomWordForm(_helper, _bonzi);
        _helper.Speak(Phrases.Prompts(_bonzi.Data!.Name!)["PreRandomWord"]);
        _helper.Play("GestureUp");
        randomWord.Show();
    }
    
}

