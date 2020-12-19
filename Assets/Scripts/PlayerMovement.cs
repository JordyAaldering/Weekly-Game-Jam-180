using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

	private Vector2 moveDir;
    private Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		moveDir = new Vector2(
			Input.GetAxis("Horizontal"),
			Input.GetAxis("Vertical")
		);
	}

	private void FixedUpdate()
	{
		moveDir = Vector2.ClampMagnitude(moveDir, 1f);
		rb.velocity = moveSpeed * moveDir;
	}
}
