﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScaleButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    bool mouseOver = false;
    bool mouseOverExit = false;
    Vector3 minScale;
    Vector3 currentScale;
    public Vector3 targetScale;
    public float  targetSacaleAfter;
    private Vector3 maxScale;

    private void Start()
    {
        maxScale = targetScale * targetSacaleAfter;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
        mouseOverExit = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
        mouseOverExit = true;
    }

    void Update()
    {
        if (mouseOver)
        {
            minScale = transform.localScale;
            transform.localScale = Vector2.Lerp(minScale, maxScale, .25f);
        }

        if (mouseOverExit)
        {
            currentScale = transform.localScale;
            transform.localScale = Vector2.Lerp(currentScale, targetScale, .25f);
        }
    }
}