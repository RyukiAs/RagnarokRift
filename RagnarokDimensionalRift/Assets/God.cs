using UnityEngine;

[System.Serializable]
public class God
{
    public string godName;
    public int grade;
    public Sprite icon;

    public God(string godName, int grade, Sprite icon)
    {
        this.godName = godName;
        this.grade = grade;
        this.icon = icon;
    }

    // Additional properties and methods can be added as needed
}
