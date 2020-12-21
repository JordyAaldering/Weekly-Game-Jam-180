using System.Collections;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
	[SerializeField] private float fireCooldown;
	[SerializeField] private float fireDistance;
	[SerializeField] private Laser laserPrefab;
	[SerializeField] private int pointsReward;

	private Transform player;

	private void Awake()
	{
		player = GameObject.FindWithTag("Player").transform;

		StartCoroutine(ShootRoutine());
	}

	private IEnumerator ShootRoutine()
	{
		var wait = new WaitForSeconds(1f);

		while (true) {
			if (Vector2.Distance(transform.position, player.position) < fireDistance) {
				Laser laser = Instantiate(laserPrefab, transform.position, transform.rotation);
				laser.Parent = gameObject;
			}

			yield return wait;
		}
	}

	public void Die()
	{
		ScoreManager.Instance.Score += pointsReward;

		Destroy(gameObject);
	}
}
