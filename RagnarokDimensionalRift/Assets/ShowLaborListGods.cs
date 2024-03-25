using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowLaborListGods : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private GameController gameController;

    [SerializeField]
    public God godPass;

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

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
        DisplayGodIcons();
    }
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        Transform sprite = this.gameObject.transform.Find("Sprite");
        canvasGroup = sprite.gameObject.GetComponent<CanvasGroup>();
        canvasGroup.alpha = .8f;
        canvasGroup.blocksRaycasts = false;

    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag"); 
        Transform sprite = this.gameObject.transform.Find("Sprite");
        canvasGroup = sprite.gameObject.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("test");
        Transform sprite = this.gameObject.transform.Find("Sprite");
        Transform icon = this.gameObject.transform.Find("Icon");
        sprite.gameObject.SetActive(true);
        icon.gameObject.SetActive(false);
        //Image spriteImage = sprite.GetComponent<Image>();
        //spriteImage.sprite = this.godPass.sprite;
    }

    public void OnDrop(PointerEventData eventData)
    {
        //rectTransform.anchoredPosition = eventData.pointerCurrentRaycast.worldPosition;

    }

    //Will display all the Gods in EssenceGods
    private void DisplayGodIcons()
    {
        // Get the summoned gods
        List<God> laborGods = GameController.Instance.GetLaborGods();
        Transform iconObj = this.gameObject.transform.Find("Icon");
        CanvasGroup canvasGroup= iconObj.GetComponent<CanvasGroup>();

        canvasGroup.alpha = 1f; // see
        canvasGroup.interactable = true; // interactable

        Debug.Log(gameObject.name);
        for (int i = 0; i <= 5; i++)
        {
            string objName = "LaborBattlePrefab" + i.ToString();
            if (gameObject.name == objName)
            {
                if (laborGods != null && i < laborGods.Count)
                {
                    if (laborGods[i] != null)
                    {
                        Debug.Log("Set prefab god");
                        this.godPass = laborGods[i];
                    }
                    else
                    {
                        Debug.LogWarning("No god found at index " + i);
                        // Handle the case where laborGods[i] is null
                        if (canvasGroup != null)
                        {
                            canvasGroup.alpha = 0f; // Transparent
                            canvasGroup.interactable = false; // Uninteractable
                        }
                        else
                        {
                            Debug.LogWarning("CanvasGroup component not found.");
                            // Handle the case where CanvasGroup component is not found
                        }
                    }
                }
                else
                {
                    Debug.LogWarning("laborGods is null or index " + i + " is out of bounds.");
                    if (canvasGroup != null)
                    {
                        canvasGroup.alpha = 0f; // Transparent
                        canvasGroup.interactable = false; // Uninteractable
                    }
                    else
                    {
                        Debug.LogWarning("CanvasGroup component not found.");
                        // Handle the case where CanvasGroup component is not found
                    }
                    // Handle the case where laborGods is null or index is out of bounds
                }
            }
        }

        // Instantiate the god icon prefab
        GameObject godIcon = this.gameObject;

        Image[] iconImages = godIcon.GetComponentsInChildren<Image>(true);
        Image secondIconImage = iconImages.Length >= 2 ? iconImages[1] : null;

        Transform sprite = this.gameObject.transform.Find("Sprite");
        Image spriteImage = sprite.GetComponent<Image>();
        spriteImage.sprite = this.godPass.sprite;
        //Debug.Log("Number of Image components: " + iconImages.Length);
        //Debug.Log("Second Image component: " + secondIconImage);

        if (secondIconImage != null)
        {
            secondIconImage.sprite = this.godPass.icon;
        }


        TextMeshProUGUI gradeText = null;
        TextMeshProUGUI levelText = null;

        foreach (TextMeshProUGUI textComponent in godIcon.GetComponentsInChildren<TextMeshProUGUI>())
        {
            //Debug.Log("Found Text Component: " + textComponent.gameObject.name);

            if (textComponent.gameObject.name == "GradeText")
            {
                gradeText = textComponent;
            }
            else if (textComponent.gameObject.name == "LevelText")
            {
                levelText = textComponent;
            }
            // Add more conditions if you have other named text components
        }

        //Debug.Log("Grade Text Component: " + (gradeText != null ? gradeText.gameObject.name : "Not found"));
        //Debug.Log("Level Text Component: " + (levelText != null ? levelText.gameObject.name : "Not found"));


        if (gradeText != null)
        {
            Dictionary<int, string> gradeMap = new Dictionary<int, string>
                {
                    { 1, "FFF" },
                    { 2, "FF" },
                    { 3, "F" },
                    { 4, "E" },
                    { 5, "D" },
                    { 6, "C" },
                    { 7, "B" },
                    { 8, "A" },
                    { 9, "S" },
                    { 10, "SS" },
                    { 11, "SSS" }
                };

            if (gradeMap.TryGetValue(this.godPass.grade, out string gradeString))
            {
                gradeText.text = gradeString;
            }
            else
            {
                gradeText.text = "Unknown Grade";
            }
        }
        if (levelText != null)
        {
            levelText.text = this.godPass.level.ToString();
        }
        else
        {
            Debug.Log("Error in setting level");
        }
    }
}
