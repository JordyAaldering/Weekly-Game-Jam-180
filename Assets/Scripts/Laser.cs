using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float lifeTime;

	private void Update()
	{
		transform.position += moveSpeed * Time.deltaTime * transform.right;

		lifeTime -= Time.deltaTime;
		if (lifeTime < 0f) {
			Destroy(gameObject);
		}
	}
}
