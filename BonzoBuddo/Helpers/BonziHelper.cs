namespace BonzoBuddo.Helpers;

/// <summary>
/// This class simplifies calling Double Agent requests. Needs to be instantiated.
/// </summary>
public class BonziHelper
{
    public DoubleAgent.AxControl.AxControl Agent { get; private set; }
    public string AgentName { get; private set; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="agent">AxControl from double agent representing the MS Agent.</param>
    /// <param name="agentName">Name of agent.</param>
    public BonziHelper(DoubleAgent.AxControl.AxControl agent, string agentName)
    {
        Agent = agent;
        AgentName = agentName;
    }

    /// <summary>
    /// Makes agent speak.
    /// </summary>
    /// <param name="phrase">The phrase to be spoken.</param>
    public void Speak(string phrase)
    {
        Agent.Characters[AgentName].Speak(phrase);
    }

    /// <summary>
    /// Makes agent play an animation.
    /// </summary>
    /// <param name="animation">The name of the animation that is to be played.</param>
    public void Play(string animation)
    {
        Agent.Characters[AgentName].Play(animation);
    }

    public void Show()
    {
        Agent.Characters[AgentName].Show();
    }

    public void Hide()
    {
        Agent.Characters[AgentName].Hide();
    }
    public void Sing()
    {
        
    }

    public void ChangeSpeed()
    {
        
    }
}