using UnityEngine;

public class GodScreenCanvas : MonoBehaviour
{
    public string canvasNameToToggle = "GodScreen";
    private GameObject currentCanvas;

    private void OnEnable()
    {
        // Assuming this script is attached to the canvas it should disable
        currentCanvas = gameObject;
    }

    public void ToggleGodScreen()
    {
        // Disable the current canvas
        Debug.Log("hi");
        Transform grandparent = transform.parent.parent.parent;


        if (grandparent != null)
        {
            grandparent.gameObject.SetActive(false);
        }
        // Find the canvas by its name
        GameObject canvasToToggle = grandparent.parent.Find(canvasNameToToggle)?.gameObject;
        Debug.LogError("found: " + canvasToToggle);

        // Toggle the visibility of the canvas
        if (canvasToToggle != null)
        {
            canvasToToggle.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("object not found with name: " + canvasNameToToggle);
        }
    }
}
