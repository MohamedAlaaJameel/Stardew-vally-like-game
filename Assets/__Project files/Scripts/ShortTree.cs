using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using DG.Tweening;
public class ShortTree : MonoBehaviour,IHittable
{
    Vector3 treeScale;
    private void Start()
    {
        treeScale = transform.localScale;
    }
    bool _IsHighlighted;
    public bool IsHighlighted => _IsHighlighted;
    public void HighlightOff()
    {
        var sprite = GetComponent<SpriteRenderer>().sprite;
        var light = GetComponent<Light2D>();
        light.lightType = Light2D.LightType.Sprite;
        WorkAroundUtil.UpdateCookieSprite(sprite, light);
        light.enabled = false;
        _IsHighlighted = false;
    }
    public void HighlightOn()
    {
        var sprite=GetComponent<SpriteRenderer>().sprite;
        var light = GetComponent<Light2D>();
        light.lightType = Light2D.LightType.Sprite;
        WorkAroundUtil.UpdateCookieSprite(sprite, light);
        light.enabled = true;
        _IsHighlighted = true;
    }
    public void Hit()
    {
        transform.DOScale(treeScale * 1.5f, .15f).SetEase(Ease.OutBounce).OnComplete(delegate(){
            transform.DOScale(treeScale, .15f).SetEase(Ease.OutBounce);
            });
       // Destroy(this.gameObject);
    }
}
