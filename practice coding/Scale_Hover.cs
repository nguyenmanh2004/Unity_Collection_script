using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale_Hover : MonoBehaviour
{
    public bool Hover = false;
    [SerializeField] Ease Ease;
    [SerializeField] float duration;
    [SerializeField] Color _colorEnter;
    
    void OnMouseEnter()
    {
        Hover = true;
        ChangeScaleAndColor(Hover);
    }
    void OnMouseExit()
    {
        
        Hover=false;
        ChangeScaleAndColor(Hover);
    }
    void ChangeScaleAndColor(bool hover)
    {
        transform.DOScale(hover ? new Vector3(1.2f, 1.2f, 0f) : new Vector3(1f, 1f, 0f), duration)
            .SetEase(Ease);  
    }
}

