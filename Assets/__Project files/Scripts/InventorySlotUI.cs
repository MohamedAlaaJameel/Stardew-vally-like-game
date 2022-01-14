using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TMPro.TextMeshProUGUI count;
    int slotIndex;
    public int SlotIndex { get { return slotIndex; } set { slotIndex = value; } }
    public Sprite Icon { get { return icon.sprite; } set { icon.sprite = value; } }
    public string Count { get { return count.text; } set { count.text= value; } }

    public void Erease()
    {
        Icon = null;
        Count  = "";
    }
}
