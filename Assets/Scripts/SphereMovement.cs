using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    [SerializeField] float followSpeed = 2f;
    [SerializeField] Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 Positioning = new Vector3(target.position.x - 5, target.position.y + 5, 0);
        transform.position = Vector3.Slerp(transform.position, Positioning, followSpeed * Time.deltaTime);
        if(target.GetComponent<StateMachine>().imFalling)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}
