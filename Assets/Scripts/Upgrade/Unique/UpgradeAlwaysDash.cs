using UnityEngine;

[CreateAssetMenu(fileName = "Always Dash", menuName = "Upgrade/Always Dash")]
public class UpgradeAlwaysDash : UpgradeBase
{
	[SerializeField] private float scorePerSecImprovement;

	public override void ApplyUpgrade()
	{
		PlayerMovement.AlwaysDash = true;
		ScoreManager.Instance.ScorePerSecond += scorePerSecImprovement;
	}
}
