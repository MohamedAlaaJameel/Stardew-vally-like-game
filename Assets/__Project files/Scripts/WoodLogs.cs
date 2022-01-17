using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(Collider2D))]

public class WoodLogs :GroundItem
{
  
    private void Awake()
    {   
        item = new InventoryItem(itemName, GetComponent<SpriteRenderer>().sprite, orignalPrefab, true);
       
    }

    public override void HighlightOn()
    {
        base.HighlightOn();
        var light = GetComponent<Light2D>();
        light.enabled = true;
        _IsHighlighted = true;
    }
    public override void HighlightOff()
    {
        base.HighlightOff();
        var light = GetComponent<Light2D>();
        light.enabled = false;
        _IsHighlighted = false;
    }
}
