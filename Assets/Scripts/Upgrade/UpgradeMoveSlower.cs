using UnityEngine;

[CreateAssetMenu(fileName = "Move Slower", menuName = "Upgrade/Move Slower")]
public class UpgradeMoveSlower : UpgradeBase
{
	[SerializeField] private float scoreIncrease;
	[SerializeField] private float moveSpeedModifier;

	public override void ApplyUpgrade()
	{
		PlayerMovement.MoveSpeedModifier = moveSpeedModifier;
		ScoreManager.Instance.Score += scoreIncrease;
	}
}
