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
    static int uniqueID=33330;
    public void UpdateInventoryUI()
    {
        slotsUI.ForEach(t =>t.CleanSlot());
        for (int i = 0; i < slotsUI.Count && i < InventorySO.itemList.Count; i++)
        {
            uniqueID++;
            InventorySO.itemList[i].UniqueServerID = uniqueID;
            slotsUI[i].Item = InventorySO.itemList[i];
  

        }
        
    }
}
