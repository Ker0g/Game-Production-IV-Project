using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray movePos = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log(movePos/*Input.mousePosition*/);
            if(Physics.Raycast(movePos, out var hitInfo))
            {
                agent.SetDestination(hitInfo.point);
            }
        } 
    }
}
