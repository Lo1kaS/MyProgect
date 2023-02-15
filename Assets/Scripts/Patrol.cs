using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : StateMachineBehaviour
{
    GameObject NPC;
    GameObject[] waypoints;
    int currentWP;
    private NavMeshAgent NavMeshAgent;
    
    private void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoints");
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        currentWP = 0;
        NavMeshAgent = NPC.GetComponentInParent<NavMeshAgent>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(waypoints.Length == 0) return;
        if (Vector3.Distance(waypoints[currentWP].transform.position, NPC.transform.position) < 3f)
        {
            currentWP++; ;
            if (waypoints.Length <= currentWP) {
                currentWP = 0;
                    }
            
        }
        
        NPC.transform.rotation = Quaternion.Euler(-90, Mathf.Atan2(waypoints[currentWP].transform.position.x - NPC.transform.position.x, waypoints[currentWP].transform.position.z - NPC.transform.position.z) * Mathf.Rad2Deg ,0);
        NavMeshAgent.SetDestination(waypoints[currentWP].transform.position);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
