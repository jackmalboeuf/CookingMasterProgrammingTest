using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void SpawnVegetable(Transform spawnLocation)
    {
        if (spawnLocation.childCount == 0)  //player is holding no vegetables
        {
            spawnedVegetable = Instantiate(vegetablePrefab, spawnLocation.position, spawnLocation.rotation, spawnLocation);
        }
        else if (spawnLocation.childCount == 1) //player is holding one vegetable
        {
            Transform firstVegetable = spawnLocation.GetChild(0);   //store currently held vegetable

            //moves the first vegetable over to the left
            firstVegetable.localPosition = new Vector2(-firstVegetable.localScale.x * 0.5f, firstVegetable.localPosition.y);

            //spawn second vegetable to the right
            spawnedVegetable = Instantiate(vegetablePrefab, spawnLocation);
            spawnedVegetable.transform.localPosition = new Vector2(firstVegetable.localScale.x * 0.5f, firstVegetable.localPosition.y);
        }
        
        if (spawnLocation.childCount <= 2 && spawnedVegetable != null)  //sets the vegetable's sprite and prevents player from holding more than two vegetables
        {
            spawnedVegetable.GetComponent<VegetableState>().vegetableSettings = vegetableProperties;
            spawnedVegetable.GetComponent<SpriteRenderer>().sprite = vegetableProperties.unchoppedImage;
            spawnedVegetable = null;
        }
    }
}
