using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum itemType
{
    Interactable,
    KeyItem,
    Default,
}
public class itemObject : ScriptableObject
{
    public GameObject prefab;
    public itemType type;
    [TextArea(15, 20)]
    public string description;
    
    
}

