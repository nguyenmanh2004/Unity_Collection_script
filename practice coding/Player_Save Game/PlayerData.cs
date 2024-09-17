using TMPro;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public string name;
    public int strength; // Sức mạnh
    public int stamina; // Sức chịu đựng
    public int intelligence; // Trí tuệ
    public int dexterity; // Khéo léo
    public int charisma; // Tinh thần
    public int level; // Mức độ
    public int health; // Điểm sức khỏe
    public int mana; // Điểm năng lượng

    public PlayerData(string name, int strength, int stamina, int intelligence, int dexterity, int charisma, int level, int health, int mana)
    {
        this.name = name;
        this.strength = strength;
        this.stamina = stamina;
        this.intelligence = intelligence;
        this.dexterity = dexterity;
        this.charisma = charisma;
        this.level = level;
        this.health = health;
        this.mana = mana;
    }
}
