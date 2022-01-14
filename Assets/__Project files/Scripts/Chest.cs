using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Chest :MonoBehaviour, IInteractable , IHighlightable
{
    Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();

    }
    public void Interact()
    {
        animator.SetBool("isOpen", true);
    }


    #region HighLight
    bool _IsHighlighted;
    public bool IsHighlighted { get => _IsHighlighted; }

    public void HighlightOn()
    {
        var light = GetComponent<Light2D>();
        light.enabled = true;
        _IsHighlighted = true;
    }

    public void HighlightOff()
    {
        var light = GetComponent<Light2D>();
        light.enabled = false;
        _IsHighlighted = false;

    }
    #endregion
}
