using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public Slider lerp;
    public Slider move_Towards;
    public Slider Pingpong;
    float t = 0;
    private void Start()
    {
        // Initialize the slider values
        lerp.minValue = 0f;
        lerp.maxValue = 1f;
        lerp.value = lerp.minValue;

        move_Towards.minValue = 0f;
        move_Towards.maxValue = 1f;
        move_Towards.value = move_Towards.minValue;

        Pingpong.minValue = 0f;
        Pingpong.maxValue = 1f;
        Pingpong.value = Pingpong.minValue;
        
    }

    void Update()
    {
        t += 0.1f * Time.deltaTime;
        // Lerp
        lerp.value = Mathf.Lerp(lerp.minValue, lerp.maxValue, t);

        // MoveTowards
        move_Towards.value = Mathf.MoveTowards(move_Towards.value, move_Towards.maxValue, 0.2f * Time.deltaTime);

        // Pingpong
        Pingpong.value = Mathf.PingPong(Time.time, 1f);
    }
}
