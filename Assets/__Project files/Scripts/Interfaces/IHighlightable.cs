using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHighlightable
{
   public void HighlightOn();
   public void HighlightOff();
    public bool IsHighlighted { get; }
}
