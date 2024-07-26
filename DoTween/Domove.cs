using UnityEngine;
using DG.Tweening;
public class Domove : MonoBehaviour
{
    public Transform targetPosition;
    public float duration = 3f;
    public bool snapping = false;

    private void Update()
    {
        // Di chuyển đối tượng đến vị trí mục tiêu
        transform.DOMove(targetPosition.position, duration, snapping);
    }
}
