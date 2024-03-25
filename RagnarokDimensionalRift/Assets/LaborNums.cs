using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LaborNums : MonoBehaviour
{
    private GameController gameController;

    [SerializeField]
    private int num;

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
        StartCoroutine(WaitForNums());
        //DisplayTrialNums();
    }
    private IEnumerator WaitForNums()
    {
        while (gameController == null || gameController.GetTrial() == 0)
        {
            yield return null; // Wait for the next frame
        }

        // Once the condensed god is set, proceed with displaying the god icons
        this.num = gameController.GetTrial();
        DisplayTrialNums();

    }


    //basically finds a lot of gameobjects in order to set a text component
    private void DisplayTrialNums()
    {
        //int TrialNum = gameController.GetTrial();
        int TrialNum = this.num;
        int nextTrialNum = TrialNum + 1;
        int futureTrialNum = TrialNum + 2;
        Debug.Log("TrialNum = " + TrialNum);

        GameObject prefab = this.gameObject;
        Transform grid = prefab.transform.Find("Grid");

        Transform currentTrial = grid.Find("CurrentTrial");
        Transform nextTrial = grid.Find("NextTrial");
        Transform futureTrial = grid.Find("FutureTrial");

        Transform currentTrialGroup = currentTrial.Find("Grouping");
        Transform nextTrialGroup = nextTrial.Find("Grouping");
        Transform futureTrialGroup = futureTrial.Find("Grouping");

        Transform currentTrialinfo = currentTrialGroup.Find("TrialInfo");
        Transform nextTrialinfo = nextTrialGroup.Find("TrialInfo");
        Transform futureTrialinfo = futureTrialGroup.Find("TrialInfo");

        Transform currentTrialText = currentTrialinfo.Find("TrialNum");
        Transform nextTrialText = nextTrialinfo.Find("TrialNum");
        Transform futureTrialText = futureTrialinfo.Find("TrialNum");


        TextMeshProUGUI currentTrialTextComponent = currentTrialText.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI nextTrialTextComponent = nextTrialText.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI futureTrialTextComponent = futureTrialText.GetComponent<TextMeshProUGUI>();

        if (currentTrialTextComponent != null && nextTrialTextComponent != null && futureTrialTextComponent != null)
        {
            currentTrialTextComponent.text = TrialNum.ToString();
            nextTrialTextComponent.text = nextTrialNum.ToString();
            futureTrialTextComponent.text = futureTrialNum.ToString();
        }
        else
        {
            Debug.LogError("textmeshprougui components not found.");
        }

    }

}
