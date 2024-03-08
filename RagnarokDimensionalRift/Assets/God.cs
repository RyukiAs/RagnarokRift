using UnityEngine;

[System.Serializable]
public class God
{
    public string godName;
    public int grade;
    public Sprite icon;
    public int level;
    public int health;
    public int attack;
    public int defense;
    public string description;

    public God(string godName, int grade, Sprite icon, string description)
    {
        this.godName = godName;
        this.grade = grade;
        this.icon = icon;
        this.level = 1;
        this.health = 1000;
        this.attack = 75;
        this.defense = 40;
        this.description = description;
    }

    // Additional properties and methods can be added as needed
}
