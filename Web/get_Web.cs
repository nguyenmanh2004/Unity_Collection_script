using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.IO;

public class UnityWebRequestGetExample : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(GetRequest("https://www.facebook.com/"));
    }

    private IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                string responseText = webRequest.downloadHandler.text;
                Debug.Log(responseText);
                
                // Lưu nội dung vào file .txt
                string filePath = "E:\\response.txt";

                // Lưu nội dung vào file .txt
                File.WriteAllText(filePath, responseText);
                
                Debug.Log("File saved at: " + filePath);
            }
        }
    }
}