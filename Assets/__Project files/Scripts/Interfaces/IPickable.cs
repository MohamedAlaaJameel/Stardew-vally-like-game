using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable : IHighlightable
{
    public void OnPick(Transform picker=null);
    public InventoryItem Item { get; }
  

}
