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

    //Raycasting
    void createHandRaycast(GameObject hand)
    {
        var rayX = hand.transform.position.x;
        var rayY = hand.transform.position.y;
        var rayZ = hand.transform.position.z;
        var indexFingerPos = new Vector3(rayX, rayY, rayZ);

        pointer = new Ray(indexFingerPos, hand.transform.forward);
        lineRenderer.widthMultiplier = 0.01f;
        lineRenderer.SetPosition(0, pointer.origin);
        lineRenderer.SetPosition(1, pointer.origin + pointer.direction * playerRange);
    }

    GameObject handRaycastObject(GameObject hand)
    {
        createHandRaycast(hand);
        RaycastHit hit;
        if (Physics.Raycast(pointer, out hit, playerRange))
        {
            return hit.collider.gameObject;
        }
        else
        {
            return null;
        }
    }

    GameObject handRaycastPoint(GameObject hand)
    {
        createHandRaycast(hand);
        return null;
    }
}
