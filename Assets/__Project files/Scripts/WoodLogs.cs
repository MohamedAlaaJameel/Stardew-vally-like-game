using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(Collider2D))]

public class WoodLogs :MonoBehaviour, IPickable
{

    InventoryItem item;
    public InventoryItem Item { get => item;}

    private void Awake()
    {
        item = new InventoryItem("Wood Log", GetComponent<SpriteRenderer>().sprite, true);
    }


    bool _IsHighlighted;
    public bool IsHighlighted => _IsHighlighted;


    public void HighlightOff()
    {
        var light = GetComponent<Light2D>();
        light.enabled = false;
        _IsHighlighted = false;
    }

    public void HighlightOn()
    {
        var light = GetComponent<Light2D>();
        light.enabled = true;
        _IsHighlighted = true;
    }

    public void OnPick()
    {
      Destroy(gameObject);
    }
 

 
}
