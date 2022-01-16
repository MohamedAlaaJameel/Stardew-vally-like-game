using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class InventoryItemList : ScriptableObject
{
    public List<InventoryItem> itemList;
    public  const int maxSize = 20;
    public bool AddItem(InventoryItem item)
    {
        if (itemList.Count < maxSize)
        {
            if (item.isStackable)
            {
                var similarItems = itemList.Where(i => i.itemName != string.Empty && i.itemName == item.itemName);
                if (similarItems.IsAny())
                {
                    similarItems.First().NumofStackeditems += item.NumofStackeditems;
                }
                else
                {
                    itemList.Add(item);
                }
            }
            else
            {
                itemList.Add(item);
            }
            return true;
        }
        else
        {
            Debug.Log($"Full Enventory");
            return false;
        }
    }
}