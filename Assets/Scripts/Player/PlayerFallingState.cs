using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerBaseState
{
    public PlayerFallingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.InputReader.LandingEvent += OnLanding;
        stateMachine.imFalling = true;
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.IsFlat())
        {
            stateMachine.InputReader.OnLanding();
        }
    }

    public override void Exit()
    {
        stateMachine.Animator.SetBool("IsFalling", false);
        stateMachine.InputReader.LandingEvent -= OnLanding;
    }
    private void OnLanding()
    {
        stateMachine.SwitchState(new PlayerTestState(stateMachine));
        Debug.Log("im landin");
    }
}
