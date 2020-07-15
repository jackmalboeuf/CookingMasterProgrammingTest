using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public RectTransform vegetableHolder;
    public Slider chopTimerSlider;
    public string interactButton;

    Transform plate;
    Transform plateVegetableHolder;
    bool isHoldingPlate = false;
    bool isTouchingPlate = false;

    private void Update()
    {
        if (Input.GetButtonDown(interactButton))
        {
            if (isTouchingPlate)
            {
                plate.SetParent(transform);
                plate.localPosition = new Vector3(0, -0.4f, -1);
                plate.GetComponent<Collider2D>().enabled = false;
                isHoldingPlate = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<VegetableSpawner>())
        {
            collision.GetComponent<VegetableSpawner>().SpawnVegetable(vegetableHolder);
        }
        else if (collision.GetComponent<ChoppingTable>())
        {
            collision.GetComponent<ChoppingTable>().ChopVegetables(vegetableHolder);
        }
        else if (collision.GetComponent<PlateBehavior>())
        {
            collision.GetComponent<PlateBehavior>().PlaceObjectOnPlate(vegetableHolder);
            isTouchingPlate = true;
            plate = collision.transform;
            plateVegetableHolder = plate.GetChild(0).transform;
        }
        else if (collision.GetComponent<CustomerBehavior>() && isHoldingPlate && plateVegetableHolder != null)
        {
            collision.GetComponent<CustomerBehavior>().CheckOrder(plateVegetableHolder);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlateBehavior>())
        {
            isTouchingPlate = false;
        }
    }
}
