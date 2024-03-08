using System.Buffers.Text;
using UnityEngine;

[System.Serializable]
public class God
{
    public string godName;
    public int grade;
    public Sprite icon;
    public int level;
    public int baseHealth;
    public int baseAttack;
    public int baseDefense;
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
        this.baseHealth = 1000;
        this.health = this.baseHealth;
        this.baseAttack = 75;
        this.attack = this.baseAttack;
        this.baseDefense = 40;
        this.defense = this.baseDefense;
        this.description = description;
    }

    public void CalculateUpgradedStats(int level)
    {
        // Calculate upgraded stats using the base stats and growth rates
        // Adjust these formulas based on your desired calculations
        int hp = this.baseHealth * this.grade;
        int defense = this.baseDefense * this.grade;
        int attack = this.baseAttack * this.grade;

        float percentBonus = this.grade * (2.0f / 100);
        float percentFinal = 1 + percentBonus;
        int exponent = this.level - 1;
        float multiply = Mathf.Pow(percentFinal, exponent);

        float hpResult = hp * multiply;
        float defResult = defense * multiply;
        float attackResult = attack * multiply;

        this.health = (int)hpResult;
        this.attack = (int)attackResult;
        this.defense = (int)defResult;
        
    }

    
}
