using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VegetableSpawner : MonoBehaviour
{
    public VegetableObject vegetableProperties; //scriptable object with the vegetable's properties
    public GameObject vegetablePrefab;

    GameObject spawnedVegetable;

    private void Start()
    {
        //show the image of the vegetable that can be picked up from here
        GetComponent<SpriteRenderer>().sprite = vegetableProperties.unchoppedImage;
    }

    public void SpawnVegetable(RectTransform spawnLocation)
    {
        if (spawnLocation.childCount < 2)  //sets the vegetable's sprite and prevents player from holding more than two vegetables
        {
            spawnedVegetable = Instantiate(vegetablePrefab, spawnLocation);
            spawnedVegetable.GetComponent<VegetableState>().vegetableSettings = vegetableProperties;
            spawnedVegetable.GetComponent<Image>().sprite = vegetableProperties.unchoppedImage;
            spawnedVegetable = null;
        }
    }
}
