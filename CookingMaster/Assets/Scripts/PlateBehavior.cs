using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBehavior : MonoBehaviour
{
    public Transform returnLocation;

    public void PlaceObjectOnPlate(Transform vegetableHolder)
    {
        for (int i = 0; i < vegetableHolder.childCount; i++)
        {
            vegetableHolder.GetChild(i).SetParent(transform.GetChild(0));
        }
    }
}
