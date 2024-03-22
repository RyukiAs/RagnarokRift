using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LaborNums : MonoBehaviour
{
    private GameController gameController;

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
        DisplayTrialNums();
    }

    private void DisplayTrialNums()
    {
        int TrialNum = gameController.GetTrial();

        GameObject prefab = this.gameObject;
        Transform currentTrial = prefab.transform.Find("CurrentTrial");
        Transform nextTrial = prefab.transform.Find("NextTrial");
        Transform futureTrial = prefab.transform.Find("FutureTrial");

        Transform currentTrialinfo = currentTrial.Find("TrialInfo");
        Transform nextTrialinfo = nextTrial.Find("TrialInfo");
        Transform futureTrialinfo = futureTrial.Find("TrialInfo");

        Transform currentTrialText = currentTrialinfo.Find("TrialNum");
        Transform nextTrialText = nextTrialinfo.Find("TrialNum");
        Transform futureTrialText = futureTrialinfo.Find("TrialNum");


        TextMeshProUGUI currentTrialTextComponent = currentTrialText.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI nextTrialTextComponent = nextTrialText.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI futureTrialTextComponent = futureTrialText.GetComponent<TextMeshProUGUI>();

        //currentTrialText.text = TrialNum.ToString;
        //nextTrialText.text = TrialNum.ToString;
        //futureTrialText.text = TrialNum.ToString;
        if (currentTrialTextComponent != null && nextTrialTextComponent != null && futureTrialTextComponent != null)
        {
            currentTrialTextComponent.text = TrialNum.ToString();
            nextTrialTextComponent.text = TrialNum.ToString();
            futureTrialTextComponent.text = TrialNum.ToString();
        }
        else
        {
            Debug.LogError("TextMeshProUGUI components not found.");
        }

    }

}
