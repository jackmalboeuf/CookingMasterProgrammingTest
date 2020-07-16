using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerBehavior : MonoBehaviour
{
    public List<int> customerOrder = new List<int>();
    public float waitTime;
    public Transform orderDisplay;

    float customerTimer = 0;
    float bonusPercent = 0.7f;
    Slider timerSldier;
    List<VegetableState> plateVegetables = new List<VegetableState>();
    bool isAngry = false;
    List<PlayerScore> playersToBeScored = new List<PlayerScore>();
    float timerMultiplier = 1;
    int pointsToAdd = 2;
    int pointsToSubtract = -2;  //this value is negative because the point update method always adds points, so this does not subtract negative points

    private void Start()
    {
        timerSldier = GetComponentInChildren<Slider>();
        customerTimer = waitTime;
    }

    private void Update()
    {
        //update the timer to tick down
        if (customerTimer > 0)
        {
            customerTimer -= Time.deltaTime * timerMultiplier;
            timerSldier.value = customerTimer;

            //remove customer and subtract points if the timer runs out
            if (customerTimer <= 0)
            {
                customerTimer = 0;

                //double the minus points if the customer is angry, otherwise keep them the same
                if (isAngry)
                {
                    pointsToSubtract *= 2;
                }
                else
                {
                    pointsToSubtract = -2;
                }

                if (playersToBeScored.Count == 0)   //subtract score of all players if none of them tried to deliver food
                {
                    for (int i = 0; i < FindObjectsOfType<PlayerScore>().Length; i++)
                    {
                        FindObjectsOfType<PlayerScore>()[i].UpdateScore(pointsToSubtract);
                    }
                }
                else    //subtract points from any players who delivered the wrong order
                {
                    for (int i = 0; i < playersToBeScored.Count; i++)
                    {
                        playersToBeScored[i].UpdateScore(pointsToSubtract);
                    }
                }

                //customer leaves
                playersToBeScored.Clear();
                Destroy(gameObject);
            }
        }
    }

    public void CheckOrder(Transform plateHolder, PlayerScore player)
    {
        plateVegetables.Clear();

        //store references to the vegetables on the plate in a list
        if (plateHolder.childCount != 0)
        {
            for (int i = 0; i < plateHolder.childCount; i++)
            {
                plateVegetables.Add(plateHolder.GetChild(i).GetComponent<VegetableState>());
            }
        }

        int numberOfVegetablesCorrect = 0;

        //compare each plate vegetable with the customer's order and check how many are correct
        //note that sequential order of the vegetables does not matter here, it finds the first correct vegetable no matter where it is sequentially
        for (int i = 0; i < customerOrder.Count; i++)
        {
            for (int g = 0; g < plateVegetables.Count; g++)
            {
                if ((int)plateVegetables[g].vegetableSettings.vegetableName == customerOrder[i] && plateVegetables[g].isChopped)
                {
                    plateVegetables.Remove(plateVegetables[g]);
                    numberOfVegetablesCorrect++;
                }
            }
        }

        if (plateVegetables.Count == 0 && numberOfVegetablesCorrect == customerOrder.Count) //if order is correct
        {
            //if order is given correctly within a certain percent of time spawn a powerup
            if (customerTimer >= bonusPercent * waitTime)
            {
                FindObjectOfType<PowerupSpawner>().SpawnPowerup();
            }

            player.UpdateScore(pointsToAdd * numberOfVegetablesCorrect);
            Destroy(gameObject);
        }
        else    //if order is incorrect
        {
            //become angry
            if (!isAngry)
            {
                isAngry = true;
                timerMultiplier = 1.5f;
                GetComponent<SpriteRenderer>().color = Color.red;
                playersToBeScored.Add(player);
            }
        }

        //reset plate no matter what the outcome is
        plateHolder.GetComponentInParent<PlateBehavior>().ResetPlate();
    }
}
