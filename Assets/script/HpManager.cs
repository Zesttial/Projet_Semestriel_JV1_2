using UnityEngine;

public class HpManager : MonoBehaviour
{
    public int currentHP;
    public int maxHP;

    public void Start()
    {
        currentHP = maxHP;
    }

    public void RemoveHp(int pvPerdu)
    {
        currentHP -= pvPerdu;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
