using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class  changeScene : MonoBehaviour
{
    // Specify the scene name you want to load
    public string sceneToLoad;
    public RectTransform yourPanelRectTransform;
    

    private void Awake()
    {
        // Register a method to be called when a scene is loaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the loaded scene is the main scene (assuming it's at build index 0)
        if (scene.buildIndex == 0)
        {
            // Set the panel's Y position based on the saved value
            //print("hi");
            SetPanelYPosition(PlayerPrefs.GetFloat("PanelYValue"));
        }
    }

    public void SetPanelYPosition(float yPosition)
    {
        // Set the Y position of the main menu panel
        //print("function: "+yPosition);

        // Get the current anchored position
        Vector2 currentPosition = yourPanelRectTransform.anchoredPosition;

        // Modify the Y coordinate
        currentPosition.y = yPosition;

        // Set the new anchored position
        yourPanelRectTransform.anchoredPosition = currentPosition;

    }

    // This function will be called when the button is pressed
    public void CelestialSummit()
    {
        // Load the specified scene
        float panelYValue = yourPanelRectTransform.anchoredPosition.y;
        //print(panelYValue);
        PlayerPrefs.SetFloat("PanelYValue", panelYValue);
        SceneManager.LoadScene(2);
        
    }
    public void AstralArchives()
    {
        // Load the specified scene
        float panelYValue = yourPanelRectTransform.anchoredPosition.y;
        //print(panelYValue);
        PlayerPrefs.SetFloat("PanelYValue", panelYValue);
        SceneManager.LoadScene(1);
    }
    public void Colosseum()
    {
        // Load the specified scene
        float panelYValue = yourPanelRectTransform.anchoredPosition.y;
        //print(panelYValue);
        PlayerPrefs.SetFloat("PanelYValue", panelYValue);
        SceneManager.LoadScene(3);
    }

    public void Labors()
    {
        // Load the specified scene
        float panelYValue = yourPanelRectTransform.anchoredPosition.y;
        //print(panelYValue);
        PlayerPrefs.SetFloat("PanelYValue", panelYValue);
        SceneManager.LoadScene(4);
    }

    public void MythicalMarket()
    {
        // Load the specified scene
        float panelYValue = yourPanelRectTransform.anchoredPosition.y;
        //print(panelYValue);
        PlayerPrefs.SetFloat("PanelYValue", panelYValue);
        SceneManager.LoadScene(5);
    }

    public void HephaestusHellforge()
    {
        // Load the specified scene
        float panelYValue = yourPanelRectTransform.anchoredPosition.y;
        //print(panelYValue);
        PlayerPrefs.SetFloat("PanelYValue", panelYValue);
        SceneManager.LoadScene(6);
    }
    public void TreasureTrove()
    {
        // Load the specified scene
        float panelYValue = yourPanelRectTransform.anchoredPosition.y;
        //print(panelYValue);
        PlayerPrefs.SetFloat("PanelYValue", panelYValue);
        SceneManager.LoadScene(7);
    }

    public void EssenceOfGods()
    {
        // Load the specified scene
        float panelYValue = yourPanelRectTransform.anchoredPosition.y;
        //print(panelYValue);
        PlayerPrefs.SetFloat("PanelYValue", panelYValue);
        SceneManager.LoadScene(8);
    }

    public void SeatOfOlympus()
    {
        // Load the specified scene
        float panelYValue = yourPanelRectTransform.anchoredPosition.y;
        //print(panelYValue);
        PlayerPrefs.SetFloat("PanelYValue", panelYValue);
        SceneManager.LoadScene(9);
    }

    public void ConfirmBattle()
    {
        // Load the specified scene
        SceneManager.LoadScene(10);
    }

    public void BackToMain()
    {
        // Load the specified scene
        SceneManager.LoadScene(0);
        
    }

    private void OnDestroy()
    {
        // Unregister the sceneLoaded method when the script is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
