using UnityEngine;

[CreateAssetMenu(fileName = "No Shoot", menuName = "Upgrade/No Shoot")]
public class UpgradeNoShoot : UpgradeBase
{
	[SerializeField] private float scorePerSecImprovement;

	public override void ApplyUpgrade()
	{
		PlayerCombat.CanShoot = false;
		ScoreManager.Instance.ScorePerSecond += scorePerSecImprovement;
	}
}
