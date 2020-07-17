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
        //get the range of the spawn area
        float xRange = Random.Range(-transform.localScale.x, transform.localScale.x);
        float yRange = Random.Range(-transform.localScale.y, transform.localScale.y);

        //get the offset of the area
        Vector3 offset = transform.position;

        //spawn at a random location within the bounds of the area, adjusted by the offset of the area
        return new Vector3(xRange, yRange, 0) + offset;
    }

    public void SpawnPowerup()
    {
        //spawn powerup gameobject
        spawnedPowerup = Instantiate(powerupPrefab, RandomizeSpawnLocation(), transform.rotation, null);
        spawnedPowerup.transform.localScale = new Vector3(0.8f, 0.8f, 1);

        //pick a random powerup to spawn and set its properties
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
