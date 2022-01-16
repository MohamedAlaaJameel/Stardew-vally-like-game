using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{

    [SerializeField] Image icon;
    [SerializeField] TMPro.TextMeshProUGUI count;
    [SerializeField] InventorySlotUI itemPlaceHolder;
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
    private void Start()
    {
        itemPlaceHolder.gameObject.SetActive(false);
    }
    public void CleanSlot()
    {
        Item = null;
    }
    private void OnItemDrag(InventoryItem itemPlaceholderItem, InventoryItem slotItem, bool acriveFlag)
    {
        itemPlaceHolder.Item = itemPlaceholderItem;
        Item = slotItem;
        itemPlaceHolder.gameObject.SetActive(acriveFlag);

    }
    public void OnSlotClick()
    {
        if (Item != null)
        {
            if (itemPlaceHolder.Item == null)
            {
                OnItemDrag(Item, null,true); 
            }
            else
            {
                OnItemDrag(Item, itemPlaceHolder.Item, true);
            }
        }
        else
        {
            if (itemPlaceHolder.Item != null)
            {
                OnItemDrag(null, itemPlaceHolder.Item, false);
            }
        }

    }

    private void Update()
    {
        if (itemPlaceHolder.Item!=null)
        {
            if (Input.GetMouseButton(0) && EventSystem.current.IsPointerOverGameObject() == false)
            {
                if (Item!=null&& Item.orignalPrefab != null)
                {
                    GameObject Treefragments = Instantiate(Item.orignalPrefab);
                    Treefragments.transform.position = transform.position;
                }
            }
        }

    }
}
