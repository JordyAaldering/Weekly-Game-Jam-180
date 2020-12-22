using UnityEngine;

public abstract class UpgradeBase : ScriptableObject
{
    [SerializeField] private Sprite icon;
    [SerializeField, TextArea] private string description;

    public Sprite Icon => icon;
    public string Description => description;

    public abstract void ApplyUpgrade();
}
