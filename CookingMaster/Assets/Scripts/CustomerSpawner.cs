using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab;
    public Image vegetableImagePrefab;
    public List<VegetableObject> vegetableTypes = new List<VegetableObject>();

    float timePassed = 0;
    float spawnIntervalTimer = 0;
    float spawnInterval = 3;
    int spawnStage = 0;
    CustomerRandomizer cRand;
    CustomerBehavior spawnedCustomer;
    GameObject orderImage;

    public List<int> chosenVegetables = new List<int>();

    private void Start()
    {
        cRand = GetComponent<CustomerRandomizer>();
    }

    private void Update()
    {
        timePassed += Time.time;

        if (spawnIntervalTimer <= 0)
        {
            spawnIntervalTimer = spawnInterval;

            SpawnCustomer(spawnStage);
            spawnStage++;
        }

        if (spawnIntervalTimer > 0)
        {
            spawnIntervalTimer -= Time.deltaTime;
        }
    }

    void SpawnCustomer(int stage)
    {
        spawnedCustomer = Instantiate(customerPrefab, transform).GetComponent<CustomerBehavior>();
        
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
            default:
                break;
        }

        for (int i = 0; i < spawnedCustomer.customerOrder.Count; i++)
        {
            orderImage = Instantiate(vegetableImagePrefab.gameObject, spawnedCustomer.orderDisplay);
            orderImage.GetComponent<Image>().sprite = vegetableTypes[spawnedCustomer.customerOrder[i]].choppedImage;
        }
    }
}
