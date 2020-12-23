using TMPro;
using UnityEngine;

public class UpgradeTimerPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeUntilUpgrade;

	private void Update()
	{
		timeUntilUpgrade.text = UpgradeManager.TimeUntilUpgrade.ToString("0.0");
	}
}
