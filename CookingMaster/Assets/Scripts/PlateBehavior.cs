using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBehavior : MonoBehaviour
{
    public Transform returnLocation;
    public PlayerInteraction holdingPlayer;

    public void PlaceObjectOnPlate(Transform vegetableHolder)
    {
        int loopTimes = vegetableHolder.childCount; //stores the number of times the loop should run

        //puts the held vegetables on the plate
        for (int i = 0; i < loopTimes; i++)
        {
            vegetableHolder.GetChild(0).SetParent(transform.GetChild(0));
        }
    }

    public void ResetPlate()
    {
        //remove objects from plate
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            Destroy(transform.GetChild(0).GetChild(i).gameObject);
        }

        //reset plate's location
        transform.SetParent(null);
        transform.position = returnLocation.position;
        GetComponent<Collider2D>().enabled = true;
        holdingPlayer.isHoldingPlate = false;
        holdingPlayer = null;
    }
}
