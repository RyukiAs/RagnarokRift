using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        
        if (!gameController.GetAllEssenceGods().Contains(this.godPass))
        {
            if (gameController.GetAllEssenceGods().Count < 7)
            {
                gameController.GetAllEssenceGods().Add(this.godPass);


                Transform tapped = transform.Find("Tapped");
                Transform text = transform.Find("Number");
                TextMeshProUGUI textString = text.GetComponent<TextMeshProUGUI>();


                tapped.gameObject.SetActive(true);
                //tapped.
                //text.gameObject.SetActive(true);
                //textString.text = gameController.GetAllEssenceGods().Count.ToString();
            }
                
        }else
        {
            Debug.Log("you already have this god");
            gameController.GetAllEssenceGods().Remove(this.godPass);
            Transform tapped = transform.Find("Tapped");
            Transform text = transform.Find("Number");
            TextMeshProUGUI textString = text.GetComponent<TextMeshProUGUI>();

            tapped.gameObject.SetActive(false);
            //text.gameObject.SetActive(false);
            //textString.text = "";
                

        }

        
       
    }

}
