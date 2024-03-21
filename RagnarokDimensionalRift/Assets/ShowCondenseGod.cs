using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowCondenseGod : MonoBehaviour
{
    private GameController gameController;

    [SerializeField]
    private God godPass;

    private void Start()
    {
        // Your existing code
        gameController = GameController.Instance;
        if (gameController == null)
        {
            Debug.Log("GameController instance not found. Make sure GameControllerInitializer script is in the scene.");
        }
    }
    private void OnEnable()
    {
        DisplayGodIcons();
    }

    private void DisplayGodIcons()
    {
        // Get the summoned gods
        //List<God> essenceGods = GameController.Instance.GetAllEssenceGods();


        this.godPass = gameController.GetCondensedGod();
        if (this.godPass != null)
        {
            Debug.Log("You have the condensed god");
        }
        else
        {
            Debug.Log("Condensed God not set");
        }

        // Instantiate the god icon prefab
        GameObject godIcon = this.gameObject;

        Image[] iconImages = godIcon.GetComponentsInChildren<Image>(true);
        Image secondIconImage = iconImages.Length >= 2 ? iconImages[1] : null;


        Debug.Log("Number of Image components: " + iconImages.Length);
        Debug.Log("Second Image component: " + secondIconImage);

        if (secondIconImage != null)
        {
            secondIconImage.sprite = this.godPass.icon;
        }


        TextMeshProUGUI gradeText = null;
        TextMeshProUGUI levelText = null;

        foreach (TextMeshProUGUI textComponent in godIcon.GetComponentsInChildren<TextMeshProUGUI>())
        {
            Debug.Log("Found Text Component: " + textComponent.gameObject.name);

            if (textComponent.gameObject.name == "GradeText")
            {
                gradeText = textComponent;
            }
            else if (textComponent.gameObject.name == "LevelText")
            {
                levelText = textComponent;
            }
            // Add more conditions if you have other named text components
        }

        Debug.Log("Grade Text Component: " + (gradeText != null ? gradeText.gameObject.name : "Not found"));
        Debug.Log("Level Text Component: " + (levelText != null ? levelText.gameObject.name : "Not found"));


        if (gradeText != null)
        {
            Dictionary<int, string> gradeMap = new Dictionary<int, string>
                {
                    { 1, "FFF" },
                    { 2, "FF" },
                    { 3, "F" },
                    { 4, "E" },
                    { 5, "D" },
                    { 6, "C" },
                    { 7, "B" },
                    { 8, "A" },
                    { 9, "S" },
                    { 10, "SS" },
                    { 11, "SSS" }
                };

            if (gradeMap.TryGetValue(this.godPass.grade, out string gradeString))
            {
                gradeText.text = gradeString;
            }
            else
            {
                gradeText.text = "Unknown Grade";
            }
        }
        if (levelText != null)
        {
            levelText.text = this.godPass.level.ToString();
        }
        else
        {
            Debug.Log("Error in setting level");
        }

        this.godPass.level = 1;
        this.godPass.CalculateUpgradedStats(this.godPass.level);

    }
}
