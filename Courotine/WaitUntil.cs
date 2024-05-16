using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitUntilCourotine : MonoBehaviour
{
    public int counter;
    void Start()
    {
        counter = 20;
        StartCoroutine(FuelNotification());
    }
    IEnumerator FuelNotification()
    {
        Debug.Log("Waiting for tank to get empty");
        yield return new WaitUntil(() => counter <= 0);
        Debug.Log("Tank Empty!"); //Notification
    }
    void Update()
    {
        if (counter > 0)
        {
            Debug.Log("Fuel Level: " + counter);
            counter--;
        }
    }
}