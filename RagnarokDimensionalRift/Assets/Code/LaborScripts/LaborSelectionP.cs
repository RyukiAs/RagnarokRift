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

    public void SetLaborEnemyGod()
    {
        int TrialNum = gameController.GetTrial();
        int modTrialNum = TrialNum % 11;
        if (modTrialNum == 1)
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite sprite = Resources.Load<Sprite>("GodSprites/CthulhuSprite");
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/CthulhuIcon");
            string description = "Cthulhu - described as a monstrous being with an octopoid head, " +
                "a scaly body, and bat-like wings. It is part of a pantheon of cosmic deities known as " +
                "the Great Old Ones.";
            // Create a new god with a specified icon
            bool attacking = false;
            int baseHealth = 1000;
            int baseAttack = 130;
            int baseDefense = 30;
            God newGod = new God("Cthulhu", TrialNum, godIcon, description, sprite, attacking, baseHealth, baseAttack, baseDefense);
            newGod.CalculateUpgradedStats(TrialNum);
            gameController.LaborEnemy = newGod;

        }
        else if (modTrialNum == 2)
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite sprite = Resources.Load<Sprite>("GodSprites/ZeusSprite");
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/ZeusIcon");
            string description = "Zeus - depicted as a powerful and majestic figure, wielding a thunderbolt " +
                "as his symbol of authority. One of the big three of the Greek Gods. The god of lighting in " +
                "Greek mythology, also seen as the most important Greek God.";
            // Create a new god with a specified icon
            bool attacking = false;
            int baseHealth = 1000;
            int baseAttack = 130;
            int baseDefense = 30;
            God newGod = new God("Zeus", TrialNum, godIcon, description, sprite, attacking, baseHealth, baseAttack, baseDefense);
            newGod.CalculateUpgradedStats(TrialNum);
            gameController.LaborEnemy = newGod;

        }
        else if (modTrialNum == 3)
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite sprite = Resources.Load<Sprite>("GodSprites/DionysusSprite");
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/DionysusIcon");
            string description = "Dionysus - known as the god of wine, festivities, and theater. One of the " +
                "Twelve Greek Olympians.";
            // Create a new god with a specified icon
            bool attacking = false;
            int baseHealth = 1000;
            int baseAttack = 130;
            int baseDefense = 30;
            God newGod = new God("Dionysus", TrialNum, godIcon, description, sprite, attacking, baseHealth, baseAttack, baseDefense);
            newGod.CalculateUpgradedStats(TrialNum);
            gameController.LaborEnemy = newGod;

        }
        else if (modTrialNum == 4)
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite sprite = Resources.Load<Sprite>("GodSprites/NeptuneSprite");
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/NeptuneIcon");
            string description = "Neptune - god of the sea, freshwater, earthquakes, and horses in Roman mythology. " +
                "He is one of the twelve Olympian deities and holds a position of great importance among the Roman " +
                "gods. Neptune is often depicted as a powerful and bearded deity, holding a trident";
            // Create a new god with a specified icon
            bool attacking = false;
            int baseHealth = 1000;
            int baseAttack = 130;
            int baseDefense = 30;
            God newGod = new God("Neptune", TrialNum, godIcon, description, sprite, attacking, baseHealth, baseAttack, baseDefense);
            newGod.CalculateUpgradedStats(TrialNum);
            gameController.LaborEnemy = newGod;

        }
        else if (modTrialNum == 5)
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite sprite = Resources.Load<Sprite>("GodSprites/ShivaSprite");
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/ShivaIcon");
            string description = "Shiva - Hindu god of destruction. One of the most important Hindu Gods. " +
                "Described as having 3 eyes, multiple hands holding a trident and skull.";
            // Create a new god with a specified icon
            bool attacking = false;
            int baseHealth = 1000;
            int baseAttack = 130;
            int baseDefense = 30;
            God newGod = new God("Shiva", TrialNum, godIcon, description, sprite, attacking, baseHealth, baseAttack, baseDefense);
            newGod.CalculateUpgradedStats(TrialNum);
            gameController.LaborEnemy = newGod;

        }
        else if (modTrialNum == 6)
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite sprite = Resources.Load<Sprite>("GodSprites/BabaYagaSprite");
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/BabaYagaIcon");
            string description = "Baba Yaga - supernatural and often malevolent character, appearing as a hag " +
                "or witch with distinctive features. She is known for her bizarre and unsettling behavior, living " +
                "in a hut that stands on chicken legs and surrounded by a fence made of human bones. Prominent " +
                "figure in Slavic folklore.";
            // Create a new god with a specified icon
            bool attacking = false;
            int baseHealth = 1000;
            int baseAttack = 130;
            int baseDefense = 30;
            God newGod = new God("Baba Yaga", TrialNum, godIcon, description, sprite, attacking, baseHealth, baseAttack, baseDefense);
            newGod.CalculateUpgradedStats(TrialNum);
            gameController.LaborEnemy = newGod;

        }
        else if (modTrialNum == 7)
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite sprite = Resources.Load<Sprite>("GodSprites/ThorSprite");
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/ThorIcon");
            string description = "Thor - God of thunder, lightning, storms, and strength in Norse mythology. " +
                "He is a member of the Aesir, the principal group of gods in the Norse pantheon, and is often " +
                "depicted as a mighty and red-bearded warrior wielding the powerful hammer, Mjolnir.";
            // Create a new god with a specified icon
            bool attacking = false;
            int baseHealth = 1000;
            int baseAttack = 130;
            int baseDefense = 30;
            God newGod = new God("Thor", TrialNum, godIcon, description, sprite, attacking, baseHealth, baseAttack, baseDefense);
            newGod.CalculateUpgradedStats(TrialNum);
            gameController.LaborEnemy = newGod;

        }
        else if (modTrialNum == 8)
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite sprite = Resources.Load<Sprite>("GodSprites/AmaterasuSprite");
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/AmaterasuIcon");
            string description = "Amaterasu - Amaterasu is a central deity in Japanese Shinto mythology, " +
                "revered as the goddess of the sun and considered one of the most important and benevolent " +
                "figures in the Shinto pantheon.";
            // Create a new god with a specified icon
            bool attacking = false;
            int baseHealth = 1000;
            int baseAttack = 130;
            int baseDefense = 30;
            God newGod = new God("Amaterasu", TrialNum, godIcon, description, sprite, attacking, baseHealth, baseAttack, baseDefense);
            newGod.CalculateUpgradedStats(TrialNum);
            gameController.LaborEnemy = newGod;

        }
        else if (modTrialNum == 9)
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite sprite = Resources.Load<Sprite>("GodSprites/BeelzebubSprite");
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/BeelzebubIcon");
            string description = "Beelzebub - Beelzebub is commonly known as a demonic figure in Christian " +
                "demonology. The name is often used as another title for Satan or a high-ranking demon. Has " +
                "historical roots in the worship of a Philistine god named Baal-Zebub, which means " +
                "\"Lord of the Flies.\"";
            // Create a new god with a specified icon
            bool attacking = false;
            int baseHealth = 1000;
            int baseAttack = 130;
            int baseDefense = 30;
            God newGod = new God("Beelzebub", TrialNum, godIcon, description, sprite, attacking, baseHealth, baseAttack, baseDefense);
            newGod.CalculateUpgradedStats(TrialNum);
            gameController.LaborEnemy = newGod;

        }
        else if (modTrialNum == 10)
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite sprite = Resources.Load<Sprite>("GodSprites/TyphonSprite");
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/TyphonIcon");
            string description = "Typhon - Monstrous figure in Greek mythology, often regarded as one of the " +
                "most powerful and fearsome beings. Described as a colossal, hundred-headed monster with fiery " +
                "eyes and an immense wingspan.";
            // Create a new god with a specified icon
            bool attacking = false;
            int baseHealth = 1000;
            int baseAttack = 130;
            int baseDefense = 30;
            God newGod = new God("Typhon", TrialNum, godIcon, description, sprite, attacking, baseHealth, baseAttack, baseDefense);
            newGod.CalculateUpgradedStats(TrialNum);
            gameController.LaborEnemy = newGod;

        }
        else
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite sprite = Resources.Load<Sprite>("GodSprites/BoogeymanSprite");
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/BoogeymanIcon");
            string description = "Boogeyman - The Boogeyman's appearance is often left deliberately vague and " +
                "amorphous. It may take on various forms, allowing it to embody the fears and imagination of " +
                "different cultures.";
            // Create a new god with a specified icon
            bool attacking = false;
            int baseHealth = 1000;
            int baseAttack = 130;
            int baseDefense = 30;
            God newGod = new God("Boogeyman", TrialNum, godIcon, description, sprite, attacking, baseHealth, baseAttack, baseDefense);
            newGod.CalculateUpgradedStats(TrialNum);
            gameController.LaborEnemy = newGod;
        }
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

    public void WipeEnemyLaborPrefabs(){
        gameController.WipeListEnemyLaborPrefabs();
    }

    public void IncreaseNum(){
        int num = gameController.GetTrial();
        gameController.SetTrial(num+1);
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
