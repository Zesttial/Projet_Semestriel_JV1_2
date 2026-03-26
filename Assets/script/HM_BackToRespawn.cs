using UnityEngine;

public class HM_BackToRespawn : HpModifier
{
    public RespawnPoint lastRespawn;
    public HealthManager myHpManager;
    public int hpMax;

    public override void OnDie()
    {
        transform.position = lastRespawn.transform.position;
        myHpManager.ChangeHP(hpMax);
    }
}
