using UnityEngine;

public class Mana : MonoBehaviour
{
    public float MaxMana = 100f;
    public float CurrentMana = 100f;

    public bool UseMana(float amount)
    {
        if (CurrentMana >= amount)
        {
            CurrentMana -= amount;
            return true;
        }
        return false;
    }

    public void RestoreMana(float amount)
    {
        CurrentMana = Mathf.Min(CurrentMana + amount, MaxMana);
    }
}