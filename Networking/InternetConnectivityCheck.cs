using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternetConnectivityCheck : MonoBehaviour
{
    void Start()
    {
        CheckInternetConnection();
    }

    void CheckInternetConnection()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            Debug.Log("Kết nối Internet thành công!");
        }
        else
        {
            Debug.Log("Kết nối Internet thất bại!");
        }
    }
}
