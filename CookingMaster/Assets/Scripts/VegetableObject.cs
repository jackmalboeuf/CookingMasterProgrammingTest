using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Vegetable", menuName = "ScriptableObjects/New Vegetable", order = 1)]
public class VegetableObject : ScriptableObject
{
    public enum Vegetables { Beet, Carrot, Cauliflower, Celery, Corn, Lettuce };

    public Vegetables vegetableName;
    public Sprite unchoppedImage;
    public Sprite choppedImage;
}
