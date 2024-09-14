using UnityEngine;
using UnityEngine.UI; // Thêm thư viện này để sử dụng RawImage

public class WebCamController : MonoBehaviour
{
    private WebCamTexture webcamTexture;
    [SerializeField] private RawImage rawImage; // Tham chiếu đến RawImage

    void Start()
    {
        // Lấy danh sách các webcam
        WebCamDevice[] devices = WebCamTexture.devices;

        // Kiểm tra xem có camera nào không
        if (devices.Length > 0)
        {
            // Sử dụng webcam đầu tiên
            webcamTexture = new WebCamTexture(devices[0].name);
            // Gán WebCamTexture cho RawImage
            rawImage.texture = webcamTexture;

            // Bắt đầu webcam
            webcamTexture.Play();
        }
        else
        {
            Debug.LogError("No webcam found!");
        }
    }

    void OnDisable()
    {
        // Dừng webcam khi không còn cần thiết
        if (webcamTexture != null && webcamTexture.isPlaying)
        {
            webcamTexture.Stop();
        }
    }
}