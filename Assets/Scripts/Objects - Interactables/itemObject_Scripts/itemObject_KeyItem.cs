using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Key Item", menuName = "Inventory/New Item/Key Item")]
public class itemObject_KeyItem : itemObject
{
    public void Awake()
    {
        type = itemType.KeyItem;
    }

}
