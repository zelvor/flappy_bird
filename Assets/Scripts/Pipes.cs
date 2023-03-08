using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge;

    private void Start(){
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x * 1.5f;
    }

    private void FixedUpdate(){
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge){
            Destroy(gameObject);
        }
    }


}
