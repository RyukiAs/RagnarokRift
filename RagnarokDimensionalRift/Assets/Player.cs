using UnityEngine;

public class Player : MonoBehaviour
{
    private GameController gameController;

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

    public void SummonGod()
    {
        int num = Random.Range(1, 12);

        if (num == 1)
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/CthulhuIcon");

            // Create a new god with a specified icon
            God newGod = new God("Cthulhu", 1, godIcon);
            gameController.allSummonedGods.Add(newGod);
        }else if (num == 2)
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/ZeusIcon");

            // Create a new god with a specified icon
            God newGod = new God("Zeus", 1, godIcon);
            gameController.allSummonedGods.Add(newGod);
        }else if (num == 3)
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/DionysusIcon");

            // Create a new god with a specified icon
            God newGod = new God("Dionysus", 1, godIcon);
            gameController.allSummonedGods.Add(newGod);
        }else if (num == 4)
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/NeptuneIcon");

            // Create a new god with a specified icon
            God newGod = new God("Neptune", 1, godIcon);
            gameController.allSummonedGods.Add(newGod);
        }else if (num == 5)
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/ShivaIcon");

            // Create a new god with a specified icon
            God newGod = new God("Shiva", 1, godIcon);
            gameController.allSummonedGods.Add(newGod);
        }else if (num == 6)
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/BabaYagaIcon");

            // Create a new god with a specified icon
            God newGod = new God("Baba Yaga", 1, godIcon);
            gameController.allSummonedGods.Add(newGod);
        }else if (num == 7)
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/ThorIcon");

            // Create a new god with a specified icon
            God newGod = new God("Thor", 1, godIcon);
            gameController.allSummonedGods.Add(newGod);
        }else if (num == 8)
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/AmaterasuIcon");

            // Create a new god with a specified icon
            God newGod = new God("Amaterasu", 1, godIcon);
            gameController.allSummonedGods.Add(newGod);
        }else if (num == 9)
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/BeelzebubIcon");

            // Create a new god with a specified icon
            God newGod = new God("Beelzebub", 1, godIcon);
            gameController.allSummonedGods.Add(newGod);
        }else if (num == 10)
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/TyphonIcon");

            // Create a new god with a specified icon
            God newGod = new God("Typhon", 1, godIcon);
            gameController.allSummonedGods.Add(newGod);
        }else 
        {
            // Load the icon sprite (you can set this in the Unity Editor)
            Sprite godIcon = Resources.Load<Sprite>("GodIcons/BoogeymanIcon");

            // Create a new god with a specified icon
            God newGod = new God("Boogeyman", 1, godIcon);
            gameController.allSummonedGods.Add(newGod);
        }


    }

    // Additional methods for handling the inventory
}
