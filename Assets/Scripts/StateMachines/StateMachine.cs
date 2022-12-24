using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    [field: SerializeField] public Transform CheckPoint{ get; private set; }
    [field: SerializeField] public float CheckPointRaius{ get; private set; }

    public bool imFalling;
    private State currentState;

    void FixedUpdate()
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
        RaycastHit2D hit = Physics2D.CircleCast(CheckPoint.position, CheckPointRaius, Vector2.down,0);
        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        if (CheckPoint == null)
        {
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(CheckPoint.position, CheckPointRaius);
    }
}
