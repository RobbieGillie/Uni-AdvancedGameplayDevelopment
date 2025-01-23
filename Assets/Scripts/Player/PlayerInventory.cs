using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/New Inventory")]
public class PlayerInventory : ScriptableObject
{
    public List<invSpace> Container = new List<invSpace>();

    public void AddItem(itemObject _item, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            Container.Add(new invSpace(_item, _amount));
        }
    }
    
    public void HasKey(int keyIndex)
    {
        Container[keyIndex].AddAmount(1);
    }
}

[System.Serializable]
public class invSpace
{
    public itemObject item;
    public int amount;
    public invSpace(itemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    
    public void AddAmount(int value)
    {
        amount += value;
    }
}