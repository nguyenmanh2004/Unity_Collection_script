using System.Collections;
using TMPro;
using UnityEngine;

public class ValueTo : MonoBehaviour
{
    public float time1;
    public float startvalue;
    public float endvalue;
    public TextMeshProUGUI text;

    private void Start()
    {
        Hashtable args = new Hashtable
        {
            { "from", startvalue },
            { "to", endvalue },
            { "time", time1 },
            { "onupdate", "OnValueChange" }
        };

        iTween.ValueTo(this.gameObject, args);
    }

    private void OnValueChange(float value)
    {
        text.text = Mathf.FloorToInt (value).ToString();
    }
}