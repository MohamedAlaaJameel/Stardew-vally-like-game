using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UiInventory : MonoBehaviour
{
    [SerializeField] InventoryItemList InventorySO;
    [SerializeField] List<InventorySlotUI> slotsUI;

    public static UiInventory instance;
    private void Awake()
    {
        UpdateInventoryUI();
        instance = this;
    }


    public void UpdateInventoryUI()
    {
        for (int i = 0; i < slotsUI.Count&& i < InventorySO.itemList.Count; i++)
        {
            var icon = InventorySO.itemList[i].itemIcon;

            slotsUI[i].Icon = icon;
        }
    }
}
