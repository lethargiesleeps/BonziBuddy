using BonzoBuddo.Helpers;

namespace BonzoBuddo.BonziAI.Speech;

/// <summary>
///     Lists and dictionaries of phrases used by Bonzi.
/// </summary>
public static class Phrases
{
    public static List<string> AuxiliaryPhrases(string name)
    {
        return new List<string>
        {
            "You silly goose you."
        };
    }

    public static List<string> ShowMessages(string name)
    {
        return new List<string>
        {
            $"I knew you weren't actually leaving me {name}!",
            "I'm so happy you called me back!",
            "Oh, what were you doing while I was gone? Just kidding, I already know.",
            "I had time to shower after you sent me away, maybe now you'll tolerate me a little longer!",
            "F is for friends that do stuff together, U is for you and me!",
            "It's good to be back."
        };
    }

    public static List<string> HideMessages(string name)
    {
        return new List<string>
        {
            "I thought you wanted to hang out.",
            "But I don't want to go right now.",
            $"Please {name}, do we really have to do this.",
            "I can't say that I'm mad, but I'm disappointed.",
            $"Someone once said \"Your best friends will never leave you\". I guess that explains where we are at in our relationship {name}.",
            "Ok, don't be to long though.",
            $"I'll miss you {name}. I'll miss you so very much."
        };
    }

    
    public static List<string> PostFact(string name)
    {
        return new List<string>
        {
            "Wow! Isn't it fun to learn something new everyday.",
            $"{name}, I really think you should thank me for giving you this vital information.",
            "Well, isn't this fascinating.",
            "They say Einstein was the smartest man in the world. I think now we can both agree that it's Bonzi!",
            "You learn a lot when you spend nearly two decades in internet prison.",
            "That's fascinating to you, but I already knew that.",
            $"{name}, aren't I a wealth of information!"
        };
    }

    public static Dictionary<string, string> JokeExtras()
    {
        return new Dictionary<string, string>
        {
            {"First", "Not a problem."},
            {"Last", "Laughter is the best medicine."}
        };
    }

    public static List<string> FirstTimeGreeting()
    {
        return new List<string>
        {
            "Well! Hello there!",
            "I don't believe we've been properly introduced.",
            "I'm Bonzi!",
            "What is your name?"
        };
    }

    public static List<string> Insulted(string name)
    {
        return new List<string>
        {
            $"Why are you being so mean to me {name}...",
            "I know I used to be kind of a bad boy, but I swear I've changed my ways.",
            $"{name}, I though we were best of friends...",
            $"Well fuck you too {name}...",
            "I don't deserve this kind of abuse from you.",
            $"You are being quite a Richard, {name}..."
        };
    }

    public static Dictionary<string, string> BonziIntro(string? name)
    {
        return new Dictionary<string, string>
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

    public static List<string> ReturnGreeting(string name)
    {
        var time = TimeOnly.FromDateTime(DateTime.Now);
        string greetingTime;
        switch (time.Hour)
        {
            case >= 6 and < 12:
                greetingTime = $"Good morning {name}. We are going to spend a beautiful day together.";
                break;
            case >= 12 and < 17:
                greetingTime = $"Good afternoon {name}. Did you just wake up?";
                break;
            case >= 17 and < 21:
                greetingTime = $"Good evening {name}. Guess what I'm having for dinner? Bananas";
                break;
            case >= 21 and < 24:
                greetingTime =
                    $"Hello {name}, it's getting pretty late, but since we are best friends I'll stay up with you.";
                break;
            default:
                greetingTime = $"{name}, you are quite the night owl aren't you?";
                break;
        }

        return new List<string>
        {
            $"Welcome back {name}!",
            $"Nice to see you again {name}!",
            $"{name}! I was almost starting to think you abandoned me.",
            $"Oh hi {name}, I was just thinking of you.",
            $"{name}! I've gone ahead and deleted your files while you were away.\nJust kidding!",
            $"I'm so happy to be spending time with you {name}.",
            $"{name}! Did you miss me?",
            $"Just another day with my best friend {name}!",
            $"{name}, what do you want to do today?",
            greetingTime
        };
    }

     
    public static Dictionary<string, string> Prompts(string name)
    {
        return new Dictionary<string, string>
        {
            {"OpenPanel", "Look at all those buttons!"},
            {"ClosePanel", $" It's {DateTime.Now.Year}, who needs buttons anymore!"},
            {"GetWeather", "Please wait while I use my big and marvelous brain to get the weather."},
            {"GetNews", $"No problem {name}. I just need some extra information from you before I conduct my search."},
            {"SearchNews", $"{name}, it would be my pleasure. Please give me a few seconds."},
            {
                "GetDictionary",
                $"{PreDictionary(name)} I just need you to let me know what word you'd like for me to look up."
            },
            {"PreRandomWord", $"Not a problem {name}, let me know if you would also like for me to get a definition."},
            {"RandomWord", "Ok, let me just think of a word."},
            {"PostSong", $"I hope you enjoyed that, that was one of my favorite tunes {name}!"}
        };
    }

    public static List<string> PreRandomWord(string word)
    {
        return new List<string>()
        {
            $"Bet you've never heard of '{word}' before.",
            $"'{word}' !",
            $"'{word}' is my new favorite word.",
            $"Have you ever heard of '{word}'?",
            $"I've got it, it's '{word}'!"
        };
    }
    private static string PreDictionary(string name)
    {
        var prompts = new List<string>
        {
            $"No problem {name}, just let me know what word you're unsure of.",
            "Back in my glory days, everyone had a dictionary in their homes. I guess you don't, let me look it up for you.",
            "Have not read the Oxford Dictionary? It's one of the best selling books in the world. Guess not, I can take care of that for you.",
            $"Here is the definition of intelligent: Purple Gorilla, usually hilarious and awesome. Synonyms: Bonzi, Antonyms: {name}. Just kidding, I can help you."
        };
        
        return prompts[new Random().Next(prompts.Count)];
    }
    public static string PostDictionary(string word)
    {
        var prompts = new List<string>
        {
            "That was an easy one.",
            $"Don't you wish you were as smart as me?",
            $"Who know '{word}' actually had a definition?!",
            $"I'll add '{word}' to my list of favorite words!",
            $"I thought '{word}' meant something else, but I guess I was wrong!"
        };
        RandomNumberHelper.SetIndex(prompts.Count);
        return prompts[RandomNumberHelper.CurrentValue];
    }

    public static Dictionary<string, string> ErrorMessages()
    {
        var illegalPrompts = new List<string>()
        {
            "I'm not looking that up!",
            "Who raised you with such bad language.",
            "They say only the uneducated use bad words.",
            "Cussing is the language of idiots!",
            "Are you trying to get me arrested?"

        };

        RandomNumberHelper.SetIndex(illegalPrompts.Count);
        return new Dictionary<string, string>
        {
            {
                "NoWeather",
                "Well, it seems like I couldn't get the weather for you. Are you sure you are connected to the internet?"
            },
            {"NoResults", "I couldn't find any news for you. Try making your search a little more broad."},
            {"BadNewsRequest", "Hmmm something went wrong. You can try again."},
            {"NoWordDictionary", "You didn't even enter a word!"},
            {"WhitespaceDictionary", "Here is the definition for space bar: a key on your keyboard."},
            {"MultipleWordsDictionary", "Whoa there buddy, I said \"a\" word."},
            {"HasCussWords", illegalPrompts[RandomNumberHelper.CurrentValue]},
            {"RandomWordIllegalBoxCombo", "I can't just search for synonyms and antonyms. If you want those, please check 'Definition' as well."}
        };
    }

    public static Dictionary<string, string> WeatherForecasts(string city, float temp)
    {
        return new Dictionary<string, string>
        {
            {
                "VeryCold",
                $"Oh my goodness, if you don't dress warm you might die! It's currently {temp} degrees in {city}!"
            },
            {"Cold", $"Burr, you better put on your long john's because it's {temp} degrees in {city} right now."},
            {"Brisk", $"Seems a little brisk right now in {city}. It's currently {temp} degrees."},
            {"Warm", $"Great weather today in {city}! It's currently {temp} degrees!"},
            {
                "Hot",
                $"Wow! You have some beautiful hot weather today in {city}! It's currently {temp} degrees. Make sure to stay hydrated."
            },
            {"VeryHot", $"Oh my god. {city} is literally on fire. If I were you I'd evacuate."}
        };
    }
}