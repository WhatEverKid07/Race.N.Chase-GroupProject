using UnityEngine;
using UnityEngine.AI;

public class PoliceCarAI : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed;
    public float turnSpeed;

    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        agent.speed = moveSpeed;
        agent.angularSpeed = turnSpeed;

        // Check if agent is on NavMesh
        if (!agent.isOnNavMesh)
        {
            Debug.LogWarning("NavMeshAgent is not on a valid NavMesh.");
            enabled = false; // Disable the script if agent is not on NavMesh
            //return;
        }

        // Set initial destination
        SetNextWaypoint();
    }

    void Update()
    {
        SetNextWaypoint();
        /*
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            SetNextWaypoint();
        }*/
    }

    void SetNextWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        agent.SetDestination(waypoints[currentWaypointIndex].position);
    }
}
