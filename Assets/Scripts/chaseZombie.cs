using UnityEngine;

public class chaseZombie : StateMachineBehaviour
{

    Transform target; //player
    public float speedChasing = 3f;
    Transform borderCheck;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        borderCheck = animator.GetComponent<Zombie>().borderCheck;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.transform.position = Vector2.MoveTowards(animator.transform.position, new Vector2(target.position.x,animator.transform.position.y),speedChasing * Time.deltaTime);

        if (Physics2D.Raycast(borderCheck.position,Vector2.right,2) && Physics2D.Raycast(borderCheck.position, Vector2.right, 2).collider.CompareTag("Player") == false || Physics2D.Raycast(borderCheck.position, Vector2.down, 1) == false)
        {
            animator.SetBool("isChasing", false);
        }
        float distance = Vector2.Distance(target.position, animator.transform.position);

        if (distance < 1f)
        {
            animator.SetBool("isAttacking", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

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
