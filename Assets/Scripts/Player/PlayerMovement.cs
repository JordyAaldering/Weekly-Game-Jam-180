﻿using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
	[SerializeField] private float dashSpeed;
	[SerializeField] private float dashTime;

	[Header("GFX")]
	[SerializeField] private SpriteRenderer shipSprite;
	[SerializeField] private GameObject shieldSprite;
	[SerializeField] private Color shipDashColor;

	public static bool CanDash { get; set; } = true;
	public static bool IsDashing { get; private set; }

	private Vector2 moveDir;
    private Rigidbody2D rb;

	private void Awake()
	{
		shieldSprite.SetActive(false);

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

		if (CanDash && !IsDashing && Input.GetButtonDown("Dash")) {
			StartCoroutine(Dash(moveDir));
		}
	}

	private void FixedUpdate()
	{
		if (!IsDashing) {
			rb.velocity = moveSpeed * moveDir;
		}
	}

	private IEnumerator Dash(Vector2 dashDir)
	{
		IsDashing = true;

		Color oldColor = shipSprite.color;
		shipSprite.color = shipDashColor;
		shieldSprite.SetActive(true);

		for (float t = 0; t < dashTime; t += Time.deltaTime) {
			rb.velocity = dashSpeed * dashDir;
			yield return null;
		}

		shipSprite.color = oldColor;
		shieldSprite.SetActive(false);

		IsDashing = false;
	}
}
