using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	[SerializeField] private float initialPointsPerSecond;
	[SerializeField] private TextMeshProUGUI scoreText;

    public static ScoreManager Instance { get; private set; }

    public float Score { get; set; }
	public float PointsPerSecond { get; set; }

	private void Awake()
	{
		Instance = this;

		PointsPerSecond = initialPointsPerSecond;
	}

	private void Update()
	{
		if (PlayerCombat.IsDead) {
			return;
		}

		Score += PointsPerSecond * Time.deltaTime;
		scoreText.text = Mathf.FloorToInt(Score).ToString();
	}
}
