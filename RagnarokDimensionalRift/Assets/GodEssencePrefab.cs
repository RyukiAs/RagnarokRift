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
                //Debug.Log("gameobject: " + gameObject.name);
                Image image = childTransform.GetComponent<Image>();
                image.color = Color.gray;
            }else
            {
                print("This god already exists");
            }

        }else
        {
            print("Essence Already Full");
        }
       
    }

}
