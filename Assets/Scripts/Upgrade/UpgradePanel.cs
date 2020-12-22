using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private UpgradeBase upgrade;

	private void Awake()
	{
		icon.sprite = upgrade.Icon;
		description.text = upgrade.Description;
	}

	public void GetUpgrade()
	{
		upgrade.ApplyUpgrade();
	}
}
