using UnityEngine;

public class ExitScript : MonoBehaviour
{

    public string exitSceneName = "ExitScene";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Load the exit scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(exitSceneName);
        }
    }
}
