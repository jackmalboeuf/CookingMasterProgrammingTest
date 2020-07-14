using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLocationManager : MonoBehaviour
{
    public List<Transform> spawnPoints = new List<Transform>();

    Transform pointToPutOnBottom;

    //checks if the first spawn is open and moves it to the bottom of the list if it isn't
    public Transform GetOpenSpawn()
    {
        Transform openSpawn = null;

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (spawnPoints[0].childCount > 0)
            {
                pointToPutOnBottom = spawnPoints[0];
                spawnPoints.RemoveAt(0);
                spawnPoints.Add(pointToPutOnBottom);
            }
            else
            {
                openSpawn = spawnPoints[0];
            }
        }

        return openSpawn;
    }
}
