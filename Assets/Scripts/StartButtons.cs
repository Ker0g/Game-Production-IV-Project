using UnityEngine;

public class StartButtons : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        // Load the next scene when the button is clicked
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }

    public void QuitButton()
    {
        // Quit the application when the button is clicked
        Application.Quit();
    }
}
