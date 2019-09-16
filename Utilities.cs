using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Utilities : MonoBehaviour {

	public static string SplitAndAnalyzeString(string input)
    {
        string[] words = input.Split(' ');

        int[] results = { 0, 0 };

        foreach (var word in words)
        {
            int index = AnalyzeString(word);
            results[index]++;
        }

        string resultString = results[0] + " words, " + results[1] + " numbers";

        return resultString;
    }

    //Returns 0 if word, 1 if number
    private static int AnalyzeString(string input)
    {
        try
        {
            culture = CultureInfo.CreateSpecificCulture("en-US");
            number = double.Parse(input, culture);
            return 0;
        }
        catch (FormatException)
        {
            return 1;
        }
    }
}
