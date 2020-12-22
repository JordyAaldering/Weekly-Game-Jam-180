﻿using UnityEngine;

[CreateAssetMenu(fileName = "Invert Controls", menuName = "Upgrade/Invert Controls")]
public class UpgradeInvertControls: UpgradeBase
{
	[SerializeField] private float scorePerSecImprovement;

	public override void ApplyUpgrade()
	{
		PlayerMovement.InvertControls = true;
		ScoreManager.Instance.ScorePerSecond += scorePerSecImprovement;
	}
}
