using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ping : MonoBehaviour
{
    public string ipAddress ; // Địa chỉ IP cần ping
    // tạo 1 biến kiểu ping tên là pingip
    private Ping pingip;

    private void Start()
    {
        StartCoroutine(PerformPing());
    }
    IEnumerator PerformPing()
    {
        // pingip ping đến ipAddress
        pingip = new Ping(ipAddress);
        //nếu chưa thành công thì null 
        while (!pingip.isDone)
        {
            yield return null;
        }
        // nếu time ping >0 hiển trị số ms
        if (pingip.time >= 0)
        {
            Debug.Log("Ping time: " + pingip.time + "ms");
        }
         // nếu ping false 
        else
        {
            Debug.Log("Ping failed.");
        }
    }
}
