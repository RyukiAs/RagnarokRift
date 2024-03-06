using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GodsDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject godIconPrefab;

    [SerializeField]
    private Transform iconsParent;

    private void OnEnable()
    {
        DisplayGodIcons();
    }

    private void DisplayGodIcons()
    {
        // Get the summoned gods
        List<God> summonedGods = GameController.Instance.GetAllSummonedGods();

        // Instantiate and display icons for each summoned god
        foreach (God god in summonedGods)
        {
            // Instantiate the god icon prefab
            GameObject godIcon = Instantiate(godIconPrefab, iconsParent);

            // Set the icon sprite
            Image[] iconImages = godIcon.GetComponentsInChildren<Image>(true);
            Image secondIconImage = iconImages.Length >= 2 ? iconImages[1] : null;

            // Log the information for debugging
            Debug.Log("Number of Image components: " + iconImages.Length);
            Debug.Log("Second Image component: " + secondIconImage);

            if (secondIconImage != null)
            {
                secondIconImage.sprite = god.icon;
            }

            // Accessing the TextMeshProUGUI components manually
            //TextMeshProUGUI[] textComponents = godIcon.GetComponentsInChildren<TextMeshProUGUI>();
            //TextMeshProUGUI gradeText;
            //TextMeshProUGUI levelText;
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

            //foreach (TextMeshProUGUI textComponent in textComponents)
            //{
            //    if (textComponent.gameObject.name == "GradeText")
            //    {
            //        gradeText= textComponent;
            //    }
            //    else if (textComponent.gameObject.name == "LevelText")
            //    {
            //        levelText= textComponent;
            //    }
            //    // Add more conditions if you have other named text components
            //}
            // Set god Grade
            //TextMeshProUGUI gradeText = godIcon.GetComponentInChildren<TextMeshProUGUI>();
            //TextMeshProUGUI levelText = godIcon.GetComponentInChildren<TextMeshProUGUI>();
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

                if (gradeMap.TryGetValue(god.grade, out string gradeString))
                {
                    gradeText.text = gradeString;
                }
                else
                {
                    gradeText.text = "Unknown Grade";
                }
            }
            if(levelText != null)
            {
                levelText.text = god.level.ToString();
            }else
            {
                Debug.Log("Error in setting level");
            }
        }
    }
}