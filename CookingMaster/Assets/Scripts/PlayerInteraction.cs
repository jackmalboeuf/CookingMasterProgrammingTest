using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public RectTransform vegetableHolder;
    public Slider chopTimerSlider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<VegetableSpawner>())
        {
            collision.GetComponent<VegetableSpawner>().SpawnVegetable(vegetableHolder);
        }
        else if (collision.GetComponent<ChoppingTable>())
        {
            collision.GetComponent<ChoppingTable>().ChopVegetables(vegetableHolder);
        }
    }
}
