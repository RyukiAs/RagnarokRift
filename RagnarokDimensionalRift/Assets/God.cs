using UnityEngine;

[System.Serializable]
public class God
{
    public string godName;
    public int grade;
    public Sprite icon;
    public int level;

    public God(string godName, int grade, Sprite icon)
    {
        this.godName = godName;
        this.grade = grade;
        this.icon = icon;
        this.level = 1;
    }

    // Additional properties and methods can be added as needed
}
