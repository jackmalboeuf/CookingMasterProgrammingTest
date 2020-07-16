using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryStatChange : MonoBehaviour
{
    public float duration;

    float startingMovespeed;
    float timer = 10;

    private void Start()
    {
        startingMovespeed = GetComponent<PlayerMovement>().movementSpeed;
        GetComponent<PlayerMovement>().movementSpeed *= 2;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                GetComponent<PlayerMovement>().movementSpeed = startingMovespeed;
                Destroy(this);
            }
        }
    }
}
