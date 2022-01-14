using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryItemList : ScriptableObject
{
    public List<InventoryItem> itemList;
    public int maxSize = 20;
    public bool addItem(InventoryItem item)
    {
        if (itemList.Count<maxSize)
        {
            itemList.Add(item);
            return true;
        }
        else
        {
            Debug.Log($"Full Enventory");
            return false;
        }
    }
}