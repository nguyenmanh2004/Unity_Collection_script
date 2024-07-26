using UnityEngine;

public class moveadd : MonoBehaviour
{
    public float moveTime = 1f;
    [SerializeField] GameObject b;

    private void Update()
    {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));

            iTween.MoveAdd(gameObject, targetPosition - transform.position, moveTime);
        
    }
}
