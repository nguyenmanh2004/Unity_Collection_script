using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class table_list : MonoBehaviour
{
    public MyItem Item = new MyItem();

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
