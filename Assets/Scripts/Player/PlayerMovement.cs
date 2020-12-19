using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
	[SerializeField] private float dashSpeed;
	[SerializeField] private float dashTime;

	private Vector2 moveDir = Vector2.zero;
	private bool isDashing = false;

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

		// clamp diagonal movement speed
		moveDir = Vector2.ClampMagnitude(moveDir, 1f);

		if (!isDashing && Input.GetButtonDown("Dash")) {
			StartCoroutine(Dash(moveDir));
		}
	}

	private void FixedUpdate()
	{
		if (!isDashing) {
			rb.velocity = moveSpeed * moveDir;
		}
	}

	private IEnumerator Dash(Vector2 dashDir)
	{
		isDashing = true;

		for (float t = 0; t < dashTime; t += Time.deltaTime) {
			rb.velocity = dashSpeed * dashDir;
			yield return null;
		}

		isDashing = false;
	}
}
