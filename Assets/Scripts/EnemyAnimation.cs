using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    private void Awake()
    {
        // Get references to Animator and NavMeshAgent components
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Calculate the speed of the enemy based on its velocity
        float speed = agent.velocity.magnitude;

        // Set the MotionSpeed parameter in the Animator
        animator.SetFloat("MotionSpeed", speed);
    }
}
