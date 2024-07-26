using UnityEngine;
using System.Collections;

public class ColorToExample : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Color endColor;
    [SerializeField] private float duration = 1.0f;

    private Color startColor;

    private void Start()
    {
        startColor = target.GetComponent<Renderer>().material.color;
        StartCoroutine(AnimateColor());
    }

    private IEnumerator AnimateColor()
    {
        iTween.ColorTo(target, iTween.Hash("color", endColor, "time", duration));
        yield return new WaitForSeconds(duration);
        target.GetComponent<Renderer>().material.color = startColor;
    }
}