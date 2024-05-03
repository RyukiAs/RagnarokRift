using System.Collections.Generic;
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
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/newCthulhuIcon");
                List<Sprite> animation = new List<Sprite> {
                    Resources.Load<Sprite>("GodAnimationFrames/Cthulhu/frame_001"),
                    Resources.Load<Sprite>("GodAnimationFrames/Cthulhu/frame_002"),
                    Resources.Load<Sprite>("GodAnimationFrames/Cthulhu/frame_003"),
                };
                string description = "Cthulhu - described as a monstrous being with an octopoid head, " +
                    "a scaly body, and bat-like wings. It is part of a pantheon of cosmic deities known as " +
                    "the Great Old Ones.";
                // Create a new god with a specified icon
                bool attacking = true;
                int baseHealth = 1790;
                int baseAttack = 150;
                int baseDefense = 80;
                God newGod = new God("Cthulhu", 1, 1, godIcon, description, sprite, attacking, baseHealth, baseAttack, baseDefense, animation);
                gameController.allSummonedGods.Add(newGod);

            }
            else if (num == 2)
            {
                // Load the icon sprite (you can set this in the Unity Editor)
                Sprite sprite = Resources.Load<Sprite>("GodSprites/ZeusSprite");
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/newZeusIcon");
                string description = "Zeus - depicted as a powerful and majestic figure, wielding a thunderbolt " +
                    "as his symbol of authority. One of the big three of the Greek Gods. The god of lighting in " +
                    "Greek mythology, also seen as the most important Greek God.";
                // Create a new god with a specified icon
                List<Sprite> animation = new List<Sprite> {
                    Resources.Load<Sprite>("GodAnimationFrames/Zeus/frame_001"),
                    Resources.Load<Sprite>("GodAnimationFrames/Zeus/frame_002"),
                    Resources.Load<Sprite>("GodAnimationFrames/Zeus/frame_003"),
                    Resources.Load<Sprite>("GodAnimationFrames/Zeus/frame_004"),
                    Resources.Load<Sprite>("GodAnimationFrames/Zeus/frame_005"),
                    Resources.Load<Sprite>("GodAnimationFrames/Zeus/frame_006"),
                    Resources.Load<Sprite>("GodAnimationFrames/Zeus/frame_007"),
                    // Add more frames as needed
                };
                bool attacking = true;
                int baseHealth = 1380;
                int baseAttack = 205;
                int baseDefense = 65;
                God newGod = new God("Zeus", 1, 1, godIcon, description, sprite,attacking, baseHealth, baseAttack, baseDefense, animation);
                gameController.allSummonedGods.Add(newGod);

            }
            else if (num == 3)
            {
                // Load the icon sprite (you can set this in the Unity Editor)
                Sprite sprite = Resources.Load<Sprite>("GodSprites/DionysusSprite");
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/newDionysusIcon");
                string description = "Dionysus - known as the god of wine, festivities, and theater. One of the " +
                    "Twelve Greek Olympians.";
                // Create a new god with a specified icon
                List<Sprite> animation = new List<Sprite> {
                    Resources.Load<Sprite>("GodAnimationFrames/Dionysus/frame_001"),
                    Resources.Load<Sprite>("GodAnimationFrames/Dionysus/frame_002"),
                    Resources.Load<Sprite>("GodAnimationFrames/Dionysus/frame_003"),
                    Resources.Load<Sprite>("GodAnimationFrames/Dionysus/frame_004"),
                    Resources.Load<Sprite>("GodAnimationFrames/Dionysus/frame_005"),
                    Resources.Load<Sprite>("GodAnimationFrames/Dionysus/frame_006"),
                    Resources.Load<Sprite>("GodAnimationFrames/Dionysus/frame_007"),
                    Resources.Load<Sprite>("GodAnimationFrames/Dionysus/frame_008"),
                    Resources.Load<Sprite>("GodAnimationFrames/Dionysus/frame_009"),
                    Resources.Load<Sprite>("GodAnimationFrames/Dionysus/frame_010"),
                    // Add more frames as needed
                };
                bool attacking = true;
                int baseHealth = 1600;
                int baseAttack = 170;
                int baseDefense = 70;
                God newGod = new God("Dionysus", 1, 1, godIcon, description, sprite, attacking, baseHealth, baseAttack, baseDefense, animation);
                gameController.allSummonedGods.Add(newGod);

            }
            else if (num == 4)
            {
                // Load the icon sprite (you can set this in the Unity Editor)
                Sprite sprite = Resources.Load<Sprite>("GodSprites/NeptuneSprite");
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/newNeptuneIcon");
                string description = "Neptune - god of the sea, freshwater, earthquakes, and horses in Roman mythology. " +
                    "He is one of the twelve Olympian deities and holds a position of great importance among the Roman " +
                    "gods. Neptune is often depicted as a powerful and bearded deity, holding a trident";
                // Create a new god with a specified icon
                List<Sprite> animation = new List<Sprite> {
                    Resources.Load<Sprite>("GodAnimationFrames/Neptune/frame_001"),
                    Resources.Load<Sprite>("GodAnimationFrames/Neptune/frame_002"),
                    Resources.Load<Sprite>("GodAnimationFrames/Neptune/frame_003"),
                    Resources.Load<Sprite>("GodAnimationFrames/Neptune/frame_004"),
                    Resources.Load<Sprite>("GodAnimationFrames/Neptune/frame_005"),
                    Resources.Load<Sprite>("GodAnimationFrames/Neptune/frame_006"),
                    Resources.Load<Sprite>("GodAnimationFrames/Neptune/frame_007"),
                    Resources.Load<Sprite>("GodAnimationFrames/Neptune/frame_008"),
                    // Add more frames as needed
                };
                bool attacking = true;
                int baseHealth = 1440;
                int baseAttack = 210;
                int baseDefense = 57;
                God newGod = new God("Neptune", 1, 1, godIcon, description, sprite, attacking, baseHealth, baseAttack, baseDefense, animation);
                gameController.allSummonedGods.Add(newGod);

            }
            else if (num == 5)
            {
                // Load the icon sprite (you can set this in the Unity Editor)
                Sprite sprite = Resources.Load<Sprite>("GodSprites/ShivaSprite");
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/newShivaIcon");
                string description = "Shiva - Hindu god of destruction. One of the most important Hindu Gods. " +
                    "Described as having 3 eyes, multiple hands holding a trident and skull.";
                // Create a new god with a specified icon
                List<Sprite> animation = new List<Sprite> {
                    Resources.Load<Sprite>("GodAnimationFrames/Shiva/frame_001"),
                    Resources.Load<Sprite>("GodAnimationFrames/Shiva/frame_002"),
                    Resources.Load<Sprite>("GodAnimationFrames/Shiva/frame_003"),
                    Resources.Load<Sprite>("GodAnimationFrames/Shiva/frame_004"),
                    Resources.Load<Sprite>("GodAnimationFrames/Shiva/frame_005"),
                    Resources.Load<Sprite>("GodAnimationFrames/Shiva/frame_006"),
                    Resources.Load<Sprite>("GodAnimationFrames/Shiva/frame_007"),
                    Resources.Load<Sprite>("GodAnimationFrames/Shiva/frame_008"),
                    Resources.Load<Sprite>("GodAnimationFrames/Shiva/frame_009"),
                    Resources.Load<Sprite>("GodAnimationFrames/Shiva/frame_010"),
                    // Add more frames as needed
                };
                bool attacking = true;
                int baseHealth = 1300;
                int baseAttack = 235;
                int baseDefense = 50;
                God newGod = new God("Shiva", 1, 1, godIcon, description, sprite, attacking, baseHealth, baseAttack, baseDefense, animation);
                gameController.allSummonedGods.Add(newGod);

            }
            else if (num == 6)
            {
                // Load the icon sprite (you can set this in the Unity Editor)
                Sprite sprite = Resources.Load<Sprite>("GodSprites/BabaYagaSpriteFlipped");
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/newBabaYagaIcon");
                string description = "Baba Yaga - supernatural and often malevolent character, appearing as a hag " +
                    "or witch with distinctive features. She is known for her bizarre and unsettling behavior, living " +
                    "in a hut that stands on chicken legs and surrounded by a fence made of human bones. Prominent " +
                    "figure in Slavic folklore.";
                // Create a new god with a specified icon
                List<Sprite> animation = new List<Sprite> {
                    Resources.Load<Sprite>("GodAnimationFrames/BabaYaga/frame_001"),
                    Resources.Load<Sprite>("GodAnimationFrames/BabaYaga/frame_002"),
                    Resources.Load<Sprite>("GodAnimationFrames/BabaYaga/frame_003"),
                    Resources.Load<Sprite>("GodAnimationFrames/BabaYaga/frame_004"),
                };
                bool attacking = true;
                int baseHealth = 1360;
                int baseAttack = 200;
                int baseDefense = 60;
                God newGod = new God("Baba Yaga", 1, 1, godIcon, description, sprite, attacking, baseHealth, baseAttack, baseDefense, animation);
                gameController.allSummonedGods.Add(newGod);

            }
            else if (num == 7)
            {
                // Load the icon sprite (you can set this in the Unity Editor)
                Sprite sprite = Resources.Load<Sprite>("GodSprites/ThorSprite");
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/newThorIcon");
                string description = "Thor - God of thunder, lightning, storms, and strength in Norse mythology. " +
                    "He is a member of the Aesir, the principal group of gods in the Norse pantheon, and is often " +
                    "depicted as a mighty and red-bearded warrior wielding the powerful hammer, Mjolnir.";
                // Create a new god with a specified icon
                List<Sprite> animation = new List<Sprite> {
                    Resources.Load<Sprite>("GodAnimationFrames/Thor/frame_001"),
                    Resources.Load<Sprite>("GodAnimationFrames/Thor/frame_002"),
                    Resources.Load<Sprite>("GodAnimationFrames/Thor/frame_003"),
                    Resources.Load<Sprite>("GodAnimationFrames/Thor/frame_004"),
                    Resources.Load<Sprite>("GodAnimationFrames/Thor/frame_005"),
                    Resources.Load<Sprite>("GodAnimationFrames/Thor/frame_006"),
                    Resources.Load<Sprite>("GodAnimationFrames/Thor/frame_007"),
                    Resources.Load<Sprite>("GodAnimationFrames/Thor/frame_008"),
                    // Add more frames as needed
                };
                bool attacking = true;
                int baseHealth = 1430;
                int baseAttack = 220;
                int baseDefense = 62;
                God newGod = new God("Thor", 1, 1, godIcon, description, sprite, attacking, baseHealth, baseAttack, baseDefense, animation);
                gameController.allSummonedGods.Add(newGod);

            }
            else if (num == 8)
            {
                // Load the icon sprite (you can set this in the Unity Editor)
                Sprite sprite = Resources.Load<Sprite>("GodSprites/AmaterasuSprite");
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/newAmaterasuIcon");
                string description = "Amaterasu - Amaterasu is a central deity in Japanese Shinto mythology, " +
                    "revered as the goddess of the sun and considered one of the most important and benevolent " +
                    "figures in the Shinto pantheon.";
                // Create a new god with a specified icon
                List<Sprite> animation = new List<Sprite> {
                    Resources.Load<Sprite>("GodAnimationFrames/Amaterasu/frame_001"),
                    Resources.Load<Sprite>("GodAnimationFrames/Amaterasu/frame_002"),
                    Resources.Load<Sprite>("GodAnimationFrames/Amaterasu/frame_003"),
                    Resources.Load<Sprite>("GodAnimationFrames/Amaterasu/frame_004"),
                    Resources.Load<Sprite>("GodAnimationFrames/Amaterasu/frame_005"),
                    // Add more frames as needed
                };
                bool attacking = true;
                int baseHealth = 1520;
                int baseAttack = 168;
                int baseDefense = 68;
                God newGod = new God("Amaterasu", 1, 1, godIcon, description, sprite, attacking, baseHealth, baseAttack, baseDefense, animation);
                gameController.allSummonedGods.Add(newGod);

            }
            else if (num == 9)
            {
                // Load the icon sprite (you can set this in the Unity Editor)
                Sprite sprite = Resources.Load<Sprite>("GodSprites/BeelzebubSprite");
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/newBeelzebubIcon");
                string description = "Beelzebub - Beelzebub is commonly known as a demonic figure in Christian " +
                    "demonology. The name is often used as another title for Satan or a high-ranking demon. Has " +
                    "historical roots in the worship of a Philistine god named Baal-Zebub, which means " +
                    "\"Lord of the Flies.\"";
                // Create a new god with a specified icon
                List<Sprite> animation = new List<Sprite> {
                    Resources.Load<Sprite>("GodAnimationFrames/Beelzebub/frame_001"),
                    Resources.Load<Sprite>("GodAnimationFrames/Beelzebub/frame_002"),
                    Resources.Load<Sprite>("GodAnimationFrames/Beelzebub/frame_003"),
                    Resources.Load<Sprite>("GodAnimationFrames/Beelzebub/frame_004"),
                    Resources.Load<Sprite>("GodAnimationFrames/Beelzebub/frame_005"),
                    Resources.Load<Sprite>("GodAnimationFrames/Beelzebub/frame_006"),
                    Resources.Load<Sprite>("GodAnimationFrames/Beelzebub/frame_007"),
                    Resources.Load<Sprite>("GodAnimationFrames/Beelzebub/frame_008"),
                    // Add more frames as needed
                };
                bool attacking = true;
                int baseHealth = 1332;
                int baseAttack = 225;
                int baseDefense = 57;
                God newGod = new God("Beelzebub", 1, 1, godIcon, description, sprite, attacking, baseHealth, baseAttack, baseDefense, animation);
                gameController.allSummonedGods.Add(newGod);

            }
            else if (num == 10)
            {
                // Load the icon sprite (you can set this in the Unity Editor)
                Sprite sprite = Resources.Load<Sprite>("GodSprites/TyphonSpriteFlipped");
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/newTyphonIcon");
                string description = "Typhon - Monstrous figure in Greek mythology, often regarded as one of the " +
                    "most powerful and fearsome beings. Described as a colossal, hundred-headed monster with fiery " +
                    "eyes and an immense wingspan.";
                // Create a new god with a specified icon
                List<Sprite> animation = new List<Sprite> {
                    Resources.Load<Sprite>("GodAnimationFrames/Typhon/frame_001"),
                    Resources.Load<Sprite>("GodAnimationFrames/Typhon/frame_002"),
                    Resources.Load<Sprite>("GodAnimationFrames/Typhon/frame_003"),
                    Resources.Load<Sprite>("GodAnimationFrames/Typhon/frame_004"),
                    Resources.Load<Sprite>("GodAnimationFrames/Typhon/frame_005"),
                    Resources.Load<Sprite>("GodAnimationFrames/Typhon/frame_006"),
                    Resources.Load<Sprite>("GodAnimationFrames/Typhon/frame_007"),
                    // Add more frames as needed
                };
                bool attacking = true;
                int baseHealth = 1800;
                int baseAttack = 155;
                int baseDefense = 80;
                God newGod = new God("Typhon", 1, 1, godIcon, description, sprite,attacking, baseHealth, baseAttack, baseDefense, animation);
                gameController.allSummonedGods.Add(newGod);

            }
            else
            {
                // Load the icon sprite (you can set this in the Unity Editor)
                Sprite sprite = Resources.Load<Sprite>("GodSprites/BoogeymanSprite");
                Sprite godIcon = Resources.Load<Sprite>("GodIcons/newBoogeymanIcon");
                string description = "Boogeyman - The Boogeyman's appearance is often left deliberately vague and " +
                    "amorphous. It may take on various forms, allowing it to embody the fears and imagination of " +
                    "different cultures.";
                // Create a new god with a specified icon
                List<Sprite> animation = new List<Sprite> {
                    Resources.Load<Sprite>("GodAnimationFrames/Boogeyman/frame_001"),
                    Resources.Load<Sprite>("GodAnimationFrames/Boogeyman/frame_002"),
                    Resources.Load<Sprite>("GodAnimationFrames/Boogeyman/frame_003"),
                    Resources.Load<Sprite>("GodAnimationFrames/Boogeyman/frame_004"),
                    Resources.Load<Sprite>("GodAnimationFrames/Boogeyman/frame_005"),
                    Resources.Load<Sprite>("GodAnimationFrames/Boogeyman/frame_006"),
                    Resources.Load<Sprite>("GodAnimationFrames/Boogeyman/frame_007"),
                    Resources.Load<Sprite>("GodAnimationFrames/Boogeyman/frame_008"),
                    Resources.Load<Sprite>("GodAnimationFrames/Boogeyman/frame_009"),
                    Resources.Load<Sprite>("GodAnimationFrames/Boogeyman/frame_010"),
                    // Add more frames as needed
                };
                bool attacking = true;
                int baseHealth = 1320;
                int baseAttack = 230;
                int baseDefense = 53;
                God newGod = new God("Boogeyman", 1, 1, godIcon, description, sprite,attacking, baseHealth, baseAttack, baseDefense, animation);
                gameController.allSummonedGods.Add(newGod);
            }
        }
    }
}
