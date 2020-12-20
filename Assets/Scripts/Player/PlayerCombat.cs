using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerCombat : MonoBehaviour
{
	[SerializeField] private float fireCooldown;
	[SerializeField] private Laser laserPrefab;

	private float fireCooldownLeft;

	private PlayerMovement pm;

	private void Awake()
	{
		pm = GetComponent<PlayerMovement>();
	}

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

	public void Die()
	{
		if (pm.IsDashing) {
			return;
		}

		Destroy(gameObject);
	}
}
