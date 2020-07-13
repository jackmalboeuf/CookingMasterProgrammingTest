using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupVegetable : MonoBehaviour
{
    public Transform vegetableHolder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<VegetableSpawner>().SpawnVegetable(vegetableHolder);
        /*if (collision.GetComponent<VegetableSpawner>() && vegetableHolder.transform.childCount == 0)
        {
            
        }*/
    }
}
