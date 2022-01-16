using UnityEngine;
using System.Collections;

[System.Serializable]                         //    Our Representation of an InventoryItem
public class InventoryItem
{
    public InventoryItem()
    {
        UniqueServerID += 1;
    }
    public InventoryItem(string itemName, Sprite itemIcon, GameObject orignalPrefab, bool isStackable = false,int NumofStackeditems=1)
    {
        this.isStackable = isStackable;
        this.itemIcon = itemIcon;
        this.itemName = itemName;
        this.NumofStackeditems = NumofStackeditems;
        this.orignalPrefab = orignalPrefab;
    }
    public GameObject orignalPrefab;
    public int NumofStackeditems=1;
    public static int UniqueServerID=1;
    public string itemName = string.Empty;      //    What the item will be called in the inventory
    public Sprite itemIcon = null;         //    What the item will look like in the inventory
    //public Rigidbody2D itemObject = null;       //    Optional slot for a PreFab to instantiate when discarding
    public bool isUnique = false;             //    Optional checkbox to indicate that there should only be one of these items per game
    public bool isIndestructible = false;     //    Optional checkbox to prevent an item from being destroyed by the player (unimplemented)
    public bool isQuestItem = false;          //    Examples of additional information that could be held in InventoryItem
    public bool isStackable = false;          //    Examples of additional information that could be held in InventoryItem
    public bool destroyOnUse = false;         //    Examples of additional information that could be held in InventoryItem
    public float encumbranceValue = 0;        //    Examples of additional information that could be held in InventoryItem  !!!
}