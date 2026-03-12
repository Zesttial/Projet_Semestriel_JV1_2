using UnityEngine;

public class DestroyedOnDeath : HpModifier
{
    public override void OnDie()
    {
        Destroy(gameObject);
    }
}
