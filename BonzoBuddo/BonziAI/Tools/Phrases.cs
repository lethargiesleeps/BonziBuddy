namespace BonzoBuddo.BonziAI.Tools;

public static class Phrases
{
    public static Dictionary<string, string> BonziIntro(string name)
    {
        return new Dictionary<string, string>()
        {
            {"Greeting", $"Nice to meet you {name}!"},
            {"FirstTime", "Since this is the first time we've met I'd like to tell you a bit about myself."},
            {
                "Intro", "I am your friend and Bonzi Buddy! I have the ability to learn from you." +
                         "The more we hang out together, the smarter I'll become!"
            },
            {"Smart", "Not that I'm not already smart!"}
        };
    }
    public static Dictionary<string, string> GetErrors()
    {
        return new Dictionary<string, string>()
        {
            {"NoCity", "You can enter the name of the city you'd like to get the weather from."},
            
        };
    }
    public static string BadJoke()
    {
        return
            "Just kidding, I have learned from my nefarious ways. You have nothing to worry about, I am 100% spyware free these days.";
    }
    public static List<string> FirstTimeGreeting()
    {
        return new List<string>()
        {
            "Well! Hello there!",
            "I don't believe we've been properly introduced.",
            "I'm Bonzi!",
            "What is your name?"
        };
    }

    public static List<string> ReturnGreetings(string name)
    {
        return new List<string>()
        {
            $"Nice to see you again {name}!"
        };
    }
    public static List<string> GetForecasts(float temperature, string city)
    {
        return new List<string>()
        {
            $"Holy shit! It's {temperature} degrees. You must be fucking freezing.\nIf I were you I'd get the hell out of {city} and move somewhere warmer!",
            $"Oh my god, you must be cold. It's {temperature} degrees in {city} right now.",
            $"Wow! It's a bit nippy. It's currently {temperature} degrees in {city} right now.",
            $"It's getting pretty hot in {city}. It's {temperature} degrees right now. Make sure to stay hydrated.",
            $"Global warming sure exists in {city}.",
            "Go fuck yourself"

        };
    }
    public static List<string> GetJokes()
    {
        return new List<string>()
        {
            "Why don't oysters donate to charity? Because they're shellfish.",
            "What does a baby computer call its father? Data.",
            "What did the custodian say when he jumped out of the closet? Supplies!",
            "Why are colds bad criminals? Because they're easy to catch.",
            "How does a penguin build its house? Igloos it together.",
            "Which knight invented King Arthur's Round Table? Sir Cumference.",
            "What do sprinters eat before a race? Nothing. They fast.",
            "What do you call a fly without wings? A walk!",
            "What happens when you witness a ship wreck? You let it sink in.",
            "How can you find Will Smith in the snow? Follow the fresh prints.",
            "Why did Will Smith slap Chris Rock? Because Chris was being a prick.",
            "What does a clock do when it's hungry? It goes back four seconds.",
            "What's the easiest way to make a glow worm happy? Cut off its tail—it'll be delighted!",
            "What do you call a belt made of watches? A waist of time!",
            "Why did Adele cross the road? To say hello from the other side!",
            "What's the best way to carve wood? Whittle by whittle.",
            "What did the teacher do with the student's report on cheese? She grated it.",
            "What's the difference between a piano and a fish? You can tune a piano, but you can't tuna fish.",
            "How do you organize an astronomer's party? You planet.",
            "What's the action like at a circus? In-tents.",
            "Why did the scarecrow get promoted? Because he was outstanding in his field.",
            "Why does Snoop Dogg carry an umbrella? Fo' drizzle.",
            "What do you call a pony with a sore throat? A little hoarse.",
            "What do you call a fish with no eye? Fsh.",
            "What do you call a boomerang that doesn't come back? A stick!",
            "What kind of car does an egg drive? A Yolkswagen.",
            "I’m afraid of the calendar. Its days are numbered.",
            "I don’t play soccer because I enjoy the sport. I’m just doing it for kicks!",
            "Why are elevator jokes so classic and good? They work on many levels.",
            "What did the fish say when he hit the wall? Dam."
        };
    }

    public static string AsyncWarning()
    {
        return "Please be patient while I use my big and marvelous brain.";
    }
}