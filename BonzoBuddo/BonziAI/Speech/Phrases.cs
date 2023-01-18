﻿namespace BonzoBuddo.BonziAI.Speech;

/// <summary>
///     Lists and dictionaries of phrases used by Bonzi.
/// </summary>
public static class Phrases
{
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

    public static Dictionary<string, string> BonziIntro(string name)
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
            $"{name}, what do you want to do today?"
        };
    }

    public static Dictionary<string, string> Prompts()
    {
        return new Dictionary<string, string>
        {
            {"GetWeather", "Please wait while I use my big and marvelous brain to get the weather."}
        };
    }

    public static Dictionary<string, string> ErrorMessages()
    {
        return new Dictionary<string, string>
        {
            {
                "NoWeather",
                "Well, it seems like I couldn't get the weather for you. Are you sure you are connected to the internet?"
            }
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