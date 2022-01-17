using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController
{
    public Vector2 MovementVector { get; }
}

public interface IControllerShortCuts
{
    public bool CollectBtn { get; }
    public bool AttackBtn { get; }
    public bool OpenInventoryBtn { get; }
}

 