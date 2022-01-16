using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDraggedItems : MonoBehaviour
{

    private void Update()
    {
        var pos=Input.mousePosition;
        transform.position = pos;
    }
}
