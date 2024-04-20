using System.Buffers.Text;
using TMPro;
using UnityEngine;
using System.Collections;

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
    public int healthVar;
    public int attackVar;
    public int defenseVar;
    public string description;
    public Sprite sprite;
    public Vector2 position; //Vector2?
    public bool canAttack;
    public bool attacking;

    public God(string godName, int grade, Sprite icon, string description, Sprite sprite, bool attacking, int baseHealth, int baseAttack, int baseDefense)
    {
        this.godName = godName;
        this.grade = grade;
        this.icon = icon;
        this.level = 1;
        this.baseHealth = baseHealth;
        this.health = this.baseHealth;
        this.healthVar = health;
        this.baseAttack = baseAttack;
        this.attack = this.baseAttack;
        this.attackVar = this.attack;
        this.baseDefense = baseDefense;
        this.defense = this.baseDefense;
        this.defenseVar = this.defense;
        this.description = description;
        this.sprite = sprite;
        this.position = new Vector2(0f,0f);
        this.canAttack = true;
        this.attacking = attacking;
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

        this.healthVar = health;
        this.attackVar= attack;
        this.defenseVar = defense;
        
    }

    

}
