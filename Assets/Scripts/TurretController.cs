using UnityEngine;

public class TurretController : MonoBehaviour
{

    [SerializeField] FieldOfView fov;

    float TimeToFire = 1f;
    bool alarmSounded = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fov.IsTargetVisible(GameObject.FindGameObjectWithTag("Player").transform))
        {
            if (!alarmSounded)
            {
                Debug.Log("Player spotted!");
                SoundManager.PlaySound("turretbeep");
                alarmSounded = true;
            }

            TimeToFire -= Time.deltaTime;
            if (TimeToFire <= 0f)
            {
              Debug.Log("Player hit!");
              UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }
            else
            {
                TimeToFire = 1f;
                alarmSounded = false;
            }
    }
}
