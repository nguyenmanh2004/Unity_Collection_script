using UnityEngine;

public class moveto : MonoBehaviour
{
   
    public float timer;
    public iTween.EaseType easeType;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 positionfollow = new Vector3(position.x,position.y,0);
            iTween.MoveTo(this.gameObject, iTween.Hash("position",positionfollow,"time", timer, "easetype", easeType));
        }
    }
}