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
    private GameObject displayLevel;


    private void OnEnable()
    {
        // Initialize the GameController reference
        gameController = GameController.Instance;

        // Get the tapped god from GameController
        godPass = gameController.getTappedGod();

        // Find the child by name at any depth
        //Image godSpriteTransform = FindDeep(Image, "GodSprite");
        Canvas canvasRef = transform.Find("Canvas")?.GetComponent<Canvas>();
        //Image childTransform = null;
        //GameObject displayLevel = null;
        //TextMeshProUGUI level = null;

        if (canvasRef != null)
        {
            //display god
            //childTransform = canvasRef.transform.Find("GodSprite")?.GetComponent<Image>();
            displayLevel = canvasRef.transform.Find("DisplayLevel")?.gameObject;
            //level = displayLevel.transform.Find("ShowLevel")?.GetComponent<TextMeshProUGUI>();
            godSprite= canvasRef.transform.Find("GodSprite")?.GetComponent<Image>();
            levelText = displayLevel.transform.Find("ShowLevel")?.GetComponent<TextMeshProUGUI>();

        }
        UpdateGodInfoDisplay();
        //if (childTransform != null)
        //{
        //    Debug.Log("editing childtransform");
        //    childTransform.sprite = godPass.icon;
        //}
        //if(level != null)
        //{
        //    Debug.Log("editing childtransform");
        //    level.text = godPass.level.ToString();
        //}
    }

    public void upgradeGod()
    {
        godPass.level += 1;
        UpdateGodInfoDisplay();
    }

    private void UpdateGodInfoDisplay()
    {
        if (godSprite != null)
        {
            godSprite.sprite = godPass.icon;
        }

        if (levelText != null)
        {
            levelText.text = godPass.level.ToString();
        }
    }

}
