using UnityEngine;

public class FireState : State
{
    public override void Enter()
    {
        Animator.Play("FireState");
        
    }

    public override void Do()
    {
       random BoxSpawn
            wait for seconde
            start fireAttack
            Time.deltaTime
            Stop fire attack
            restart Do()
    }

    public override void Exit()
    {
        if (HPBoss <= 33 %)
            go GazState;
    }
}
