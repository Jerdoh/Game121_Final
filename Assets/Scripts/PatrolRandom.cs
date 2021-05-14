using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class PatrolRandom : MonoBehaviour {

    public GameObject player;
    private Transform playerPosition;
    private int playerHealth;
    private int rangeToAttack = 10;

    public Transform[] points;
    private int destPoint = 0;
    private int prevDestPoint = 0;
    private NavMeshAgent agent;


    void Start () {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint() {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;
        
        // Set the agent to go to the currently selected destination.       
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        int nextDest = PickRandomDest(0, points.Length);
        while(nextDest == destPoint || nextDest == prevDestPoint) {
            nextDest = PickRandomDest(0, points.Length);
        }
        prevDestPoint = destPoint;
        destPoint = (nextDest) % points.Length;
    }

    int PickRandomDest(int min, int max) {
        int dest = Random.Range(min, max);
        return dest;
    }

    void Update () {
        playerHealth = player.GetComponent<Player>().health;
        playerPosition = player.transform;
        
        if((Vector3.Distance(playerPosition.position, transform.position) < rangeToAttack) && playerHealth > 0) {
            player.GetComponent<Player>().TakeDamage(1);
        } else {
            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
        }
    }
}