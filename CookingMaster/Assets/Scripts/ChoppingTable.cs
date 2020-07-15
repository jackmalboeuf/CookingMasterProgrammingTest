using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoppingTable : MonoBehaviour
{
    Transform currentVegetable;
    GameObject player;
    Slider chopSlider;
    Transform vegetableHolder;

    float chopTimer = 0;
    float chopSpeed = 2;
    bool canInteract = true;

    public void ChopVegetables(Transform holder)
    {
        //prevents activation of method if player has no unchopped vegetables and prevents other player from using same table
        if (canInteract && holder.childCount > 0 && !holder.GetChild(0).GetComponent<VegetableState>().isChopped)
        {
            //store component in variables
            currentVegetable = holder.GetChild(0);
            player = holder.parent.gameObject;
            chopSlider = player.GetComponent<PlayerInteraction>().chopTimerSlider;
            vegetableHolder = holder;

            //put vegetable on plate
            currentVegetable.SetParent(transform.GetChild(0));
            currentVegetable.position = new Vector3(transform.position.x, transform.position.y, -1);

            //start chopping process
            chopTimer = chopSpeed;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            chopSlider.gameObject.SetActive(true);
            chopSlider.maxValue = chopSpeed;
            chopSlider.value = chopSlider.maxValue;
            canInteract = false;
        }
    }

    private void Update()
    {
        //chopping timer
        if (chopTimer > 0)
        {
            //subtract time each frame
            chopTimer -= Time.deltaTime;
            chopSlider.value = chopTimer;

            //when timer hits 0 reset everything
            if (chopTimer <= 0)
            {
                chopTimer = 0;
                player.GetComponent<PlayerMovement>().enabled = true;
                player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                chopSlider.gameObject.SetActive(false);
                currentVegetable.GetComponent<Image>().sprite = currentVegetable.GetComponent<VegetableState>().vegetableSettings.choppedImage;
                currentVegetable.GetComponent<VegetableState>().isChopped = true;
                currentVegetable.SetParent(vegetableHolder);
                currentVegetable.position = new Vector2(0, 0);
                canInteract = true;
            }
        }
    }
}
