using UnityEngine;
using static GodScreenCanvas;

public class GodScreenCanvas : MonoBehaviour
{

    [SerializeField]
    private God godPass;

    public string canvasNameToToggle = "GodScreen";
    private GameObject currentCanvas;
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

    private void OnEnable()
    {
        // Assuming this script is attached to the canvas it should disable
        currentCanvas = gameObject;
    }

    public void SetGodInfo(God god)
    {
        this.godPass = god;
    }

    public void ToggleGodScreen()
    {
        //gameController.SetTappedGod(GodHolder.godData);
        // Disable the current canvas
        //Debug.Log("hi");
        Transform grandparent = transform.parent.parent.parent;

        //GodScreenCanvas useGod = GetComponentInParent<GodScreenCanvas>();
        GodScreenCanvas useGod = GetComponentInChildren<GodScreenCanvas>();
        Debug.Log("component in children: " + grandparent.gameObject.name);
        if (useGod != null)
        {
            Debug.Log("found component godscreenCanvas in parent: " + useGod);
        }
        gameController.SetTappedGod(useGod.godPass);
        
        // Find the canvas by its name
        GameObject canvasToToggle = grandparent.parent.Find(canvasNameToToggle)?.gameObject;
        Debug.Log("found: " + canvasToToggle);

        // Toggle the visibility of the canvas
        if (canvasToToggle != null)
        {
            

            canvasToToggle.gameObject.SetActive(true);

            if (grandparent != null)
            {
                grandparent.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("object not found with name: " + canvasNameToToggle);
        }

    }
}
