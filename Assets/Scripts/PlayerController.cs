using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        PhysicsEngine physicsEngine = GetComponent<PhysicsEngine>();
    }

    void Update()
    {
        //Press mouse, and the player will jump
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }
    
    private void Jump()
    {
        PhysicsEngine physicsEngine = GetComponent<PhysicsEngine>();
        physicsEngine.JumpForce(10f);
    }
}
