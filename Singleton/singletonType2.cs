using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysingletonType2 : MonoBehaviour
{

    private static MysingletonType2 instance;

    public static MysingletonType2 Instance
    {
        get
        {
            // nếu chưa có thể hiện singleton
            if (instance == null)
            {
                // tìm kiếm class MysingletonType2 
                instance = FindObjectOfType<MysingletonType2>();
                if (instance == null)
                {
                    // nếu ko tìm thấy thì tạo 1 Game object mới tên là singletonObject
                    GameObject singletonObject = new GameObject();
                    // instance đc gán bằng component class này
                    instance = singletonObject.AddComponent<MysingletonType2>();
                    // gán tên của object này = tên class để khởi tạo
                    singletonObject.name = "MysingletonType2";
                    // ko xoá game object này trong scene
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }

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

