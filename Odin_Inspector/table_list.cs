using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class table_list : MonoBehaviour
{
    // t?o m?i 1 th? hi?n c?a thu?c tính 

    public MyItem Item = new MyItem();

    // t?o m?i  1 table c?a th? hi?n ?ó
    [TableList]
    public List<MyItem> Table = new List<MyItem>()
{
    new MyItem(),
    new MyItem(),
    new MyItem(),
};

    [Serializable]
    public class MyItem
    {
        public string A;

        public int B;

    }
}
