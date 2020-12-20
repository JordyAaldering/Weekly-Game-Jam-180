using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float lifeTime;

	public GameObject Parent { get; set; }

	private void Update()
	{
		transform.position += moveSpeed * Time.deltaTime * transform.right;

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
