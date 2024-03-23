using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GodInfo : MonoBehaviour
{ 
    [SerializeField]
    private God godPass;

    private GameController gameController;
    private Image godSprite;
    private TextMeshProUGUI levelText;
    private TextMeshProUGUI godDescription;
    private TextMeshProUGUI gradeText;
    private TextMeshProUGUI attackText;
    private TextMeshProUGUI defenseText;
    private TextMeshProUGUI healthText;
    private GameObject displayLevel;
    private GameObject description;
    private GameObject showStats;


    private void OnEnable()
    {
        // Initialize the GameController reference
        gameController = GameController.Instance;

        // Get the tapped god from GameController
        godPass = gameController.getTappedGod();

        Canvas canvasRef = transform.Find("Canvas")?.GetComponent<Canvas>();
        if (canvasRef != null)
        {
            //find gameobject to get children
            displayLevel = canvasRef.transform.Find("DisplayLevel")?.gameObject;
            description = canvasRef.transform.Find("Description")?.gameObject;
            showStats = canvasRef.transform.Find("ShowStats")?.gameObject;


            godSprite = canvasRef.transform.Find("GodSprite")?.GetComponent<Image>();
            levelText = displayLevel.transform.Find("ShowLevel")?.GetComponent<TextMeshProUGUI>();
            godDescription = description.transform.Find("Text")?.GetComponent<TextMeshProUGUI>();
            attackText = showStats.transform.Find("AttackDisplay")?.GetComponent<TextMeshProUGUI>();
            defenseText = showStats.transform.Find("DefenseDisplay")?.GetComponent<TextMeshProUGUI>();
            healthText = showStats.transform.Find("HealthDisplay")?.GetComponent<TextMeshProUGUI>();
            gradeText = showStats.transform.Find("GrowthRateDisplay")?.GetComponent<TextMeshProUGUI>();
        }
        UpdateGodInfoDisplay();
    }

    public void upgradeGod()
    {
        godPass.level += 1;
        godPass.CalculateUpgradedStats(godPass.level);
        UpdateGodInfoDisplay();
    }

    private void UpdateGodInfoDisplay()
    {
        if (godSprite != null)
        {
            godSprite.sprite = godPass.sprite; // was icon
        }

        if (levelText != null)
        {
            levelText.text = godPass.level.ToString();
        }
        if(godDescription != null)
        {
            godDescription.text = godPass.description;
        }
        if(healthText != null)
        {
            healthText.text = godPass.health.ToString();
        }
        if (defenseText != null)
        {
            defenseText.text = godPass.defense.ToString();
        }
        if (attackText != null)
        {
            attackText.text = godPass.attack.ToString();
        }
        if (gradeText != null)
        {
            if(godPass.grade == 1)
            {
                gradeText.text = "FFF";
            }else if(godPass.grade == 2)
            {
                gradeText.text = "FF";
            }
            else if (godPass.grade == 3)
            {
                gradeText.text = "F";
            }
            else if (godPass.grade == 4)
            {
                gradeText.text = "E";
            }
            else if (godPass.grade == 5)
            {
                gradeText.text = "D";
            }
            else if (godPass.grade == 6)
            {
                gradeText.text = "C";
            }
            else if (godPass.grade == 7)
            {
                gradeText.text = "B";
            }
            else if (godPass.grade == 8)
            {
                gradeText.text = "A";
            }
            else if (godPass.grade == 9)
            {
                gradeText.text = "S";
            }
            else if (godPass.grade == 10)
            {
                gradeText.text = "SS";
            }
            else if (godPass.grade == 11)
            {
                gradeText.text = "SSS";
            }else
            {
                gradeText.text = "Unknown";
            }

        }


    }

}
