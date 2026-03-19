using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Vector3 startPos;

    [SerializeField] ButtonScript button;

    public Vector3 endPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (button != null) 
        {
            if (button.isPressed == true)
            {
                transform.position = Vector3.Lerp(transform.position, endPos, Time.deltaTime * 2);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime * 2);
            }
        }
    }
}
