using UnityEngine;

[CreateAssetMenu(fileName="New Upgrade", menuName="Upgrade/No Dash")]
public class UpgradeNoDash : UpgradeBase
{
	[SerializeField] private float scorePerSecImprovement;

	public override void ApplyUpgrade()
	{
		PlayerMovement.CanDash = false;
		ScoreManager.Instance.ScorePerSecond += scorePerSecImprovement;
	}
}
