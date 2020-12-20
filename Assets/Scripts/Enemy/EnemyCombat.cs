using System.Collections;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
	[SerializeField] private float fireCooldown;
	[SerializeField] private Laser laserPrefab;

	private void Awake()
	{
		StartCoroutine(ShootRoutine());
	}

	private IEnumerator ShootRoutine()
	{
		var wait = new WaitForSeconds(1f);

		while (true) {
			Laser laser = Instantiate(laserPrefab, transform.position, transform.rotation);
			laser.Parent = gameObject;

			yield return wait;
		}
	}

	public void Die()
	{
		Destroy(gameObject);
	}
}
