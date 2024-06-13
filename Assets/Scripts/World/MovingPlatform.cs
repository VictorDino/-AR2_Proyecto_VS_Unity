using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 pointA; 
    public Vector3 pointB; 
    public float speed = 1.0f; 

    private Vector3 targetA;
    private Vector3 targetB;
    private Vector3 lastPosition;

    void Start()
    {
        targetA = transform.position + pointA;
        targetB = transform.position + pointB;
        lastPosition = transform.position;
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1.0f);
        transform.position = Vector3.Lerp(targetA, targetB, t);
    }

    public Vector3 GetPlatformMovement()
    {
        Vector3 movement = transform.position - lastPosition;
        lastPosition = transform.position;
        return movement;
    }
}
