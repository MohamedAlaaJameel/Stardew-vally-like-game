using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable : IHighlightable
{
  public void Hit();
}
