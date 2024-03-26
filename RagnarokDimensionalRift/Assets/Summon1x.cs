using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Summon1x : MonoBehaviour
{
    private GameController gameController;

    private God godpass;

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
        StartCoroutine(showSummonGod());
    }

    private IEnumerator showSummonGod()
    {
        while (gameController == null || gameController.GetAllSummonedGods() == null)
        {
            yield return null; // Wait for the next frame
        }

        // Once the condensed god is set, proceed with displaying the god icons
        int godCount = gameController.GetAllSummonedGods().Count;
        List<God> allGods = gameController.GetAllSummonedGods();
        godpass = allGods[godCount - 1];
        UpdateScreen();
    }

    //get all things to update
    private void UpdateScreen()
    {
        GameObject canvas = this.gameObject;

        //setting icon
        Transform icon = canvas.transform.Find("Icon");
        Image iconImage = icon.GetComponent<Image>();
        iconImage.sprite = godpass.icon;

        //setting the sprite
        Transform sprite = canvas.transform.Find("Sprite");
        Image spriteImage = sprite.GetComponent<Image>();
        spriteImage.sprite = godpass.sprite;

        //setting the name
        Transform name = canvas.transform.Find("GodName");
        TextMeshProUGUI nameString = name.GetComponent<TextMeshProUGUI>();
        nameString.text = godpass.godName;

        //setting the grade
        Transform grade = canvas.transform.Find("Grade");
        Transform gradeTransform = grade.Find("varGrade");
        TextMeshProUGUI gradeText = gradeTransform.GetComponent<TextMeshProUGUI>();
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

        if (gradeMap.TryGetValue(godpass.grade, out string gradeString))
        {
            gradeText.text = gradeString;
        }
        else
        {
            gradeText.text = "Unknown Grade";
        }
    }

}
