using UnityEngine;

public class CheckPoint : Interactable
{
    public override void Interaction()
    {
        base.Interaction();
        var healthManager =player.GetComponent <HealthManager>();
        healthManager.checkPoint = transform;
    }
}
