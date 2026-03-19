using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    [SerializeField] FieldOfView fov;

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
     void Update()
    { 
        
        if (agent.remainingDistance < 0.5f)
        {
            //await Task.Delay(1000);
            PatrolToPoint();
        }

        if (fov.IsTargetVisible(GameObject.FindGameObjectWithTag("Player").transform))
        {
            agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        }
        //else PatrolToPoint();

       

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player caught!");
            
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }


    void PatrolToPoint()
    {
        agent.SetDestination(positions[nextPos]);

        nextPos = (nextPos + 1) % positions.Length;
    }
}
