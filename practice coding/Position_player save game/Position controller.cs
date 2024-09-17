using UnityEngine;
using System.IO;

public class PositionManager : MonoBehaviour
{
    public Transform target; // Đối tượng để lưu vị trí
    private string filePath;

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "position.json"); // Đường dẫn để lưu tệp
        LoadPosition(); // Tải vị trí khi bắt đầu
    }

    void Update()
    {
        // Di chuyển đối tượng bằng phím WASD
        if (Input.GetKey(KeyCode.W)) target.position += Vector3.up * Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) target.position += Vector3.down * Time.deltaTime;
        if (Input.GetKey(KeyCode.A)) target.position += Vector3.left * Time.deltaTime;
        if (Input.GetKey(KeyCode.D)) target.position += Vector3.right * Time.deltaTime;

        // Lưu vị trí khi nhấn phím "L"
        if (Input.GetKeyDown(KeyCode.L))
        {
            SavePosition();
        }
    }

    public void SavePosition()
    {
        PositionData positionData = new PositionData(target.position);
        string json = JsonUtility.ToJson(positionData); // Chuyển đổi dữ liệu sang JSON
        File.WriteAllText(filePath, json); // Lưu vào tệp
        Debug.Log("Đã lưu vị trí: " + target.position);
    }

    public void LoadPosition()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath); // Đọc dữ liệu từ tệp
            PositionData positionData = JsonUtility.FromJson<PositionData>(json); // Chuyển đổi JSON về đối tượng
            target.position = positionData.ToVector3(); // Cập nhật vị trí của đối tượng
            Debug.Log("Đã tải vị trí: " + target.position);
        }
        else
        {
            Debug.LogWarning("Tệp không tồn tại.");
        }
    }
}