using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class Child_Game_Objects : MonoBehaviour
{
    // Khi [ChildGameObjectsOnly] được áp dụng cho một biến, nó áp đặt một ràng buộc trên trình chỉnh sửa Inspector

    // của Unity. Ràng buộc này đảm bảo rằng chỉ các đối tượng con hoặc chính nó của đối tượng chứa

    // script mới có thể được gán vào biến.

    [ChildGameObjectsOnly]
    public Transform ChildOrSelfTransform;

    [ChildGameObjectsOnly]
    public GameObject ChildGameObject;

 
}
