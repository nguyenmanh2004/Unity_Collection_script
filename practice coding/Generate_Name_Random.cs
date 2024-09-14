using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Generate_Name : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textname;
    public int typenameFemmale = 5;
    public int typenameMale = 6;
    public string curentName;
    // Start is called before the first frame update
    void Start()
    {
        textname.text = "name";
    }
    public void SetnameFemale()
    {
        do
        {
            textname.text = string.Empty; // Đặt lại textname.text thành rỗng
            string curentName = NVJOBNameGen.Uppercase(NVJOBNameGen.GiveAName(typenameFemmale));
            textname.text = curentName; // Gán tên mới
        } while (string.IsNullOrEmpty(textname.text));
    }
    public void SetnameMale()
    {
        do
        {
            textname.text = string.Empty; // Đặt lại textname.text thành rỗng
            string curentName = NVJOBNameGen.Uppercase(NVJOBNameGen.GiveAName(typenameMale));
            textname.text = curentName; // Gán tên mới
        } while (string.IsNullOrEmpty(textname.text));
    }
}
