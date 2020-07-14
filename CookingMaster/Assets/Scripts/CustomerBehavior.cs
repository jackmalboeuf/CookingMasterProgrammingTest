using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerBehavior : MonoBehaviour
{
    public List<int> customerOrder = new List<int>();
    public float waitTime;
    public Transform orderDisplay;

    float customerTimer = 0;
    float bonusPercent = 0.7f;
    Slider timerSldier;

    private void Start()
    {
        timerSldier = GetComponentInChildren<Slider>();
        customerTimer = waitTime;
    }

    private void Update()
    {
        //update the timer to tick down
        if (customerTimer > 0)
        {
            customerTimer -= Time.deltaTime;
            timerSldier.value = customerTimer;

            //remove customer and subtract points if the timer runs out
            if (customerTimer <= 0)
            {
                customerTimer = 0;
                //subtract points
                Destroy(gameObject);
            }
        }
    }

    public void CheckOrder()
    {
        if (customerTimer >= bonusPercent * waitTime)
        {

        }
    }
}
