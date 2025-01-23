using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Interactable", menuName = "Environment/New Interactable")]
public class itemObject_Interactable : itemObject
{
    public void Awake()
    {
        type = itemType.Interactable;
    }

}
