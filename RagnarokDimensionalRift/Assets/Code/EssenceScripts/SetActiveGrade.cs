using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SetActiveGrade : MonoBehaviour
{

    private GameController gameController;

    public List<GameObject> buttons;

    public string activeColor;

    public string inactiveColor;

    private void Start()
    {
        //Debug.Log("Player script Start method called."); // Add this line

        // Your existing code
        gameController = GameController.Instance;
        if (gameController == null)
        {
            Debug.LogError("GameController instance not found. Make sure GameControllerInitializer script is in the scene.");
        }
        //Debug.Log("Player script initialization complete."); // Add this line
    }

    //Used in selectionOfEssence to Choose gods of a set grade
    //this will setGrade in GameController and change the color
    public void SetGrade(int grade)
    {
        gameController.SetActiveGrade(grade);
        gameController.WipeAllEssenceGods();
        gameController.WipeListEssencePrefabs();

        Image image = buttons[grade-1].GetComponent<Image>();

        if (image != null)
        {
            UnityEngine.Color color;
            if (UnityEngine.ColorUtility.TryParseHtmlString(activeColor, out color))
            {
                image.color = color;
            }
            else
            {
                Debug.LogError("Invalid hexadecimal color value: " + activeColor);
            }
        }
        else
        {
            Debug.LogError("Image component not found on the game object.");
        }

        UnityEngine.Color color2;
        foreach ( GameObject button in buttons)
        {
            if(button != buttons[grade-1]){
                Image image2 = button.GetComponent<Image>();
                if (UnityEngine.ColorUtility.TryParseHtmlString(inactiveColor, out color2))
                {
                    image2.color = color2;
                }
                else
                {
                    Debug.LogError("Invalid hexadecimal color value: " + inactiveColor);
                }
            }
        }


    }


    
}
