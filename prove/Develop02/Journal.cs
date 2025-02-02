using System;
using System.Collections.Generic;
using System.IO;

// Main journal class that handles all the entries and file stuff
public class Journal
{
    // Keep track of all our entries and the prompt generator
    private List<Entry> _entries;
    private PromptGenerator _promptGenerator;

    public Journal()
    {
        _entries = new List<Entry>();
        _promptGenerator = new PromptGenerator();
    }

    // Gets a random prompt and creates a new entry
    public void AddEntry()
    {
        string prompt = _promptGenerator.GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("> ");
        string response = Console.ReadLine();

        Entry.DisplayAvailableMoods();
        string mood;
        while (true)
        {
            Console.Write("\nSelect your current mood (enter number): ");
            if (int.TryParse(Console.ReadLine(), out int moodIndex) && 
                moodIndex >= 1 && moodIndex <= Entry.AvailableMoods.Length)
            {
                mood = Entry.AvailableMoods[moodIndex - 1];
                break;
            }
            Console.WriteLine("Invalid selection. Please try again.");
        }

        Entry entry = new Entry(prompt, response, mood);
        _entries.Add(entry);
        Console.WriteLine("\nEntry added successfully!");
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine($"{entry._date}|{entry._promptText}|{entry._responseText}|{entry._mood}");
                }
            }
            Console.WriteLine("Journal saved successfully!");
        }
        catch (Exception ex)
        {
            // Better safe than sorry with file operations
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    // Loads entries from a file 
    public void LoadFromFile(string filename)
    {
        try
        {
            _entries.Clear(); // start fresh
            string[] lines = File.ReadAllLines(filename);
            
            foreach (string line in lines)
            {
                string[] parts = line.Split("|");
                if (parts.Length == 4)
                {
                    Entry entry = new Entry(parts[1], parts[2], parts[3]);
                    entry._date = parts[0];
                    _entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }

    public void DisplayMoodStatistics()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to analyze.");
            return;
        }

        // Count up all the moods
        Dictionary<string, int> moodCounts = new Dictionary<string, int>();
        foreach (Entry entry in _entries)
        {
            if (!moodCounts.ContainsKey(entry._mood))
                moodCounts[entry._mood] = 0;
            moodCounts[entry._mood]++;
        }

        // Show the stats with percentages
        Console.WriteLine("\nMood Statistics:");
        Console.WriteLine("---------------");
        foreach (var mood in moodCounts)
        {
            double percentage = (double)mood.Value / _entries.Count * 100;
            Console.WriteLine($"{mood.Key}: {mood.Value} entries ({percentage:F1}%)");
        }
    }
} 