using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading: MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI text_tb;
    [SerializeField] Slider slider;
    [SerializeField] Canvas spaceCanvas;


    void Start()
    {
        
        TextRandom();
        StartCoroutine(RunSlider());
        CameraSpace();
       


    }
    void CameraSpace()
    {
        Camera mainCamera = Camera.main;

        // Gán camera chính cho canvas không gian
        if (mainCamera != null && spaceCanvas != null)
        {
            spaceCanvas.worldCamera = mainCamera;
            // Nếu cần, có thể thay đổi chế độ render của canvas
            spaceCanvas.renderMode = RenderMode.ScreenSpaceCamera; // Đảm bảo canvas đang ở chế độ World Space
        }
    }
   
    public void TextRandom()
    {
        // Các chuỗi văn bản
        string[] texts = {
            "Chúc bạn chơi game vui vẻ!",
            "1 điều gì đó bí ẩn trong con rắn này.",
            "Không nên chơi quá 180 phút 1 ngày."
        };

        // Random chỉ số
        int randomIndex = Random.Range(0, texts.Length);

        // Gán chuỗi văn bản ngẫu nhiên vào text_tb
        text_tb.text = texts[randomIndex];
    }
    private IEnumerator RunSlider()
    {
        float duration = 1f; // Thời gian chạy trong giây
        float elapsedTime = 0f;

        // Đặt giá trị ban đầu của slider
        slider.value = 0;

        while (elapsedTime < duration)
        {
            // Tính toán giá trị hiện tại của slider
            elapsedTime += Time.deltaTime;
            slider.value = Mathf.Lerp(0, 2, elapsedTime / duration);
            yield return null; // Chờ đến frame tiếp theo
        }
        
        // Đảm bảo rằng slider kết thúc ở giá trị 1
        slider.value = 1;
        int Active = SceneManager.GetActiveScene().buildIndex;
        if (Active == 0)
        {
            SceneManager.LoadScene(1);

        }
        else
        {
            SceneManager.LoadScene(0);

        }

    }
    private void OnEnable()
    {
        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= SceneManager_activeSceneChanged;
    }
    private void SceneManager_activeSceneChanged(Scene newScene, Scene oldScene)
    {

        Destroy(gameObject);
        }
    }      

