using UnityEngine;
using UnityEngine.SceneManagement;

public class  changeScene : MonoBehaviour
{
    // Specify the scene name you want to load
    public string sceneToLoad;

    // This function will be called when the button is pressed
    public void CelestialSummit()
    {
        // Load the specified scene
        SceneManager.LoadScene(2);
    }
    public void AstralArchives()
    {
        // Load the specified scene
        SceneManager.LoadScene(1);
    }
    public void Colosseum()
    {
        // Load the specified scene
        SceneManager.LoadScene(3);
    }

    public void Labors()
    {
        // Load the specified scene
        SceneManager.LoadScene(4);
    }

    public void MythicalMarket()
    {
        // Load the specified scene
        SceneManager.LoadScene(5);
    }

    public void HephaestusHellforge()
    {
        // Load the specified scene
        SceneManager.LoadScene(6);
    }
    public void TreasureTrove()
    {
        // Load the specified scene
        SceneManager.LoadScene(7);
    }

    public void EssenceOfGods()
    {
        // Load the specified scene
        SceneManager.LoadScene(8);
    }

    public void SeatOfOlympus()
    {
        // Load the specified scene
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

}
