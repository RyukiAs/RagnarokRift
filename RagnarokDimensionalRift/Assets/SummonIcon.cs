using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class SummonIcon : MonoBehaviour
{
    private GameController gameController;

    [SerializeField]
    private Image sourceImage;

    private void OnEnable()
    {
        // This method is called when the GameObject becomes active

        // Find the Image component in the hierarchy
        Image sourceImage = GetComponentInChildren<Image>();

        if (sourceImage == null)
        {
            //Debug.LogError("Image component not found on the GameObject or its children.");
            return;
        }

        List<God> summonedGods = GameController.Instance.GetAllSummonedGods();

        if (summonedGods.Count > 0)
        {
            God lastGod = summonedGods[summonedGods.Count - 1];

            if (lastGod.icon != null)
            {
                //Debug.Log("Setting sourceImage with sprite: " + lastGod.icon);
                sourceImage.sprite = lastGod.icon;
            }
            else
            {
                //Debug.LogError("The sprite on the lastGod is null.");
            }
        }
        else
        {
            Debug.LogWarning("No summoned gods available.");
        }
    }
}
