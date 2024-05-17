using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class time : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timetext;
    void Start()
    {
        timetext= GetComponent<TextMeshProUGUI>();
        Updatetime();
    }

    // Update is called once per frame
    void Update()
    {
        Updatetime();
    }
    void Updatetime()
    {
        System.DateTime currentime = System.DateTime.Now;
        timetext.text = currentime.ToString("HH:mm:ss");
    }
}
