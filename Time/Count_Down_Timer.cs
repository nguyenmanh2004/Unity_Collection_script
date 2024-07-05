using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class count_down_timer : MonoBehaviour
{
    public float countdownTimer ; // Biến public để countDown

    void Update()
    {
        // Giảm countdownTimer theo thời gian deltaTime
        countdownTimer -= Time.deltaTime;

        // Kiểm tra nếu countdownTimer đã về 0 hoặc thấp hơn
        if (countdownTimer <= 0)
        {
            // Thực hiện hành động khi countdownTimer về 0
            Debug.Log("Countdown finished!");
        }
    }
}
