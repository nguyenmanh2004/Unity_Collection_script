using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AvatarChange : MonoBehaviour
{
    public Image imageComponent;

    public void UploadAvatar()
    {

        // Hiển thị cửa sổ tệp để người dùng chọn
        string selectedFile = EditorUtility.OpenFilePanelWithFilters("Select an image file", Application.dataPath, new string[] { "Image files", "*.png;*.jpg;*.jpeg;*.gif" });

        // Kiểm tra xem người dùng đã chọn tệp tin hay chưa
        if (!string.IsNullOrEmpty(selectedFile) && File.Exists(selectedFile))
        {
            // Hiển thị thông tin về tệp tin đã chọn
            Debug.Log("Selected file: " + selectedFile);

            // Tải ảnh từ tệp tin đã chọn
            Texture2D texture = LoadTextureFromFile(selectedFile);

            // Gán ảnh vào Image component
            imageComponent.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
        else
        {
            Debug.Log("No file selected.");
        }
    }

    private Texture2D LoadTextureFromFile(string filePath)
    {
        // Đọc tất cả các byte từ tệp tin được chỉ định bởi filePath
        byte[] bytes = File.ReadAllBytes(filePath);

        // Tạo một instance mới của Texture2D với kích thước 2x2 (kích thước tối thiểu)
        Texture2D texture = new Texture2D(2, 2);

        // Tải dữ liệu ảnh từ mảng byte vào Texture2D
        texture.LoadImage(bytes);

        // Trả về Texture2D đã được tải
        return texture;
    }
}