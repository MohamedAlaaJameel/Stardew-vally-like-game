using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Player  
{
    #region Ctor
    public Player
    (
    Transform transform,
    Rigidbody2D rb2d,
    IController controller,
    float pSpeed,
    Animator animator,
    InventoryItemList inventory
    )
    {
        this.rb2d = rb2d;
        this.controller = controller;
        this.transform = transform;
        this.pSpeed = pSpeed;
        this.animator = animator;
        this.inventory = inventory;
    } 
    #endregion
    #region Player movement
    public Vector2 lastFaceDirection;
    float pSpeed;
    Rigidbody2D rb2d;
    IController controller;
    Transform transform;
    public void Move(float customSpeed = 0)
    {
        var motion = controller.MovementVector;
        if (motion != Vector2.zero)
        {
            customSpeed = customSpeed == 0 ? pSpeed : customSpeed;
            rb2d.velocity = (controller.MovementVector * customSpeed);
            lastFaceDirection = controller.MovementVector.normalized;
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    } 
    #endregion
    #region Player Animation
    Animator animator;
    public void RunBlendedAnimation(string xAxisparamName, string yAxisparamName)
    {
        var motion = controller.MovementVector;
        if (motion != Vector2.zero)
        {
            animator.speed = 1;
            animator.SetFloat(xAxisparamName, controller.MovementVector.x);
            animator.SetFloat(yAxisparamName, controller.MovementVector.y);
        }
        else
        {
            animator.speed = 0;
        }

    }
    #endregion
    #region Player game Interactins
    [SerializeField] InventoryItemList inventory;
    /// <summary>
    /// Drop a physics circule in the direction of player to check if collide with any hittable obj
    /// </summary>
    /// <param name="toolDistance"></param>
    /// <param name="DetectionCirculeRadius"></param>
    public void UseTool(float toolDistance, float DetectionCirculeRadius)//TODO : ITool;
    {
        var hittable = GetAreaColliders(toolDistance, (collider) => collider.GetComponent<IHittable>() != null);
        if (hittable != null)
        {
            hittable.GetComponent<IHittable>().Hit();
        }
    }
    public void PickItem(float pickDistance, float DetectionCirculeRadius)
    {
        var hittable = GetAreaColliders(pickDistance, collider => collider.GetComponent<IPickable>() != null);
        if (hittable != null)
        {
            var itemObject = hittable.GetComponent<IPickable>().Item;
            if (inventory.AddItem(itemObject))
            {
                UiInventory.instance.UpdateInventoryUI();//spakety to be remvoed
                hittable.GetComponent<IPickable>().OnPick(transform);//destroy on pick..
            }
        }
    }
    public void Interact(float interactionDistance, float DetectionCirculeRadius)//TODO : ITool;
    {
        var interactable = GetAreaColliders(interactionDistance, collider => collider.GetComponent<IInteractable>() != null);
        if (interactable != null)
        {
            interactable.GetComponent<IInteractable>().Interact();
        }
    }
    Collider2D GetAreaColliders(float distance, Func<Collider2D, bool> predicate)
    {
        Vector2 CirculePos = rb2d.position + lastFaceDirection * distance;
        Collider2D[] allColliders = Physics2D.OverlapCircleAll(CirculePos, distance);
        Collider2D hittable = allColliders.Where(predicate).FirstOrDefault();
        return hittable;
    }

    #endregion
}
