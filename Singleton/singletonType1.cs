using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

    public class MySingletonType1 : MonoBehaviour
    {
    // tạo 1 biến chung của lớp MySingletonType1 , private set để hạn chế truy cập từ bên ngoài 
    public static MySingletonType1 instance { get; private set; }
 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void DoSomething()
    {
        Debug.Log("Doing something...");
    }
}

