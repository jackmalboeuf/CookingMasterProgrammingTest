using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTimer : MonoBehaviour
{
    public Text timerText;
    public Text winnerText;
    
    [HideInInspector]
    public float timer = 0;

    private void Start()
    {
        timer = 200;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = Mathf.Round(timer).ToString(); //round timer value to nearest whole number

            //player's time runs out
            if (timer <= 0)
            {
                //stop player control
                GetComponent<PlayerMovement>().enabled = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                GetComponent<Collider2D>().enabled = false;

                //get all player timers
                PlayerTimer[] timers = FindObjectsOfType<PlayerTimer>();
                int numberOfTimersDone = 0;

                //check which timers are at 0
                for (int i = 0; i < timers.Length; i++)
                {
                    if (timers[i].timer <= 0)
                    {
                        numberOfTimersDone++;
                    }
                }

                //if all of the player's timers are done
                if (numberOfTimersDone == timers.Length)
                {
                    SortedList sl = new SortedList();
                    PlayerScore[] scoredPlayers = FindObjectsOfType<PlayerScore>();

                    //add players and scores to a sorted list
                    for (int i = 0; i < scoredPlayers.Length; i++)
                    {
                        try
                        {
                            sl.Add(scoredPlayers[i].score, scoredPlayers[i].name);
                        }
                        catch (ArgumentException)
                        {
                            //do nothing if there is a tie
                        }
                    }
                    
                    //show who won and their score
                    winnerText.transform.parent.gameObject.SetActive(true);
                    winnerText.text = string.Format("{0} Wins!\n\nScore: {1}", sl.GetByIndex(sl.Count - 1), sl.GetKey(sl.Count - 1));

                    //add the winner's score to the top ten scores list
                    FindObjectOfType<ScoreReader>().ReadSpreadsheet((int)sl.GetKey(sl.Count - 1), sl.GetByIndex(sl.Count - 1).ToString());
                }
            }
        }
    }
}
