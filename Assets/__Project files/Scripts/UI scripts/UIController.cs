using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject InventoryPanel;
    IControllerShortCuts shortcutController;

    private void Start()
    {
        shortcutController = new KeyboardMouse();
    }

    private void Update()
    {
        if (InventoryPanel==null)
        {
            Debug.Log($"InventoryPanel is not aassigned");
            return;
        }
        if (shortcutController.OpenInventoryBtn)
        {
            InventoryPanel.SetActive(!InventoryPanel.activeInHierarchy);
        }
    }

}
