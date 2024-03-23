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

    public void SummonGod(int times)
    {
        for (int i = 0; i < times; i++)
        {
            int num = Random.Range(1, 12);

            if (num == 1)
            {
                // Load the icon sprite (you can set this in the Unity Editor)
                Sprite sprite = Resources.Load<Sprite>("GodSprites/CthulhuSprite");
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/CthulhuIcon");
                string description = "Cthulhu - described as a monstrous being with an octopoid head, " +
                    "a scaly body, and bat-like wings. It is part of a pantheon of cosmic deities known as " +
                    "the Great Old Ones.";
                // Create a new god with a specified icon
                God newGod = new God("Cthulhu", 1, godIcon, description, sprite);
                gameController.allSummonedGods.Add(newGod);

            }
            else if (num == 2)
            {
                // Load the icon sprite (you can set this in the Unity Editor)
                Sprite sprite = Resources.Load<Sprite>("GodSprites/ZeusSprite");
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/ZeusIcon");
                string description = "Zeus - depicted as a powerful and majestic figure, wielding a thunderbolt " +
                    "as his symbol of authority. One of the big three of the Greek Gods. The god of lighting in " +
                    "Greek mythology, also seen as the most important Greek God.";
                // Create a new god with a specified icon
                God newGod = new God("Zeus", 1, godIcon, description, sprite);
                gameController.allSummonedGods.Add(newGod);

            }
            else if (num == 3)
            {
                // Load the icon sprite (you can set this in the Unity Editor)
                Sprite sprite = Resources.Load<Sprite>("GodSprites/DionysusSprite");
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/DionysusIcon");
                string description = "Dionysus - known as the god of wine, festivities, and theater. One of the " +
                    "Twelve Greek Olympians.";
                // Create a new god with a specified icon
                God newGod = new God("Dionysus", 1, godIcon, description, sprite);
                gameController.allSummonedGods.Add(newGod);

            }
            else if (num == 4)
            {
                // Load the icon sprite (you can set this in the Unity Editor)
                Sprite sprite = Resources.Load<Sprite>("GodSprites/NeptuneSprite");
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/NeptuneIcon");
                string description = "Neptune - god of the sea, freshwater, earthquakes, and horses in Roman mythology. " +
                    "He is one of the twelve Olympian deities and holds a position of great importance among the Roman " +
                    "gods. Neptune is often depicted as a powerful and bearded deity, holding a trident";
                // Create a new god with a specified icon
                God newGod = new God("Neptune", 1, godIcon, description, sprite);
                gameController.allSummonedGods.Add(newGod);

            }
            else if (num == 5)
            {
                // Load the icon sprite (you can set this in the Unity Editor)
                Sprite sprite = Resources.Load<Sprite>("GodSprites/ShivaSprite");
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/ShivaIcon");
                string description = "Shiva - Hindu god of destruction. One of the most important Hindu Gods. " +
                    "Described as having 3 eyes, multiple hands holding a trident and skull.";
                // Create a new god with a specified icon
                God newGod = new God("Shiva", 1, godIcon, description, sprite);
                gameController.allSummonedGods.Add(newGod);

            }
            else if (num == 6)
            {
                // Load the icon sprite (you can set this in the Unity Editor)
                Sprite sprite = Resources.Load<Sprite>("GodSprites/BabaYagaSprite");
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/BabaYagaIcon");
                string description = "Baba Yaga - supernatural and often malevolent character, appearing as a hag " +
                    "or witch with distinctive features. She is known for her bizarre and unsettling behavior, living " +
                    "in a hut that stands on chicken legs and surrounded by a fence made of human bones. Prominent " +
                    "figure in Slavic folklore.";
                // Create a new god with a specified icon
                God newGod = new God("Baba Yaga", 1, godIcon, description, sprite);
                gameController.allSummonedGods.Add(newGod);

            }
            else if (num == 7)
            {
                // Load the icon sprite (you can set this in the Unity Editor)
                Sprite sprite = Resources.Load<Sprite>("GodSprites/ThorSprite");
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/ThorIcon");
                string description = "Thor - God of thunder, lightning, storms, and strength in Norse mythology. " +
                    "He is a member of the Aesir, the principal group of gods in the Norse pantheon, and is often " +
                    "depicted as a mighty and red-bearded warrior wielding the powerful hammer, Mjolnir.";
                // Create a new god with a specified icon
                God newGod = new God("Thor", 1, godIcon, description, sprite);
                gameController.allSummonedGods.Add(newGod);

            }
            else if (num == 8)
            {
                // Load the icon sprite (you can set this in the Unity Editor)
                Sprite sprite = Resources.Load<Sprite>("GodSprites/AmaterasuSprite");
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/AmaterasuIcon");
                string description = "Amaterasu - Amaterasu is a central deity in Japanese Shinto mythology, " +
                    "revered as the goddess of the sun and considered one of the most important and benevolent " +
                    "figures in the Shinto pantheon.";
                // Create a new god with a specified icon
                God newGod = new God("Amaterasu", 1, godIcon, description, sprite);
                gameController.allSummonedGods.Add(newGod);

            }
            else if (num == 9)
            {
                // Load the icon sprite (you can set this in the Unity Editor)
                Sprite sprite = Resources.Load<Sprite>("GodSprites/BeelzebubSprite");
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/BeelzebubIcon");
                string description = "Beelzebub - Beelzebub is commonly known as a demonic figure in Christian " +
                    "demonology. The name is often used as another title for Satan or a high-ranking demon. Has " +
                    "historical roots in the worship of a Philistine god named Baal-Zebub, which means " +
                    "\"Lord of the Flies.\"";
                // Create a new god with a specified icon
                God newGod = new God("Beelzebub", 1, godIcon, description, sprite);
                gameController.allSummonedGods.Add(newGod);

            }
            else if (num == 10)
            {
                // Load the icon sprite (you can set this in the Unity Editor)
                Sprite sprite = Resources.Load<Sprite>("GodSprites/TyphonSprite");
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/TyphonIcon");
                string description = "Typhon - Monstrous figure in Greek mythology, often regarded as one of the " +
                    "most powerful and fearsome beings. Described as a colossal, hundred-headed monster with fiery " +
                    "eyes and an immense wingspan.";
                // Create a new god with a specified icon
                God newGod = new God("Typhon", 1, godIcon, description, sprite);
                gameController.allSummonedGods.Add(newGod);

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
                God newGod = new God("Boogeyman", 1, godIcon, description, sprite);
                gameController.allSummonedGods.Add(newGod);
            }
        }
    }
}
