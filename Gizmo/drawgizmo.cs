using UnityEditor;
using UnityEngine;

public class MyGizmoDrawer : MonoBehaviour
{
    [SerializeField] Vector2Int m_Position;
    [DrawGizmo(GizmoType.Selected | GizmoType.Active)]
    private void OnDrawGizmos()
    {
        // Vẽ Gizmo chỉ khi đối tượng được chọn hoặc đang hoạt động
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(m_Position.x,m_Position.y,0f));
    }
}