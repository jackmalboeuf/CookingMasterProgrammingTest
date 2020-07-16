using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject powerupPrefab;
    public Sprite speedSprite;
    public Sprite timeSprite;
    public Sprite scoreSprite;

    GameObject spawnedPowerup;

    //pick a random spawn location based on the bounds of the object this script is attached to
    //the box collider attached to the object is just for visual reference of the spawn area
    //the box collider component should be disabled at runtime
    Vector3 RandomizeSpawnLocation()
    {
        float xRange = Random.Range(-transform.lossyScale.x, transform.lossyScale.x);
        float yRange = Random.Range(-transform.lossyScale.y, transform.lossyScale.y);

        Vector3 offset = transform.position;

        return new Vector3(xRange, yRange, 0) + offset;
    }

    public void SpawnPowerup()
    {
        spawnedPowerup = Instantiate(powerupPrefab, RandomizeSpawnLocation(), transform.rotation, null);

        int rand = Random.Range(0, 3);

        switch (rand)
        {
            case 0:
                spawnedPowerup.GetComponent<SpriteRenderer>().sprite = speedSprite;
                spawnedPowerup.GetComponent<Powerup>().type = Powerup.powerupType.Speed;
                break;
            case 1:
                spawnedPowerup.GetComponent<SpriteRenderer>().sprite = timeSprite;
                spawnedPowerup.GetComponent<Powerup>().type = Powerup.powerupType.Time;
                break;
            case 2:
                spawnedPowerup.GetComponent<SpriteRenderer>().sprite = scoreSprite;
                spawnedPowerup.GetComponent<Powerup>().type = Powerup.powerupType.Score;
                break;
            default:
                break;
        }
    }
}
