using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitforsecond : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(DoSomething());
    }
    private IEnumerator DoSomething()
    {
        Debug.Log("Bắt đầu Coroutine");

        // Đợi 2 giây
        yield return new WaitForSeconds(2f);

        Debug.Log("Đợi 2 giây!");

        // Thực hiện hành động khác
        Debug.Log("Tiếp tục thực hiện hành động sau khi đợi xong");
    }

}
