using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public NavMeshAgent agent;

    public Vector3[] positions;

    public int nextPos = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //agent.SetDestination(positions[0]);

        PatrolToPoint();
    }

    // Update is called once per frame
    async void Update()
    {
        if (agent.remainingDistance < 0.5f) 
        {
            await Task.Delay(1000);
            PatrolToPoint();
        }
            
    }


    void PatrolToPoint()
    {
        agent.SetDestination(positions[nextPos]);

        nextPos = (nextPos + 1) % positions.Length;
    }
}
