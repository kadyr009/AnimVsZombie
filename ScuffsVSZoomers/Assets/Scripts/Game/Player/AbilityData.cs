using UnityEngine;

public enum AbilityType
{
    Fireball,
    Heal,
    WallOfFlame
    // Добавь свои типы
}

// =========================
// ScriptableObject: AbilityData
// =========================

[CreateAssetMenu(fileName = "NewAbility", menuName = "Abilities/Ability")]
public class AbilityData : ScriptableObject
{
    public string abilityName;
    public AbilityType type;
    public float manaCost;
    public float cooldown;
    public GameObject effectPrefab;
    public AnimationClip animation;
}