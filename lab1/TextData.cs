using System;
using System.Text.RegularExpressions;

public class TextData
{
    private string fileName;
    private string text;
    private int numberOfVowels;
    private int numberOfConsonants;
    private int numberOfLetters;
    private int numberOfSentences;
    private string longestWord;

    public TextData(string text, string fileName)
    {
        this.fileName = fileName;
        this.text = text;
        this.numberOfVowels = CountVowels(text);
        this.numberOfConsonants = CountConsonants(text);
        this.numberOfLetters = CountLetters(text);
        this.numberOfSentences = CountSentences(text);
        this.longestWord = FindLongestWord(text);
    }

    public string GetFilename() => fileName;
    public string GetText() => text;
    public int GetNumberOfVowels() => numberOfVowels;
    public int GetNumberOfConsonants() => numberOfConsonants;
    public int GetNumberOfLetters() => numberOfLetters;
    public int GetNumberOfSentences() => numberOfSentences;
    public string GetLongestWord() => longestWord;

    private int CountVowels(string text)
    {
        int count = 0;
        foreach (char c in text.ToLower())
        {
            if ("aeiouAEIOU".Contains(c))
            {
                count++;
            }
        }

        return count;
    }

    private int CountConsonants(string text)
    {
        int count = 0;
        foreach (char c in text.ToLower())
        {
            if (char.IsLetter(c) && !"aeiouAEIOU".Contains(c))
            {
                count++;
            }
        }
        return count;
    }

    private int CountLetters(string text)
    {
        int count = 0;
        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                count++;
            }
        }
        return count;
    }

    private int CountSentences(string text)
    {
        return Regex.Matches(text, @"[.!?]").Count;
    }

    private string FindLongestWord(string text)
    {
        string[] words = text.Split(new char[] { ' ', '\n', '\t', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        string longest = "";
        foreach (string word in words)
        {
            if (word.Length > longest.Length)
            {
                longest = word;
            }
        }
        return longest;
    }


}
