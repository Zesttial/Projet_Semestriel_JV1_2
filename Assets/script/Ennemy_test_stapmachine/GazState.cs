using UnityEngine;

public class GazState : State
{
    public override void Enter()
    {
        Animator.Play("GazState");

    }

    public override void Do()
    {
        start gazZone
    }

    public override void Exit()
    {
        if (HPBoss <= 0 %)
            Die
    }
}
