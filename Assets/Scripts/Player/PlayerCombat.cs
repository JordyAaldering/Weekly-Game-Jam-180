using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerCombat : MonoBehaviour
{
	[SerializeField] private float fireCooldown;
	[SerializeField] private Laser laserPrefab;

	public static bool IsDead { get; private set; }

	private float fireCooldownLeft;

	private void Update()
	{
		if (Input.GetButtonDown("Fire1") && fireCooldownLeft <= 0f) {
			fireCooldownLeft = fireCooldown;

			Laser laser = Instantiate(laserPrefab, transform.position, transform.rotation);
			laser.Parent = gameObject;
		}

		if (fireCooldownLeft > 0f) {
			fireCooldownLeft -= Time.deltaTime;
		}
	}

	public void Die(bool force = false)
	{
		if (!force && PlayerMovement.IsDashing) {
			return;
		}

		IsDead = true;

		FindObjectOfType<GameOverCanvas>().EnablePanel();
		Destroy(gameObject);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Meteor")) {
			Die(true);
		}
	}
}
