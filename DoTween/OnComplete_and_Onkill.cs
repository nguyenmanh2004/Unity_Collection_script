using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OnComplete_and_Onkill : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
    Sequence mySequence = DOTween.Sequence()
    .Append(transform.DOMoveX(3f, 1f))
    .Append(transform.DORotate(new Vector3(0f, 180f, 0f), 1f))
    .OnComplete(() => Debug.Log("Animation sequence completed!"))
    .OnKill(() => Debug.Log("Animation sequence killed!"));
    }
}
