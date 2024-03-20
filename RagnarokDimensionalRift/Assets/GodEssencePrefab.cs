using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
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

    public void Condense()
    {
        List<God> essenceGods = gameController.GetAllEssenceGods();
        int random = Random.Range(0, 7);
        gameController.SetCondensedGod(essenceGods[random]);
        foreach(God god in essenceGods)
        {
            if(god != gameController.GetCondensedGod())
            {
                Debug.Log("Deleting" + god);
                gameController.allSummonedGods.Remove(god);
            }
        }
        gameController.UpgradeGrade(gameController.GetCondensedGod());
        gameController.WipeAllEssenceGods();
    }

    public void WipeEssencePrefabs()
    {
        //Debug.Log("Wiping essence prefabs");
        gameController.WipeListEssencePrefabs();
    }

    public void WipeEssenceGods()
    {
        gameController.WipeAllEssenceGods();
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

    public void setButton(bool a)
    {
        Transform grandparent = transform.parent.parent.parent.parent;
        // Access further ancestors if needed
        Transform timage = grandparent.Find("Confirm");

        //Debug.Log(timage);
        Image image = timage.GetComponent<Image>();
        Button button = timage.GetComponent<Button>();

        if(a)
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

    public void addGodToList()
    {
        
        if (!gameController.GetAllEssenceGods().Contains(this.godPass))
        {
            if (gameController.GetAllEssenceGods().Count < 7)
            {
                setButton(false);
                gameController.GetAllEssenceGods().Add(this.godPass);

                
                gameController.ListEssencePrefabs.Add(this.gameObject); //same index as count

                Transform tapped = transform.Find("Tapped");
                Transform text = transform.Find("Number");
                TextMeshProUGUI textString = text.GetComponent<TextMeshProUGUI>();


                tapped.gameObject.SetActive(true);
                //tapped.
                text.gameObject.SetActive(true);
               
                textString.text = gameController.GetAllEssenceGods().Count.ToString();

                if(gameController.GetAllEssenceGods().Count == 7)
                {
                    /*
                    Transform grandparent = transform.parent.parent.parent.parent;
                    if (grandparent != null)
                    {
                        // Access further ancestors if needed
                        Transform timage = grandparent.Find("Confirm");

                        //Debug.Log(timage);
                        Image image = timage.GetComponent<Image>();
                        Button button = timage.GetComponent<Button>();
                        button.interactable = true;

                        image.color = Color.green;
                        
                    }
                    */
                    setButton(true);
                }
                
            }
                
        }else
        {
            setButton(false);
            Debug.Log("you already have this god");
            Transform tapped = transform.Find("Tapped");
            Transform text = transform.Find("Number");
            TextMeshProUGUI textString = text.GetComponent<TextMeshProUGUI>();
            

            int index = int.Parse(textString.text);
            Debug.Log("index: " + index);

            
            gameController.ListEssencePrefabs.Remove(this.gameObject);
            
            gameController.GetAllEssenceGods().Remove(this.godPass);
            Debug.Log(gameController.GetListEssencePrefabs().Count);

            for (int i=index-1; i < gameController.GetListEssencePrefabs().Count; i++)
            {
                Debug.Log("running list of prefabs");
                Debug.Log(gameController.GetListEssencePrefabs().Count);
                GameObject obj = gameController.ListEssencePrefabs[i];
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
