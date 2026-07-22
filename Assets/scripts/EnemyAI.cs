using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float viewDistance = 10f;
    public float viewAngle = 90f;
    public LayerMask obstacleMask;

    private NavMeshAgent agent;
    private Transform player;
    private Vector3 originalPosition;
    private bool isChasing = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        originalPosition = transform.position;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            Debug.Log("Player found: " + player.name);
        }
        else
        {
            Debug.LogError("ERROR: No object with tag 'Player' found in scene!");
        }
    }

    private void Update()
    {
        if (player == null) return;

        if (CanSeePlayer())
        {
            if (!isChasing)
            {
                Debug.Log("Player detected! Starting chase.");
                isChasing = true;
            }
            agent.SetDestination(player.position);
        }
        else
        {
            if (isChasing)
            {
                Debug.Log("Lost player sight. Returning home.");
                isChasing = false;
                agent.SetDestination(originalPosition);
            }
        }
    }

    private bool CanSeePlayer()
    {
        Vector3 eyePos = transform.position + Vector3.up * 0.5f;
        Vector3 dirToPlayer = (player.position - transform.position);
        float distanceToPlayer = dirToPlayer.magnitude;
        Debug.DrawRay(eyePos, transform.forward * viewDistance, Color.yellow);

        if (distanceToPlayer <= viewDistance)
        {
            float angle = Vector3.Angle(transform.forward, dirToPlayer.normalized);

            if (angle <= viewAngle / 2f)
            {
                if (!Physics.Raycast(eyePos, dirToPlayer.normalized, distanceToPlayer, obstacleMask))
                {
                    Debug.DrawLine(eyePos, player.position, Color.green);
                    return true;
                }
                else
                {
                    Debug.DrawLine(eyePos, player.position, Color.red);
                }
            }
        }

        return false;
    }
}
