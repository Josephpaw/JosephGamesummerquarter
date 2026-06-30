using UnityEngine;
using UnityEngine.AI;
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
