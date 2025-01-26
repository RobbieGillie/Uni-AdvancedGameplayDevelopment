using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item/Default Item")]

public class itemObject_Default : itemObject
{
    public void Awake()
    {
        type = itemType.Default;
    }
}
