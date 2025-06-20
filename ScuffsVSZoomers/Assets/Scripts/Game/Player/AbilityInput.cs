using UnityEngine;

public class AbilityInput : MonoBehaviour
{
    private AbilitySystem _abilitySystem;

    private void Awake()
    {
        _abilitySystem = GetComponent<AbilitySystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _abilitySystem.CastAbility(0);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            _abilitySystem.CastAbility(1);
    }
}