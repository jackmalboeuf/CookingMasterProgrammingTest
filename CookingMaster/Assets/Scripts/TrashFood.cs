using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashFood : MonoBehaviour
{
    int scoreChange = -1;

    public void DeleteFood(Transform heldFood, Transform plate)
    {
        //remove any food held by the player
        for (int i = 0; i < heldFood.childCount; i++)
        {
            Destroy(heldFood.GetChild(i).gameObject);
        }

        //remove any food on the plate, reset the plate's location, and subtract score
        if (plate != null)
        {
            plate.GetComponent<PlateBehavior>().ResetPlate();

            if (heldFood.GetComponentInParent<PlayerScore>())
            {
                heldFood.GetComponentInParent<PlayerScore>().UpdateScore(scoreChange);
            }
        }
    }
}
