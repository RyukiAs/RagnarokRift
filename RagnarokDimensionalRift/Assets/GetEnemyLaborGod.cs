using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetEnemyLaborGod : MonoBehaviour
{
    private GameController gameController;

    [SerializeField]
    public God godPass;

    private void Start()
    {
        // Your existing code
        gameController = GameController.Instance;
        if (gameController == null)
        {
            Debug.Log("GameController instance not found. Make sure GameControllerInitializer script is in the scene.");
        }
    }

    private void OnEnable()
    {
        DisplayGod();
    }

    private void DisplayGod()
    {
        godPass = gameController.LaborEnemy;

        Transform obj = this.gameObject.transform.Find("Image");
        Image sprite = obj.GetComponent<Image>();
        sprite.sprite = godPass.sprite;

        RectTransform holdGod = this.gameObject.GetComponent<RectTransform>();
        Debug.Log("holdGod position" + holdGod.anchoredPosition);
        godPass.position= holdGod.anchoredPosition;
    }
}
