using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter()
    {
        stateMachine.InputReader.FallingEvent += OnFalling;
        stateMachine.imFalling = false;
    }

    public override void Tick(float deltaTime)
    {
        Vector2 movement = new Vector2();
        movement.x = stateMachine.InputReader.MovementValue.x;
        movement.y = 0;
        stateMachine.transform.Translate(movement * stateMachine.MovementSpeed * deltaTime);
        if (movement.x != 0)
        {
            stateMachine.Animator.SetFloat("Speed", 1);
        }
        else
        {
            stateMachine.Animator.SetFloat("Speed", 0);
        }

        if(!stateMachine.IsFlat())
        {
            stateMachine.transform.Translate(1,0,0);
            stateMachine.InputReader.OnFalling();
        }
    }

    public override void Exit()
    {
        stateMachine.Animator.SetBool("IsFalling", true);
        stateMachine.InputReader.FallingEvent -= OnFalling;
    }

    private void OnFalling()
    {
        stateMachine.SwitchState(new PlayerFallingState(stateMachine));
        Debug.Log("im falin");

    }

    
    
}
