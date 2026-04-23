using System.Collections;
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


    void SwapCamera()
    {
        //transform.position = positions[nextPos];
        //transform.eulerAngles = rotations[nextPos];

        transform.position = Vector3.Lerp(transform.position, positions[nextPos], 0.5f * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotations[nextPos]), 0.5f * Time.deltaTime);

        nextPos = (nextPos + 1) % positions.Length;
    }

    public float transitionTime = 1f;
    bool isMoving = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            StartCoroutine(MoveCamera());
        }
    }

    IEnumerator MoveCamera()
    {
        isMoving = true;

        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;

        Vector3 targetPos = positions[nextPos];
        Quaternion targetRot = Quaternion.Euler(rotations[nextPos]);

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / transitionTime;

            transform.position = Vector3.Lerp(startPos, targetPos, t);
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);

            yield return null;
        }

        nextPos = (nextPos + 1) % positions.Length;
        isMoving = false;
    }
}
