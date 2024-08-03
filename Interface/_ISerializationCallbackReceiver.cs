using UnityEngine;
using System;

public class MyCustomObject : MonoBehaviour, ISerializationCallbackReceiver
{
    public int someValue = 42;
    private int internalValue;

    private void Start()
    {
        Debug.Log("someValue: " + someValue);
        Debug.Log("internalValue: " + internalValue);
    }

    public void OnBeforeSerialize()
    {
        // Chuẩn bị dữ liệu trước khi object được lưu
        internalValue = someValue * 2;
    }

    public void OnAfterDeserialize()
    {
        // Khôi phục lại trạng thái của object sau khi nó được tải
        internalValue = someValue * 2;
        Debug.Log("OnAfterDeserialize - someValue: " + someValue + ", internalValue: " + internalValue);
    }
}