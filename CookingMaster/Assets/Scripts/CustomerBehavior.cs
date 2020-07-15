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
            customerTimer -= Time.deltaTime;
            timerSldier.value = customerTimer;

            //remove customer and subtract points if the timer runs out
            if (customerTimer <= 0)
            {
                customerTimer = 0;

                //if angry: pointsToSubtract = double points
                //else: pointsToSubtract = normal points

                //if failed player list is empty: subtract points from both players
                //else if: subtract points from each player in list once
                Destroy(gameObject);
            }
        }
    }

    public void CheckOrder(Transform plate)
    {
        plateVegetables.Clear();

        if (plate.childCount != 0)
        {
            for (int i = 0; i < plate.childCount; i++)
            {
                plateVegetables.Add(plate.GetChild(i).GetComponent<VegetableState>());
            }
        }

        int numberOfVegetablesCorrect = 0;

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
        print(plateVegetables.Count);
        print(numberOfVegetablesCorrect);
        print(customerOrder.Count);
        if (plateVegetables.Count == 0 && numberOfVegetablesCorrect == customerOrder.Count)
        {
            if (customerTimer >= bonusPercent * waitTime)
            {
                //give powerup
            }

            //add points
            Destroy(gameObject);
        }
        else
        {
            //become angry
            //add player who delivered incorrectly to list
            
            print("wrong");
        }
    }
}
