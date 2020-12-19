using UnityEngine;

public class RotateAroundPlayer : StateMachineBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float orbitDistance;
    [SerializeField] private float orbitRotateSpeed;

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
        Vector3 angle = LerpByDistance(player.position, transform.position, orbitDistance);
        Vector3 target = RotatePointAroundPivot(angle, player.position);
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        stateTimeLeft -= Time.deltaTime;
        if (stateTimeLeft <= 0f) {
            animator.Play("MoveTowardsPlayer");
		}
    }

    private static Vector3 LerpByDistance(Vector3 from, Vector3 to, float dist)
    {
        return dist * (to - from).normalized + from;
    }

    private Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot)
    {
        return Quaternion.Euler(0f, 0f, orbitRotateSpeed) * (point - pivot) + pivot;
    }
}
