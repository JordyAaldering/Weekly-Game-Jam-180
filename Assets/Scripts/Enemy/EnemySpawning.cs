using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] private float spawnDistance;
	[SerializeField] private float spawnTimeMin;
	[SerializeField] private float spawnTimeMax;

	[SerializeField] private EnemyCombat enemyPrefab;

	private float spawnTimeLeft;

	private void Awake()
	{
		spawnTimeLeft = 3f;
	}

	private void Update()
	{
		if (spawnTimeLeft <= 0f) {
			spawnTimeLeft = Random.Range(spawnTimeMin, spawnTimeMax);

			float x = Random.Range(0f, 2f * spawnDistance);
			float y = Mathf.Sin(spawnDistance * 10f / Mathf.PI * x);
			Vector3 pos = new Vector3(x - spawnDistance, y * spawnDistance);

			Instantiate(enemyPrefab, pos, Quaternion.identity, transform);
		} else {
			spawnTimeLeft -= Time.deltaTime;
		}
	}
}
