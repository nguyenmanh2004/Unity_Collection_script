using UnityEngine;

public class BezierCurve3 : MonoBehaviour
{


    [SerializeField] Transform TransformA;
    [SerializeField] Transform TransformB;
    [SerializeField] Transform TransformC;
    [SerializeField] Transform TransformD;
    public Vector2 pointA; // Điểm bắt đầu
    public Vector2 pointB; // Điểm kiểm soát 1
    public Vector2 pointC; // Điểm kiểm soát 2
    public Vector2 pointD; // Điểm kết thúc

    public float duration = 2.0f; // Thời gian di chuyển
    private float t = 0.0f; // Tham số t
    private void Start()
    {
        pointA = TransformA.position;
        pointB = TransformB.position;
        pointC = TransformC.position;
        pointD = TransformD.position;
    }
    void Update()
    {
        // Tăng tham số t theo thời gian
        t += Time.deltaTime / duration;

        // Tính toán điểm trên đường cong
        Vector2 pointOnCurve = CalculateBezierPoint(t, pointA, pointB, pointC, pointD);

        // Di chuyển đối tượng đến điểm trên đường cong
        transform.position = pointOnCurve;

        // Reset lại t khi đã đến điểm cuối
        if (t >= 1.0f)
        {
            t = 0.0f; // Hoặc bạn có thể dừng lại
        }
    }

    Vector2 CalculateBezierPoint(float t, Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector2 p = uuu * p0; // (1-t)^3 * P0
        p += 3 * uu * t * p1; // 3 * (1-t)^2 * t * P1
        p += 3 * u * tt * p2; // 3 * (1-t) * t^2 * P2
        p += ttt * p3; // t^3 * P3

        return p;
    }
}