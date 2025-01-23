using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInv : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public int x_start;
    public int y_start;
    public int x_itemspace;
    public int y_itemspace;
    public int columns;
    Dictionary<invSpace, GameObject> itemsDisplayed = new Dictionary<invSpace, GameObject>();
    
    private TextMeshProUGUI TMPROUGUI;
    private RectTransform RT;
    
    void Start()
    {
        //playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        TMPROUGUI = GetComponent<TextMeshProUGUI>();
        RT = GetComponent<RectTransform>();
        CreateDisplay();
    }
    
    void Update()
    {
        UpdateDisplay();
    }
    
    public void CreateDisplay()
    {
        //for (int i = 0; i < playerInventory.Container.Count; i++)
        foreach (var item in playerInventory.Container)
        {
            var obj = Instantiate(item.item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(playerInventory.Container.IndexOf(item));
            obj.GetComponentInChildren<TextMeshProUGUI>().text = item.amount.ToString("n0");
            itemsDisplayed.Add(item, obj);
        }
    }
    
    public Vector3 GetPosition(int i)
    {
        return new Vector3(x_start + ( + x_itemspace * (i % columns)), y_start + (-y_itemspace * (i / columns)), 0f);
    }
    
    public void UpdateDisplay()
    {
        //for (int i = 0; i < playerInventory.Container.Count; i++)
        foreach (var item in playerInventory.Container)
        {
            if (itemsDisplayed.TryGetValue(item, out var obj))
            {
                itemsDisplayed[item].GetComponentInChildren<TextMeshProUGUI>().text = item.amount.ToString("n0");
            }
            else
            {
                obj = Instantiate(item.item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(playerInventory.Container.IndexOf(item));
                obj.GetComponentInChildren<TextMeshProUGUI>().text = item.amount.ToString("n0");
                itemsDisplayed.Add(item, obj);
            }
        }
    }
    
}
