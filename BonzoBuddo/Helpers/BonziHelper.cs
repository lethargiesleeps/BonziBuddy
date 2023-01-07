namespace BonzoBuddo.Helpers;

/// <summary>
/// This class simplifies calling Double Agent requests. Needs to be instantiated.
/// </summary>
public class BonziHelper
{
    public DoubleAgent.AxControl.AxControl Agent { get; private set; }
    public string AgentName { get; private set; }
    public BonziHelper(DoubleAgent.AxControl.AxControl agent, string agentName)
    {
        Agent = agent;
        AgentName = agentName;
    }

    public void Speak(string phrase)
    {
        Agent.Characters[AgentName].Speak(phrase);
    }

    public void Play(string animation)
    {
        Agent.Characters[AgentName].Play(animation);
    }

    public void ChangeSpeed()
    {
        
    }
}