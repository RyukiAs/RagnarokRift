using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaborBattle : MonoBehaviour
{
    private GameController gameController;

    [SerializeField]
    private GameObject godIconPrefab;

    [SerializeField]
    private Transform iconsParent;

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
        Battle();
    }

    public void Battle()
    {
        foreach(God god in gameController.GetLaborGods())
        {
            GameObject godIcon = Instantiate(godIconPrefab, iconsParent);
            RectTransform godIconRectTransform = godIcon.GetComponent<RectTransform>();
            godIconRectTransform.anchoredPosition = god.position;
        }
    }
}
