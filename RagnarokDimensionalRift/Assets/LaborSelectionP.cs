using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LaborSelectionP : MonoBehaviour
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

    //sets god info
    public void SetGodInfo(God god)
    {
        this.godPass = god;
    }

    //Clears the list of essensePrefabs
    public void WipeLaborsPrefabs()
    {
        //Debug.Log("Wiping essence prefabs");
        gameController.WipeListLaborsPrefabs();
    }

    //Clears the list of essenseGods
    public void WipeLaborGods()
    {
        gameController.WipeLaborGods();
    }

    public void setButtonFromButton(bool a)
    {
        Transform timage = gameObject.transform.Find("Confirm");
        Debug.Log(timage.name);
        Image image = timage.GetComponent<Image>();
        Button button = timage.GetComponent<Button>();

        if (a)
        {
            button.interactable = true;
            image.color = Color.green;
        }
        else
        {
            button.interactable = false;
            image.color = Color.gray;
        }

    }

    //set confirm button interactable and change color
    public void setButton(bool a)
    {
        Transform grandparent = transform.parent.parent.parent.parent;
        // Access further ancestors if needed
        Transform timage = grandparent.Find("Confirm");

        //Debug.Log(timage);
        Image image = timage.GetComponent<Image>();
        Button button = timage.GetComponent<Button>();

        if (a)
        {
            button.interactable = true;
            image.color = Color.green;
        }
        else
        {
            button.interactable = false;
            image.color = Color.gray;
        }

    }

    //Adds or removes gods to EssenceList and Adds
    //the prefab in order to be able to access UI elements
    public void addGodToList()
    {

        if (!gameController.GetLaborGods().Contains(this.godPass))
        {
            if (gameController.GetLaborGods().Count < 6)
            {
                setButton(false);
                gameController.LaborsGodList.Add(this.godPass);

                gameController.ListLaborsPrefabs.Add(this.gameObject); //same index as count

                Transform tapped = transform.Find("Tapped");
                Transform text = transform.Find("Number");
                TextMeshProUGUI textString = text.GetComponent<TextMeshProUGUI>();


                tapped.gameObject.SetActive(true);
                //tapped.
                text.gameObject.SetActive(true);

                textString.text = gameController.GetLaborGods().Count.ToString();

                if (gameController.GetLaborGods().Count >= 1)
                {
                    setButton(true);
                }

            }

        }
        else
        {
            //setButton(false);
            Debug.Log("you already have this god");
            Transform tapped = transform.Find("Tapped");
            Transform text = transform.Find("Number");
            TextMeshProUGUI textString = text.GetComponent<TextMeshProUGUI>();


            int index = int.Parse(textString.text);
            Debug.Log("index: " + index);


            gameController.ListLaborsPrefabs.Remove(this.gameObject);

            gameController.LaborsGodList.Remove(this.godPass);

            if (gameController.GetLaborGods().Count < 1)
            {
                setButton(false);
            }

            Debug.Log(gameController.GetListLaborPrefabs().Count);

            for (int i = index - 1; i < gameController.GetListLaborPrefabs().Count; i++)
            {
                Debug.Log("running list of prefabs");
                Debug.Log(gameController.GetListLaborPrefabs().Count);
                GameObject obj = gameController.ListLaborsPrefabs[i];
                Transform tapped2 = obj.transform.Find("Tapped");
                Transform text2 = obj.transform.Find("Number");
                TextMeshProUGUI textString2 = text2.GetComponent<TextMeshProUGUI>();
                int stringText = int.Parse(textString2.text);
                int resultText = stringText - 1;
                textString2.text = resultText.ToString();
            }

            tapped.gameObject.SetActive(false);
            text.gameObject.SetActive(false);
            textString.text = "";

        }



    }
}
