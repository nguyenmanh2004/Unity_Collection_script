using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Open_Website : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textWeb;
    // Start is called before the first frame update
    void Start()
    {
      
    }
    public void OpenWebPage()
    {
        // Mở liên kết web khi Text được nhấn
        Application.OpenURL(textWeb.text);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
