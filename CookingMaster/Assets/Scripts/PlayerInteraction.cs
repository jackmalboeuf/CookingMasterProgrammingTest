using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public RectTransform vegetableHolder;
    public Slider chopTimerSlider;
    public string interactButton;
    public bool isHoldingPlate = false;

    Transform plate;
    Transform plateVegetableHolder;

    //the bool below is used for getting input while a trigger is being touched 
    //because checking input in physics functions (fixed update, on trigger stay) is inconsistent
    bool isTouchingPlate = false;

    private void Update()
    {
        //checking input in update for the reason outlined above
        if (Input.GetButtonDown(interactButton))
        {
            //pick up plate
            if (isTouchingPlate)
            {
                plate.SetParent(transform);
                plate.localPosition = new Vector3(0, -0.4f, -1);
                plate.GetComponent<Collider2D>().enabled = false;
                plate.GetComponent<PlateBehavior>().holdingPlayer = this;
                isHoldingPlate = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //handle various behaviors when colliding with different object types
        if (collision.GetComponent<VegetableSpawner>() && !isHoldingPlate)  //pick up vegetable
        {
            collision.GetComponent<VegetableSpawner>().SpawnVegetable(vegetableHolder);
        }
        else if (collision.GetComponent<ChoppingTable>() && !isHoldingPlate)    //chop vegetables at chopping table
        {
            collision.GetComponent<ChoppingTable>().ChopVegetables(vegetableHolder);
        }
        else if (collision.GetComponent<PlateBehavior>())   //putting vegetables on the plate
        {
            collision.GetComponent<PlateBehavior>().PlaceObjectOnPlate(vegetableHolder);
            isTouchingPlate = true;
            plate = collision.transform;
            plateVegetableHolder = plate.GetChild(0).transform;
        }
        else if (collision.GetComponent<CustomerBehavior>() && isHoldingPlate && plateVegetableHolder != null)  //give plate to customer
        {
            collision.GetComponent<CustomerBehavior>().CheckOrder(plateVegetableHolder, GetComponent<PlayerScore>());
        }
        else if (collision.GetComponent<TrashFood>())   //throw food in the trash
        {
            collision.GetComponent<TrashFood>().DeleteFood(vegetableHolder, plate);
            plate = null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //the plate's collider is turned off if the player picks it up 
        //so isTouchingPlate will be false even if the player is carrying the plate
        if (collision.GetComponent<PlateBehavior>())
        {
            isTouchingPlate = false;
        }
    }
}
