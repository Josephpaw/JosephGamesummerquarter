using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    } 

    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            Debug.Log($"{gameObject.name} hit {collision.gameObject.name}!");
        }
    }
}

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform target;
    public Text loseText;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (loseText != null)
        {
            loseText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER LOST");

            if (loseText != null)
            {
                loseText.gameObject.SetActive(true);
                loseText.text = "LOSE";
            }

            agent.isStopped = true;
        }
    }
}