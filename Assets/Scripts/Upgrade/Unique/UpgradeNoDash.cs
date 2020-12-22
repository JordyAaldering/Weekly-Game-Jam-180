using UnityEngine;

[CreateAssetMenu(fileName="No Dash", menuName="Upgrade/No Dash")]
public class UpgradeNoDash : UpgradeBase
{
	[SerializeField] private float scorePerSecImprovement;

	public override void ApplyUpgrade()
	{
		PlayerMovement.CanDash = false;
		ScoreManager.Instance.ScorePerSecond += scorePerSecImprovement;
	}
}
