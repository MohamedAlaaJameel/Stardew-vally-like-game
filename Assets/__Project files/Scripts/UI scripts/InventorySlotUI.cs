using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public delegate void OneParamInvItem(InventorySlotUI item);
    public static event OneParamInvItem OnInventoryItemClick;


    [SerializeField]public Image icon;
    [SerializeField]public TMPro.TextMeshProUGUI count;

    public InventoryItem item;

    public InventoryItem Item
    {
        get { return item; }

        set
        {
            if (value != null)
            {

                item = value;
                icon.sprite = item.itemIcon;
                count.text = item.NumofStackeditems.ToString();
                //  Debug.Log($"Count {count.text}of {item.itemIcon.name}");

            }
            else
            {

                item = value;
                icon.sprite = null;
                count.text = string.Empty;
            }
        }
    }






    private void Awake()
    {

        //  stackedTransfereItems = draggedItemImage.GetComponentInChildren<TMPro.TextMeshProUGUI>();

        var btn = GetComponent<Button>();
        if (btn)
        {
            btn.onClick.AddListener(OnSlotClick);
        }
    }


    public void CleanSlot()
    {
        Item = null;
    }
    private void OnItemDrag(InventoryItem itemPlaceholderItem, InventoryItem slotItem, bool acriveFlag)
    {
     


    }
    public void OnSlotClick()
    {
        OnInventoryItemClick.Invoke(this);
    }

    //private void Update()
    //{
    //    if (!isButtonSet)
    //    {
    //        return;
    //    }
    //    if (itemPlaceHolder.Item != null)
    //    {
    //        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false)
    //        {
    //            if (itemPlaceHolder.Item.orignalPrefab != null)
    //            {
                 
    //                Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //                //GameObject Treefragments = Instantiate(itemPlaceHolder.Item.orignalPrefab);
    //                Debug.Log($"{itemPlaceHolder.Item.itemName}");
    //                GameObject Treefragments=Instantiate(Resources.Load($"{itemPlaceHolder.Item.itemName}")) as GameObject;
 

    //                Treefragments.transform.position = worldPosition;
    //                isButtonSet = false;
    //                itemPlaceHolder.gameObject.SetActive(false);

    //            }
    //        }

    //    }

    //}
}