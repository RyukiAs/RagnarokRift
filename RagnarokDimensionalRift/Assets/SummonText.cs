using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class SummonText : MonoBehaviour
{
    private GameController gameController;

    [SerializeField]
    private TextMeshProUGUI gName;

    private void OnEnable()
    {
        // This method is called when the GameObject becomes active

        // Find the TextMeshProUGUI component in the hierarchy
        gName = GetComponentInChildren<TextMeshProUGUI>();

        if (gName == null)
        {
            //Debug.LogError("TextMeshProUGUI component not found on the GameObject or its children.");
            return;
        }

        List<God> summonedGods = GameController.Instance.GetAllSummonedGods();

        if (summonedGods.Count > 0)
        {
            God lastGod = summonedGods[summonedGods.Count - 1];

            if (lastGod.godName != null)
            {
                //Debug.Log("Setting gName with text: " + lastGod.godName);
                gName.text = lastGod.godName;
            }
            else
            {
                Debug.LogError("The name on the lastGod is null.");
            }
        }
        else
        {
            Debug.LogWarning("No summoned gods available.");
        }
    }
}

