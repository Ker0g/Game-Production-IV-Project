using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    [SerializeField] FieldOfView fov;

    public NavMeshAgent agent;

    public Transform[] positions;
    public EnemyController[] enemies;

    bool yelled = false;

    Animator animator;

    public int nextPos = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemies = FindObjectsOfType<EnemyController>();

        animator = GetComponent<Animator>();
        //agent.SetDestination(positions[0]);
        animator.SetInteger("State", 1);
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
            if (!yelled)
            {
                Yell();
            }
            agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
            SoundManager.PlaySound("guard");
        }
        else
        {
            if (yelled)
            {
                yelled = false;
                PatrolToPoint();
            }
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
        agent.SetDestination(positions[nextPos].position);
        SoundManager.PlaySound("guard");
        nextPos = (nextPos + 1) % positions.Length;
    }

    void Yell()
    {
        if (!yelled)
        {
            Debug.Log("Enemy spotted the player!");
            SoundManager.PlaySound("hey");
            for (int i = 0; i < enemies.Length; i++)
            {

                if (enemies[i] != this)
                {
                    Vector3 dist = enemies[i].transform.position - transform.position;
                    if (dist.magnitude < 15f)
                        enemies[i].agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
                }
            }
            yelled = true;
        }
    }
}
