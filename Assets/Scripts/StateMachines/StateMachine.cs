using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public bool imFalling;
    private State currentState;

    void Update()
    {
        currentState?.Tick(Time.deltaTime);
    }

    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
    public bool IsFlat()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (Vector2.Reflect(Vector2.down, hit.normal) == Vector2.up)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
