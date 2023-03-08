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

    private void FixedUpdate()
    {
        GravityForce();
        if (verticalVelocity > 0){
            ChangeRotationUp();
        } else if (verticalVelocity < 0){
            ChangeRotationDown();
        }
    }

    private void GravityForce(){
        verticalVelocity += gravity * gravityScale * Time.deltaTime;
        velocity = new Vector3(0, verticalVelocity, 0);
        transform.position += velocity * Time.deltaTime;
    }

    public void ResetVelocity(){
        verticalVelocity = 0f;
    }

    public void JumpForce(float jumpForce){
        verticalVelocity = jumpForce;
        velocity = new Vector3(0, verticalVelocity, 0);
        transform.position += velocity * Time.deltaTime;
    }

    private void ChangeRotationUp(){
        transform.rotation = Quaternion.Euler(0, 0, 30);
    }

    private void ChangeRotationDown(){
        // transform.rotation = Quaternion.Euler(0, 0, -60);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -60), 0.05f);
    }

}
