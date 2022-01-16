using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : MonoBehaviour, IPickable
{
    [SerializeField] protected string itemName= "";
    [SerializeField] protected bool stackable;
    [SerializeField] protected GameObject orignalPrefab;
   protected InventoryItem item;
    public InventoryItem Item { get => item; }

    private void Awake()
    {
        item = new InventoryItem(itemName, GetComponent<SpriteRenderer>().sprite, orignalPrefab, stackable);
    }


    protected bool _IsHighlighted;
    public virtual bool IsHighlighted => _IsHighlighted;


    public virtual void HighlightOff()
    {
 
    }

    public virtual void HighlightOn()
    {
 
    }

    public virtual void OnPick(Transform picker = null)
    {
        Destroy(gameObject);
    }



}
