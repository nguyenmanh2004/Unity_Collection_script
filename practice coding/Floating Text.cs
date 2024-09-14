using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class FloatingText : MonoBehaviour
{
    [SerializeField] private float moveDistance;  // Khoảng cách bay lên
    [SerializeField] private float duration = 0.3f; // Thời gian bay lên
    private Color[] rainbowColors = new Color[]
 {
        Color.red,
        Color.yellow,
        Color.green,
        Color.cyan,
        Color.blue,
        Color.magenta,
        Color.black,
        new Color(1.0f, 0.5f, 0.0f) // Màu cam
 };

    private void Start()
    {
        // Bắt đầu hiệu ứng bay lên
        FlyUp();
        
    }

    public void FlyUp()
    {

        Color randomColor = rainbowColors[Random.Range(0, rainbowColors.Length)];
        GetComponent<TextMeshProUGUI>().color = randomColor;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveY(transform.parent.position.y+moveDistance, duration)); // Bay lên
        sequence.Append(GetComponent<TextMeshProUGUI>().DOFade(0, duration)); // Mờ dần (sẽ bắt đầu sau khi bay lên)
        sequence.Append(transform.DOScale(1.5f, duration)); // Phóng to (sẽ bắt đầu sau khi mờ dần)
        sequence.OnComplete(() => Destroy(transform.parent.gameObject)); // Xóa đối tượng sau khi hoàn tất
    }
}

