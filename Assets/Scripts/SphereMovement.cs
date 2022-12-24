using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    [field: SerializeField] public StateMachine StateMachineComponent { get; private set; }
    [field: SerializeField] public Material Material { get; private set; }
    [field: SerializeField] public float FollowSpeed { get; private set; }
    [field: SerializeField] public Transform Target { get; private set; }

    private Vector3 Positioning;

    void Update()
    {
        Positioning = new Vector3(Target.position.x - 5, Target.position.y + 5, 0);

        transform.position = Vector3.Slerp(transform.position, Positioning, FollowSpeed * Time.deltaTime);

        if(StateMachineComponent.imFalling)
        {
            Material.color = Color.red;
        }
        else
        {
            Material.color = Color.blue;
        }
    }
}
