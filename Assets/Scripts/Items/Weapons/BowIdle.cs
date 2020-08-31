using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BowIdle : StateMachineBehaviour
{
    public KeyCode Key;
    public GameObject Arrow;
    public Transform ArrowStart;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var childObjects = animator.gameObject.GetComponentsInChildren<Transform>();

        foreach (var item in childObjects)
        {
            if(item.name == "ArrowStartPoint")
            {
                ArrowStart = item;
            }
        }

        if (animator.gameObject.GetComponentsInChildren<Arrow>().Length == 0)
        {
            Instantiate(Arrow, ArrowStart);
        }
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Input.GetKeyDown(Key))
        {
            animator.SetBool("Draw", true);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
