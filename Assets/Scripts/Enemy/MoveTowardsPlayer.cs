using UnityEngine;

public class MoveTowardsPlayer : StateMachineBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float stoppingDistance;

    [Header("State Transition")]
    [SerializeField] private float minStateTime;
    [SerializeField] private float maxStateTime;
    private float stateTimeLeft;

    private Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateTimeLeft = Random.Range(minStateTime, maxStateTime);

        player = GameObject.FindWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform transform = animator.transform;
        Vector3 target = LerpByDistance(player.position, transform.position, stoppingDistance);
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        stateTimeLeft -= Time.deltaTime;
        if (stateTimeLeft <= 0f) {
            animator.Play("RotateAroundPlayer");
        }
    }

    private static Vector3 LerpByDistance(Vector3 from, Vector3 to, float dist)
    {
        return dist * (to - from).normalized + from;
    }
}
