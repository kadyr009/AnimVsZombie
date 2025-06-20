using System.Collections.Generic;
using UnityEngine;

public class AbilitySystem : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Mana _mana;
    [SerializeField] private List<AbilityData> _abilities;
    [SerializeField] private Transform _spawnPoint; // Куда будет спавниться эффект

    private AbilityData _currentAbility;
    private bool _isCasting;
    private Dictionary<AbilityData, float> _cooldowns = new();

    private void Update()
    {
        UpdateCooldowns();
    }

    public void CastAbility(int index)
    {
        if (_isCasting || index >= _abilities.Count) return;

        AbilityData ability = _abilities[index];

        if (_cooldowns.ContainsKey(ability) && _cooldowns[ability] > 0f)
            return;

        if (_mana.UseMana(ability.manaCost))
        {
            _currentAbility = ability;
            _isCasting = true;
            _animator.Play(ability.animation.name);
        }
    }

    // Этот метод вызывается ИЗ АНИМАЦИОННОГО СОБЫТИЯ (Animation Event)
    public void ActivateEffect()
    {
        if (_currentAbility == null) return;

        GameObject effect = Instantiate(_currentAbility.effectPrefab, _spawnPoint.position, _spawnPoint.rotation);

        AbilityBehaviour behaviour = effect.GetComponent<AbilityBehaviour>();
        if (behaviour != null)
        {
            if (behaviour is FireballAbility fireball)
            {
                // Пример: задать направление для фаербола
                fireball.SetDirection(transform.forward); // Или по направлению камеры
            }

            behaviour.Activate(gameObject); // Передаём ссылку на игрока/кастера
        }

        _cooldowns[_currentAbility] = _currentAbility.cooldown;
        _isCasting = false;
        _currentAbility = null;
    }

    private void UpdateCooldowns()
    {
        List<AbilityData> keys = new(_cooldowns.Keys);
        foreach (var ability in keys)
        {
            _cooldowns[ability] -= Time.deltaTime;
            if (_cooldowns[ability] <= 0f)
                _cooldowns.Remove(ability);
        }
    }
}