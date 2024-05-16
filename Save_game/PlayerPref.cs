using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPref : MonoBehaviour
{
    int number = 0;
    string text="đã hoàn thành 20 number";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // lưu biến save
            PlayerPrefs.SetFloat("save", number);
            number++;
            Debug.Log(number);
            if (number >= 20)
            {
                PlayerPrefs.SetString("datafull", text);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (PlayerPrefs.HasKey("datafull"))
            {
                // lấy ra giá trị biến save
                string savestring = PlayerPrefs.GetString("datafull");
                Debug.Log("Saved string: " + savestring);
            }
            else
            {
                Debug.Log("No saved data found.");
            }
        }
    }
}
