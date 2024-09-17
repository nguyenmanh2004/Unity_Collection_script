using UnityEngine;
using System.IO;
using TMPro;

public class DataManager : MonoBehaviour
{
    private string filePath;

    public TMP_InputField nameInput; // Input Field cho tên
    public TMP_InputField strengthInput; // Input Field cho sức mạnh
    public TMP_InputField staminaInput; // Input Field cho sức chịu đựng
    public TMP_InputField intelligenceInput; // Input Field cho trí tuệ
    public TMP_InputField dexterityInput; // Input Field cho khéo léo
    public TMP_InputField charismaInput; // Input Field cho tinh thần
    public TMP_InputField levelInput; // Input Field cho mức độ
    public TMP_InputField healthInput; // Input Field cho sức khỏe
    public TMP_InputField manaInput; // Input Field cho năng lượng
    public TextMeshProUGUI statsText; // Tham chiếu đến TextMeshPro

    void Start()
    {
        // Đặt đường dẫn đến file JSON
        filePath = Path.Combine(Application.persistentDataPath, "playerData.json");
        Debug.Log("Persistent Data Path: " + Application.persistentDataPath);

        // Tải dữ liệu
        PlayerData loadedData = LoadData();
        if (loadedData != null)
        {
            DisplayPlayerStats(loadedData); // Hiển thị thông tin nhân vật
        }
    }

    public void SaveData()
    {
        // Lấy dữ liệu từ các Input Field
        string playerName = nameInput.text;
        int strength = int.Parse(strengthInput.text);
        int stamina = int.Parse(staminaInput.text);
        int intelligence = int.Parse(intelligenceInput.text);
        int dexterity = int.Parse(dexterityInput.text);
        int charisma = int.Parse(charismaInput.text);
        int level = int.Parse(levelInput.text);
        int health = int.Parse(healthInput.text);
        int mana = int.Parse(manaInput.text);

        // Tạo đối tượng PlayerData
        PlayerData playerData = new PlayerData(playerName, strength, stamina, intelligence, dexterity, charisma, level, health, mana);

        // Chuyển đổi đối tượng thành JSON và lưu vào file
        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Player data saved to " + filePath);
    }

    public PlayerData LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath); // Đọc dữ liệu từ file
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json); // Chuyển đổi JSON về đối tượng
            Debug.Log("Data loaded: " + playerData.name);
            return playerData;
        }
        else
        {
            Debug.LogWarning("File does not exist: " + filePath);
            return null;
        }
    }

    private void DisplayPlayerStats(PlayerData playerData)
    {
        statsText.text = $"Name: {playerData.name}\n" +
                         $"Strength: {playerData.strength}\n" +
                         $"Stamina: {playerData.stamina}\n" +
                         $"Intelligence: {playerData.intelligence}\n" +
                         $"Dexterity: {playerData.dexterity}\n" +
                         $"Charisma: {playerData.charisma}\n" +
                         $"Level: {playerData.level}\n" +
                         $"Health: {playerData.health}\n" +
                         $"Mana: {playerData.mana}";
    }
}