using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
	[SerializeField] private List<UpgradeBase> uniqueUpgrades;
    [SerializeField] private List<UpgradeBase> repeatableUpgrades;

	[Header("UI")]
	[SerializeField] private GameObject upgradeGroup;
    [SerializeField] private UpgradePanel[] upgradePanels;

	private void Awake()
	{
		upgradeGroup.SetActive(false);
	}

	public void ShowUpgrades()
	{
		upgradeGroup.SetActive(true);

		if (uniqueUpgrades.Count > 0) {
			// always give one unique upgrade
			SetUniqueUpgrade();
			SetRemainingUpgrades(1);
		} else {
			// No unique upgrades remain
			SetRemainingUpgrades(0);
		}
	}

	private void SetUniqueUpgrade()
	{
		int index = Random.Range(0, uniqueUpgrades.Count);
		UpgradeBase upgrade = uniqueUpgrades[index];
		uniqueUpgrades.RemoveAt(index);
		upgradePanels[0].SetUpgrade(upgrade);
	}

	private void SetRemainingUpgrades(int startIndex)
	{
		var upgrades = repeatableUpgrades
			.OrderBy(x => Random.Range(0f, 1f))
			.Take(upgradePanels.Length - startIndex);

		foreach (var upgrade in upgrades) {
			upgradePanels[startIndex].SetUpgrade(upgrade);
			startIndex++;
		}
	}
}
