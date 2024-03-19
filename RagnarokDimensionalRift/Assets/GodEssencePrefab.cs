using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodEssencePrefab : MonoBehaviour
{

    [SerializeField]
    private God godPass;

    private GameController gameController;

    private void Start()
    {
        //Debug.Log("Player script Start method called."); // Add this line

        // Your existing code
        gameController = GameController.Instance;
        if (gameController == null)
        {
            Debug.Log("GameController instance not found. Make sure GameControllerInitializer script is in the scene.");
        }
        //Debug.Log("Player script initialization complete."); // Add this line
    }

    public void SetGodInfo(God god)
    {
        this.godPass = god;
    }

    public void addGodToList()
    {
        if (gameController.GetAllEssenceGods().Count < 7)
        {
            if (!gameController.GetAllEssenceGods().Contains(this.godPass))
            {
                gameController.GetAllEssenceGods().Add(this.godPass);

                Transform childTransform = transform.Find("SelectEssence");
                Image image = childTransform.GetComponent<Image>();
                Button button = childTransform.GetComponent<Button>();
                //Image buttonImage = button.GetComponent<Image>();
                //Image buttonImage = button.image;

                //image.color = Color.gray;


                ColorBlock colors = button.colors;

                // Modify the alpha value of the normal color
                //Color normalColor = colors.normalColor;
                //normalColor.a = 1.0f; // Change this value as needed
                //colors.normalColor = normalColor;

                // Apply the modified colors to the button
                //button.colors = colors;
                ///float aplha = 0.5f;
                //Color buttonColor = buttonImage.color;
                //currentColor.a = aplha;
                //float aplha = 1.0f;
                //Color currentColor = image.color

                Debug.Log("Changed Color to gray");
            }
            else
            {
                print("This god already exists");
            }

        }else
        {
            print("Essence Already Full");
        }
       
    }

}
