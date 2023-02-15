using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : StateMachineBehaviour
{
    GameObject NPC;
    [SerializeField]
    GameObject Player;
    ZombieAI ZombieAI;
    private NavMeshAgent NavMeshAgent;
    private void Awake()
    {
        
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        NavMeshAgent = NPC.GetComponent<NavMeshAgent>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ZombieAI = NPC.GetComponent<ZombieAI>();
        ZombieAI.Fire();
        NPC.transform.rotation = Quaternion.Euler(-90, Mathf.Atan2(Player.transform.position.x - NPC.transform.position.x, Player.transform.position.z - NPC.transform.position.z) * Mathf.Rad2Deg, 0);
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
