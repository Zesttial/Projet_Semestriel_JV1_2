using UnityEngine;

[RequireComponent(typeof(HealthManager))]
public class HpModifier : MonoBehaviour
{
    protected HealthManager healthManager;
    public int hp;

    void Start()
    {
        healthManager = GetComponent<HealthManager>();
        healthManager.AddModifier(this);
    }

    public virtual void OnHpChanged(int amount)
    {

    }

    public virtual void OnDie()
    {
        Debug.Log("mort");
        healthManager.MaxHp();
    }

}
