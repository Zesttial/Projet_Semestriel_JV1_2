using UnityEngine;

[RequireComponent(typeof(HealthManager))]
public class HpModifier : MonoBehaviour
{
    protected HealthManager _healthManager;

    void Start()
    {
        _healthManager = GetComponent<HealthManager>();
        _healthManager.AddModifier(this);
    }

    public virtual void OnHpChanged(int amount)
    {

    }

    public virtual void OnDie()
    {

    }

}
