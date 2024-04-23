using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

class Program
{
    static void Main()
    {
        string text = "This is a sample text. The most common letter is t, and the words containing t are: this, is, sample, text, The, most, common, letter, is.";
        string[] result = MostCommonLetterWords(text);

        Console.WriteLine($"The most common letter is {result[0]} with a frequency of {result[1]}.");
        Console.WriteLine($"The words containing {result[0]} are: {string.Join(", ", result[2])}");
    }

    static string[] MostCommonLetterWords(string text)
    {
        // Initialize a dictionary to store the frequency of each letter
        Dictionary<char, int> letterFreq = new Dictionary<char, int>();

        // Iterate over each character in the text
        foreach (char c in text.ToLower())
        {
            // If the character is a letter, add it to the dictionary or increment its count
            if (char.IsLetter(c))
            {
                if (letterFreq.ContainsKey(c))
                {
                    letterFreq[c]++;
                }
                else
                {
                    letterFreq[c] = 1;
                }
            }
        }
        // Find the most common letter and its frequency
        char mostCommonLetter = letterFreq.Keys.MaxBy(k => letterFreq[k]).First();
        int maxFreq = letterFreq[mostCommonLetter];

        // Split the text into words and filter for words containing the most common letter
        string[] wordList = text.Split(' ');
        List<string> wordsWithLetter = new List<string>();
        foreach (string word in wordList)
        {
            if (word.Contains(mostCommonLetter))
            {
                wordsWithLetter.Add(word);
            }
        }
    }
}
        // Return the most common letter, its frequency, and the list of words




using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string text = "This is a sample text. The most common letter is t, and the words containing t are: this, is, sample, text, The, most, common, letter, is. This is the shortest sentence.";
        string result = ShortestSentence(text);

        Console.WriteLine($"The shortest sentence is: {result}");
    }

    static string ShortestSentence(string text)
    {
        // Split the text into sentences using periods as delimiters
        string[] sentences = text.Split('.', StringSplitOptions.RemoveEmptyEntries);

        // Find the length of the shortest sentence
        int shortestLength = sentences.Min(s => s.Length);

        // Find the first sentence with the minimum length
        string shortestSentence = sentences.First(s => s.Length == shortestLength);

        // Return the shortest sentence
        return shortestSentence;
    }
}


