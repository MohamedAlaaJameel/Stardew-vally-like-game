using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMouse : IController,IControllerShortCuts
{
    public float xAxis => Input.GetAxisRaw("Horizontal");
    public float YAxis => Input.GetAxisRaw("Vertical");
    public Vector2 MovementVector => new Vector2(xAxis, YAxis);

    public bool CollectBtn => Input.GetMouseButtonDown(1);
    public bool AttackBtn => Input.GetMouseButtonDown(0);

    public bool OpenInventoryBtn => Input.GetKeyDown(KeyCode.I);
}
