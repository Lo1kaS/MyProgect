using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPSBase : StateMachineBehaviour
{
    [SerializeField]
    GameObject NPC;
    [SerializeField]
    GameObject Player;
   
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        
    }
}   
