using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player object
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        // Get the NavMeshAgent component attached to the NPC
        navMeshAgent = GetComponent<NavMeshAgent>();

        // If player reference is not set, try finding the player object by tag (you can set the player tag in Unity)
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
    }

    void Update()
    {
        // Check if the player reference is set
        if (player != null)
        {
            // Set the destination of the NPC to follow the player
            navMeshAgent.SetDestination(player.position);
        }
    }
}

