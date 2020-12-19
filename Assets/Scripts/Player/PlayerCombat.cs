using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
	[SerializeField] private float fireCooldown;
	[SerializeField] private Laser laserPrefab;

	private float fireCooldownLeft;

	private void Update()
	{
		if (Input.GetButtonDown("Fire1") && fireCooldownLeft <= 0f) {
			fireCooldownLeft = fireCooldown;

			Laser laser = Instantiate(laserPrefab, transform.position, transform.rotation);
		}

		if (fireCooldownLeft > 0f) {
			fireCooldownLeft -= Time.deltaTime;
		}
	}
}
