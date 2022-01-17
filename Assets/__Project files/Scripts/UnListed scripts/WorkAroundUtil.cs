using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class WorkAroundUtil 
{
     
    private static FieldInfo _LightCookieSprite = typeof(Light2D).GetField("m_LightCookieSprite", BindingFlags.NonPublic | BindingFlags.Instance);
    public static void UpdateCookieSprite(Sprite sprite, Light2D _light2D)
    {
        _LightCookieSprite.SetValue(_light2D, sprite);
    }
}
