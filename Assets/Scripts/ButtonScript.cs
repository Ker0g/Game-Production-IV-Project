using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonScript : MonoBehaviour
{
    GameObject player;
    [SerializeField] InputActionAsset inputActions;
    private InputAction pressAction;

    bool isPressed = false;
    bool canPress;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        pressAction = inputActions.FindAction("Interact");
        if(player)        {
            Debug.Log("Player found: " + player.name);
        }
        else
        {
            Debug.LogError("Player not found in the scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canPress && pressAction.WasPressedThisFrame())
        {
            isPressed = !isPressed;
            Debug.Log("Button Pressed: " + isPressed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);
        if (other.gameObject == player)
        {
            canPress = true;
            Debug.Log("Player entered button area. Can press: " + canPress);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            canPress = false;
        }
    }
}
