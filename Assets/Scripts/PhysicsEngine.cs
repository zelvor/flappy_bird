using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{
    [SerializeField] public float gravityScale = 1f;
    private Vector3 velocity;
    private float verticalVelocity;
    private float gravity = -9.81f;
    private void Start()
    {
        velocity = Vector3.zero;
        verticalVelocity = 0f;
    }

    private void Update()
    {
        GravityForce();
    }

    private void GravityForce(){
        verticalVelocity += gravity * gravityScale * Time.deltaTime;
        velocity = new Vector3(0, verticalVelocity, 0);
        transform.position += velocity * Time.deltaTime;
    }

    public void JumpForce(float jumpForce){
        verticalVelocity = jumpForce;
        velocity = new Vector3(0, verticalVelocity, 0);
        transform.position += velocity * Time.deltaTime;
    }
}
