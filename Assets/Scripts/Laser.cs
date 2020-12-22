using UnityEngine;

public class Laser : MonoBehaviour
{
	[SerializeField] private float moveSpeed;
	[SerializeField] private float lifeTime;

	public static float PlayerSpeedModifier { get; set; } = 1f;
	public static float EnemySpeedModifier { get; set; } = 1f;

	public GameObject Parent { get; set; }
	public bool ParentIsPlayer { get; set; }

	private void Update()
	{
		float speed = moveSpeed * (ParentIsPlayer ? PlayerSpeedModifier : EnemySpeedModifier);
		transform.position += speed * Time.deltaTime * transform.right;

		lifeTime -= Time.deltaTime;
		if (lifeTime < 0f) {
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject != Parent) {
			if (collision.TryGetComponent<PlayerCombat>(out var pCombat)) {
				pCombat.Die();
			} else if (collision.TryGetComponent<EnemyCombat>(out var eCombat)) {
				eCombat.Die();
			}

			// destroy the laser on any collision
			Destroy(gameObject);
		}
	}
}
