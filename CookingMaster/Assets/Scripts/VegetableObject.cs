using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Vegetable", menuName = "ScriptableObjects/New Vegetable", order = 1)]
public class VegetableObject : ScriptableObject
{
    public string vegetableName;
    public Sprite unchoppedImage;
    public Sprite choppedImage;
}
