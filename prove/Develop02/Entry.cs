using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _responseText;
    public string _mood;

    public static string[] AvailableMoods = {
        "Happy", "Sad", "Excited", "Tired", "Anxious", 
        "Peaceful", "Frustrated", "Grateful", "Motivated"
    };

    public Entry(string prompt, string response, string mood)
    {
        _date = DateTime.Now.ToShortDateString();
        _promptText = prompt;
        _responseText = response;
        _mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_responseText}\n");
    }

    public static void DisplayAvailableMoods()
    {
        Console.WriteLine("\nAvailable moods:");
        for (int i = 0; i < AvailableMoods.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {AvailableMoods[i]}");
        }
    }
} 