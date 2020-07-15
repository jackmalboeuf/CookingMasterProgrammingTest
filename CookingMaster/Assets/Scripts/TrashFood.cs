using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashFood : MonoBehaviour
{
    public void DeleteFood(Transform heldFood, Transform plate)
    {
        for (int i = 0; i < heldFood.childCount; i++)
        {
            Destroy(heldFood.GetChild(i).gameObject);
        }

        if (plate != null)
        {
            for (int i = 0; i < plate.childCount; i++)
            {
                Destroy(plate.GetChild(0).GetChild(i).gameObject);
            }

            plate.SetParent(null);
            plate.position = plate.GetComponent<PlateBehavior>().returnLocation.position;
        }
    }
}
