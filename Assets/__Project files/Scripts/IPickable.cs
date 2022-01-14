using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable : IHighlightable
{
    public void OnPick();
    public InventoryItem Item { get; }
  

}
