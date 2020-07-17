using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public enum powerupType { Speed, Time, Score }
    public powerupType type;

    delegate void PowerupActions(PlayerInteraction player);
    PowerupActions actions;

    public void PickUpPowerup(PlayerInteraction player)
    {
        switch (type)
        {
            case powerupType.Speed:
                actions = BoostSpeed;
                break;
            case powerupType.Time:
                actions = AddTime;
                break;
            case powerupType.Score:
                actions = IncreaseScore;
                break;
            default:
                break;
        }

        actions(player);
        Destroy(gameObject);
    }

    void BoostSpeed(PlayerInteraction playerMovement)
    {
        playerMovement.gameObject.AddComponent<TemporaryStatChange>();
    }

    void AddTime(PlayerInteraction playerTimer)
    {
        playerTimer.GetComponent<PlayerTimer>().timer += 20;
    }

    void IncreaseScore(PlayerInteraction playerScore)
    {
        playerScore.GetComponent<PlayerScore>().UpdateScore(5);
    }
}
