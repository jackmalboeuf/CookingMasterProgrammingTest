using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerRandomizer : MonoBehaviour
{
    List<int> chosenVegetables = new List<int>();

    public List<int> CreateRandomCustomer(int numberOfVeg)
    {
        chosenVegetables.Clear();

        for (int i = 0; i < numberOfVeg; i++)
        {
            chosenVegetables.Add(Random.Range(0, 6));
        }

        return chosenVegetables;
    }
}
