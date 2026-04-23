using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;

    Animator animator;

    [SerializeField] InputActionAsset inputActions;
    private InputAction pressAction;

    private void Start()
    {
        animator = GetComponent<Animator>();
        pressAction = inputActions.FindAction("Interact");

        SoundManager.PlayMusic("specialagent");
    }

    // Update is called once per frame
    void Update()
    {   
        if (agent.hasPath)
            {
             animator.SetInteger("State", 1);
            }
            else             {
                animator.SetInteger("State", 0);
            }


        if (Input.GetMouseButtonDown(1))
        {
            

            Ray movePos = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log(movePos/*Input.mousePosition*/);
            if(Physics.Raycast(movePos, out var hitInfo))
            {
                SoundManager.PlaySound("playerbeep");
                agent.SetDestination(hitInfo.point);
            }
        } 

        if(pressAction.WasPressedThisFrame())
        {
           animator.SetTrigger("Interact");
        }
    }
}
