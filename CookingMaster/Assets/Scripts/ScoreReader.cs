using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreReader : MonoBehaviour
{
    public Text topTenScoresText;

    List<int> scores = new List<int>();
    List<string> names = new List<string>();

    public void ReadSpreadsheet(int newTopScore, string newTopPlayerName)
    {
        //get the scores csv file
        TextAsset spreadsheet = Resources.Load<TextAsset>("topScores");

        //split the file at each line
        string[] lines = spreadsheet.text.Split(new char[] { '\n' });

        //split each line at each comma (row)
        for (int i = 0; i < lines.Length; i++)
        {
            string[] row = lines[i].Split(new char[] { ',' });

            //add the values to separate lists
            if (row[0] != "")
            {
                scores.Add(Int32.Parse(row[0]));
                names.Add(row[1]);
            }
        }

        //if there is an identical score already in the list, replace it with the new one
        if (scores.Contains(newTopScore))
        {
            int removalNum = scores.IndexOf(newTopScore);
            scores.RemoveAt(removalNum);
            names.RemoveAt(removalNum);
        }

        scores.Add(newTopScore);
        names.Add(newTopPlayerName);

        SortedList sl = new SortedList();

        //add the scores and names to a sorted list
        for (int i = 0; i < scores.Count; i++)
        {
            sl.Add(scores[i], names[i]);
        }

        //keep the list at 10 by removing the lowest score
        if (sl.Count > 10)
        {
            sl.RemoveAt(0);
        }

        //writeScores is for updating the values of the csv spreadsheet
        string writeScores = string.Empty;

        if (topTenScoresText.gameObject.activeSelf)
        {
            //showScores is for displaying the scores on the end game screen
            string showScores = string.Empty;

            for (int i = sl.Count; i > 0; i--)
            {                
                showScores += string.Format("{0}:    {1}\n", sl.GetByIndex(i - 1), sl.GetKey(i - 1));
                writeScores += string.Format("{0},{1}\n", sl.GetKey(i - 1), sl.GetByIndex(i - 1));
            }

            //show scores on end screen
            topTenScoresText.text = showScores;
        }

        //write the updated scores to the spreadsheet
        writeScores.TrimEnd('\n');
        File.WriteAllText("Assets/Resources/topScores.csv", writeScores);
    }
}
