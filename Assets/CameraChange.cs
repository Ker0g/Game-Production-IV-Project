using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Vector3[] positions;
    public Vector3[] rotations;

    public int nextPos = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SwapCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwapCamera();
        }
    }

    void SwapCamera()
    {
        transform.position = positions[nextPos];
        transform.eulerAngles = rotations[nextPos];

        nextPos = (nextPos + 1) % positions.Length;
    }
}
