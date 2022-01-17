using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceHolder : MonoBehaviour
{
    public delegate void UidDelegate(InventoryItem itemName, Vector2 pos);//todo int for item unique id
    public static event UidDelegate SpawnItem;

    public delegate void InventoryItemDelegate(InventoryItem item);
    public static event InventoryItemDelegate removeFromDataInventory;


    [SerializeField] InventorySlotUI placeHolder;
     InventorySlotUI tempHolder;
     //


    // Start is called before the first frame update

    private void Awake()
    {
        placeHolder.Item = new InventoryItem();
        tempHolder = Instantiate(placeHolder);
        tempHolder.Item = new InventoryItem();
        tempHolder.gameObject.SetActive(false);

    }
    private void OnEnable()
    {
        InventorySlotUI.OnInventoryItemClick += SetPlaceHolderData;
    }
    private void OnDisable()
    {
        InventorySlotUI.OnInventoryItemClick -= SetPlaceHolderData;
    }
    void SetPlaceHolderData(InventorySlotUI slot )
    {
        Debug.Log($"event called");
        #region placeholder already have item 
        if (placeHolder.gameObject.activeInHierarchy)
        {

            if ((slot.Item == null || string.IsNullOrEmpty(slot.Item.itemName)))
            {
                slot.Item = new InventoryItem();
                TransfereData(slot, placeHolder);
                placeHolder.gameObject.SetActive(false);
                return;
            }
            else if (!string.IsNullOrEmpty(slot.Item.itemName))
            {
                TransfereData(tempHolder, slot);
                TransfereData(slot, placeHolder);
                TransfereData(placeHolder, tempHolder);
                return;
            }

        }

        #endregion
        #region First press On empty slot
        if (slot.Item == null || string.IsNullOrEmpty(slot.Item.itemName))
        {
            Debug.Log($"null item return");
            return;
        }
        #endregion
        #region First press on slot has item
        TransfereData(placeHolder, slot);
        slot.Item = null;

        #endregion

        placeHolder.gameObject.SetActive(true);

    }
    void TransfereData(InventorySlotUI Dest, InventorySlotUI Source)
    {

        Dest.Item.isStackable =          Source.item.isStackable;
        Dest.Item.itemIcon =             Source.item.itemIcon;
        Dest.Item.itemName =             Source.item.itemName;
        Dest.Item.NumofStackeditems =    Source.item.NumofStackeditems;
        Dest.Item.orignalPrefab =        Source.item.orignalPrefab;
        Dest.icon.sprite =               Source.item.itemIcon;
        Dest.count.text =                Source.item.NumofStackeditems.ToString();
        Dest.Item.UniqueServerID =       Source.item.UniqueServerID;
    }
    private void Update()
    {
        if (placeHolder!=null &&placeHolder.gameObject.activeInHierarchy&&!string.IsNullOrEmpty(placeHolder.Item.itemName))
        {
            if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false)
            {
                Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                removeFromDataInventory.Invoke(placeHolder.Item);
                SpawnItem.Invoke(placeHolder.Item, worldPosition);

                placeHolder.gameObject.SetActive(false);
            }
        }

       

    }
}
