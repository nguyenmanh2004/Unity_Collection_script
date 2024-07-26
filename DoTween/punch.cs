using System.Collections;
using UnityEngine;

public class punch : MonoBehaviour
{
    public GameObject button;
    public float x;
    public float y;
    public float time;
  

    public void punchItween()
    {
        Hashtable args = new Hashtable();
        args.Add("x", x);
        args.Add("y", y);
        args.Add("time", time);
        iTween.PunchScale(button, args);

    }
   
}
