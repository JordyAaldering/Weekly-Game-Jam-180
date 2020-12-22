using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	[SerializeField] private float initialPointsPerSecond;
	[SerializeField] private GameObject scorePanel;
	[SerializeField] private TextMeshProUGUI scoreText;

    public static ScoreManager Instance { get; private set; }

    public float Score { get; set; }
	public float PointsPerSecond { get; set; }

	private bool isPaused;

	private void Awake()
	{
		Instance = this;

		PointsPerSecond = initialPointsPerSecond;
	}

	public static void DisablePanel()
	{
		Instance.scorePanel.SetActive(false);
		Instance.isPaused = true;
	}

	private void Update()
	{
		if (PlayerCombat.IsDead || isPaused) {
			return;
		}

		Score += PointsPerSecond * Time.deltaTime;
		scoreText.text = Mathf.FloorToInt(Score).ToString();
	}
}
