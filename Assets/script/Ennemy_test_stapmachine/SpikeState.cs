using UnityEngine;

public class SpikeState : State
{
    public override void Enter()
    {
        Animator.Play("ExitSpikes");
        Animator.Play("EnterSpikes");
    }

    public override void Do()
    {
        float time = transform.position.y;

        if(Spikes1 is Exit)
        {
            Enter Spikes1 and Exit Spikes2
        }
    }

    public override void Exit() 
    { 
        if (HPBoss <= 66%)
            go FireState;
    }
}
