using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Summon10x : MonoBehaviour
{
    private GameController gameController;

    public List<God> summonedGods;

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
        summonedGods = new List<God>();
        StartCoroutine(showSummonGod());
    }

    private IEnumerator showSummonGod()
    {
        while (gameController == null || gameController.GetAllSummonedGods() == null)
        {
            yield return null; // Wait for the next frame
        }

        // Once the condensed god is set, proceed with displaying the god icons
        List<God> allGods= gameController.GetAllSummonedGods();
        int godCount = gameController.GetAllSummonedGods().Count;
        //for(int i = godCount-10; i <godCount; i++)
        for (int i = Mathf.Max(0, godCount - 10); i < godCount; i++)
        {
            summonedGods.Add(allGods[i]);
        }
        UpdateScreen();
    }

    private void UpdateScreen()
    {
        //foreach(God god in summonedGods)
        //{
        //    Debug.Log("Summoned " + god.godName);
        //}
        for(int i = 0; i < summonedGods.Count; i++)
        {
            God god = summonedGods[i];
            GameObject Holder = this.gameObject;
            string objectToGet = "God" + i.ToString();
            Transform GodObject = Holder.transform.Find(objectToGet);

            //set image
            Transform imageTrans = GodObject.Find("Image");
            Image icon = imageTrans.GetComponent<Image>();
            icon.sprite = god.icon;

            //set grade
            Transform GradeTrans = GodObject.Find("Grade");
            TextMeshProUGUI gradeText = GradeTrans.GetComponent<TextMeshProUGUI>();
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
            //gradeText.text = god.grade.ToString();

            //set level
            Transform levelTrans = GodObject.Find("Level");
            TextMeshProUGUI levelText = levelTrans.GetComponent<TextMeshProUGUI>();
            levelText.text = god.level.ToString();

            //set name
            Transform nameTrans = GodObject.Find("GodName");
            TextMeshProUGUI nameText = nameTrans.GetComponent<TextMeshProUGUI>();
            nameText.text = god.godName.ToString();
        }
    }

}
