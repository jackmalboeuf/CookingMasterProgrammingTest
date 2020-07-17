using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab;
    public Image vegetableImagePrefab;
    public CustomerLocationManager cLocation;
    public List<VegetableObject> vegetableTypes = new List<VegetableObject>();

    float spawnIntervalTimer = 0;
    float spawnInterval = 10;
    float timePerVegetable = 15;
    int spawnStage = 0;
    CustomerBehavior spawnedCustomer;
    GameObject orderImage;

    public List<int> chosenVegetables = new List<int>();

    private void Update()
    {
        if (spawnIntervalTimer <= 0)    //when the timer reaches 0
        {
            spawnIntervalTimer = spawnInterval; //reset timer

            bool anyOpenSpawns = false;  //assume there are no open spawns

            //change the bool to true if there are any open spawns
            for (int i = 0; i < cLocation.spawnPoints.Count; i++)
            {
                if (cLocation.spawnPoints[i].childCount == 0)
                {
                    anyOpenSpawns = true;
                }
            }

            //spawn a new customer only if there is at least one open spawn
            if (anyOpenSpawns)
            {
                SpawnCustomer(spawnStage);
            }

            //move the spawn stage forward unless it has reached the max number of vegetable options
            if (spawnStage < 5)
            {
                spawnStage++;
            }
        }

        //count down the timer
        if (spawnIntervalTimer > 0)
        {
            spawnIntervalTimer -= Time.deltaTime;
        }
    }

    void SpawnCustomer(int stage)
    {
        //spawn the customer at a point determined by the CustomerLocationManager script
        spawnedCustomer = Instantiate(customerPrefab, cLocation.GetOpenSpawn().position, cLocation.GetOpenSpawn().rotation, cLocation.GetOpenSpawn()).GetComponent<CustomerBehavior>();
        CustomerRandomizer cRand = gameObject.AddComponent<CustomerRandomizer>();

        //change the customer's order size based on the game's progress
        switch (stage)
        {
            case 0:
                spawnedCustomer.customerOrder = cRand.CreateRandomCustomer(1);
                break;
            case 1:
                spawnedCustomer.customerOrder = cRand.CreateRandomCustomer(2);
                break;
            case 2:
                spawnedCustomer.customerOrder = cRand.CreateRandomCustomer(3);
                break;
            case 3:
                spawnedCustomer.customerOrder = cRand.CreateRandomCustomer(4);
                break;
            case 4:
                spawnedCustomer.customerOrder = cRand.CreateRandomCustomer(5);
                break;
            case 5:
                spawnedCustomer.customerOrder = cRand.CreateRandomCustomer(6);
                break;
            default:
                break;
        }

        //add a number of images equal to the customer's order size and change their sprite to match the vegetable type
        for (int i = 0; i < spawnedCustomer.customerOrder.Count; i++)
        {
            orderImage = Instantiate(vegetableImagePrefab.gameObject, spawnedCustomer.orderDisplay);
            orderImage.GetComponent<Image>().sprite = vegetableTypes[spawnedCustomer.customerOrder[i]].choppedImage;
        }

        //find the timer slider
        Slider timerSlider = spawnedCustomer.GetComponentInChildren<Slider>();

        //set the customer's wait time based on their order size and reset the timer slider
        spawnedCustomer.waitTime = timePerVegetable * spawnedCustomer.customerOrder.Count;
        timerSlider.maxValue = spawnedCustomer.waitTime;
        timerSlider.value = timerSlider.maxValue;
        Destroy(cRand);
    }
}
