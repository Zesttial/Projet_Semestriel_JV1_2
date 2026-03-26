using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private int hp;
    [SerializeField]
    private int hpMax;
    [SerializeField]
    private List<DammageType> immunities;

    private List<HpModifier> hpModifiers;
    

    public int MaxHp()
    {
        return hpMax;
    }

    public void AddModifier(HpModifier modifier)
    {
        if (hpModifiers == null)
        {
            hpModifiers = new List<HpModifier>();
        }

        hpModifiers.Add(modifier);
    }

    public void ChangeHP(int newAmount)
    {
        hp = newAmount;

        foreach (HpModifier modifier in hpModifiers)
        {
            modifier.OnHpChanged(newAmount);
        }

        if (hp <= 0)
        {
            Die();
        }
    }

    public void AddHp(int amount)
    {
        ChangeHP(hp + amount);
    }

    public int GetHP()
    {
        return hp;
    }

    public void Dammage(int amount, DammageType type)
    {
        if (immunities.Contains(type))
        {
            return;
        }
        else
        {
            AddHp(-amount);
        }
    }

    public void Die()
    {
        foreach (HpModifier modifier in hpModifiers)
        {
            modifier.OnDie();
        }

    }

    void Start()
    {
        if (hpModifiers == null)
        {
            hpModifiers = new List<HpModifier>();
        }
        ChangeHP(hpMax);


    }

}