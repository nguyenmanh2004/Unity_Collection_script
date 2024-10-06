using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Networking;

public class Webrequestjson : MonoBehaviour
{
    // Start is called before the first frame update
    
        IEnumerator Start()
        {
            using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:4000/ap1/test"))
            {
                // Gửi yêu cầu và chờ phản hồi
                yield return request.SendWebRequest();

                // Kiểm tra lỗi
                if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    //Debug.LogError("Lỗi: " + request.error);
                }
                else
                {
                    // Xử lý dữ liệu nhận được
                    Debug.Log("Dữ liệu: " + request.downloadHandler.text);

                }
                info info1 = JsonUtility.FromJson<info>(request.downloadHandler.text);
                Debug.Log(info1.message);
                Debug.Log(info1.success);
                Debug.Log(info1.timestamp);
            }
        }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    [Serializable]
    public class info
    {
        public string message;
        public bool success;
        public string timestamp;
    }
}
