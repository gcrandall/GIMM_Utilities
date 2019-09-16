using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParseStrings : MonoBehaviour
{
    void Start()
    {
        string phrase = "The quick brown fox jumps over the lazy dog.";
        string[] words = phrase.Split(' ');

        foreach (var word in words)
        {
            System.Console.WriteLine($"<{word}>");
        }

        //

        char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

        string text = "one\ttwo three:four,five six seven";
        System.Console.WriteLine($"Original text: '{text}'");

        string[] words = text.Split(delimiterChars);
        System.Console.WriteLine($"{words.Length} words in text:");

        foreach (var word in words)
        {
            System.Console.WriteLine($"<{word}>");
        }

        //

        string[] separatingStrings = { "<<", "..." };

        string text = "one<<two......three<four";
        System.Console.WriteLine($"Original text: '{text}'");

        string[] words = text.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
        System.Console.WriteLine($"{words.Length} substrings in text:");

        foreach (var word in words)
        {
            System.Console.WriteLine(word);
        }
    }
}
