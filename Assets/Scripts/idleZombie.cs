using UnityEngine;

public class idleZombie : StateMachineBehaviour
{

    Transform target; // player
    Transform borderCheck;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        borderCheck = animator.GetComponent<Zombie>().borderCheck;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Physics2D.Raycast(borderCheck.position, Vector2.right, 2) && Physics2D.Raycast(borderCheck.position, Vector2.right, 2).collider.CompareTag("Player") == false || Physics2D.Raycast(borderCheck.position, Vector2.down, 1) == false)
        {
            return;
        }
        float distance = Vector2.Distance(target.position,animator.transform.position);

        if(distance < 7)
        {
            animator.SetBool("isChasing",true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AudioManager.instance.Play("ZombieScream");

    }

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
