using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private int hp;
    [SerializeField]
    private int hpMax;
    public Transform checkPoint;
    [SerializeField]
    private List<DammageType> immunities;

    private List<HpModifier> hpModifiers;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeHP(hpMax);

    }

}