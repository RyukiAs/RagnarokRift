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

    [SerializeField]
    private int startingGodIndex;

    [SerializeField]
    private int endGodIndex; // Adjust this value based on your needs

    private void OnEnable()
    {
        DisplayGodIcons();
    }
    private void OnDisable()
    {
        Transform parentTransform = this.transform;

        foreach (Transform child in parentTransform)
        {
            Destroy(child.gameObject);
        }
    }

    //Display gods given a start index and end index, will have buttons to make it a page like thing
    private void DisplayGodIcons()
    {
        // Get the summoned gods
        List<God> summonedGods = GameController.Instance.GetAllSummonedGods();

        // Instantiate and display icons for each summoned god
        //foreach (God god in summonedGods)
        for (int i = startingGodIndex; i <= endGodIndex && i < summonedGods.Count; i++)
        {
            // Instantiate the god icon prefab
            GameObject godIcon = Instantiate(godIconPrefab, iconsParent);

            GodScreenCanvas godScreenContent = godIcon.GetComponent<GodScreenCanvas>();
            // Check if the script is attached
            if (godScreenContent != null)
            {
                // Call the SetGodInfo method to set the information of the God
                godScreenContent.SetGodInfo(summonedGods[i]);
            }
            else
            {
                Debug.LogError("GodScreenContent script not found on the prefab.");
            }
            // Set the icon sprite
            Image[] iconImages = godIcon.GetComponentsInChildren<Image>(true);
            Image secondIconImage = iconImages.Length >= 2 ? iconImages[1] : null;

            // Log the information for debugging
            //Debug.Log("Number of Image components: " + iconImages.Length);
            //Debug.Log("Second Image component: " + secondIconImage);

            if (secondIconImage != null)
            {
                secondIconImage.sprite = summonedGods[i].icon; //was icon
            }

            //
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

            //Debug.Log("Grade Text Component: " + (gradeText != null ? gradeText.gameObject.name : "Not found"));
            //Debug.Log("Level Text Component: " + (levelText != null ? levelText.gameObject.name : "Not found"));


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

                if (gradeMap.TryGetValue(summonedGods[i].grade, out string gradeString))
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
                levelText.text = summonedGods[i].level.ToString();
            }
            else
            {
                Debug.Log("Error in setting level");
            }
        }
    }
}