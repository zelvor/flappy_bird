using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckCollision : MonoBehaviour
{
    private GameObject player;

    private float radiusOfPlayer = 0.4f;

    private GameObject pipes;

    public bool isGameOver = false;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (!isGameOver)
        CheckCrash();
    }

    private GameObject FindNearestPipe()
    {
        // Find nearest pipe in front of player
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipes");
        float nearestDistance = 100f;
        GameObject nearestPipe = null;
        foreach (GameObject pipe in pipes)
        {
            float distance = pipe.transform.position.x - player.transform.position.x;
            if (distance > -1 && distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestPipe = pipe;  
            }
        }
        if (nearestPipe != null)
        {
            this.pipes = nearestPipe;
            //Get "Top" and "Bottom" of the pipe
            GameObject topPipe = nearestPipe.transform.GetChild(0).gameObject;
            GameObject bottomPipe = nearestPipe.transform.GetChild(1).gameObject;

            // //Mark with red for debug
            // topPipe.GetComponent<SpriteRenderer>().color = Color.red;
            // bottomPipe.GetComponent<SpriteRenderer>().color = Color.red;
        }
        return nearestPipe;
    }

    private void CheckCrash()
    {
        if (player.transform.position.y <= -3.1f){
            isGameOver = true;
            FindObjectOfType<GameManager>().GameOver();
        }
        else{
        GameObject nearestPipe = FindNearestPipe();
        //Check if the player is in the gap
        if (nearestPipe != null)
        {
            //Get "Top" and "Bottom" of the pipe
            GameObject topPipe = nearestPipe.transform.GetChild(0).gameObject;
            GameObject bottomPipe =
                nearestPipe.transform.GetChild(1).gameObject;

            isGameOver =
                (
                IsCollision(player, radiusOfPlayer, topPipe, 1.1f, 6.7f) ||
                IsCollision(player, radiusOfPlayer, bottomPipe, 1.1f, 6.7f)
                );
            
            if (isGameOver)
            {
                FindObjectOfType<GameManager>().GameOver();
            }
        }
            
        }
    }

    private bool
    IsCollision(
        GameObject player,
        float radiusOfPlayer,
        GameObject pipe,
        float width,
        float height
    )
    {
        //Get the position of the player
        Vector3 playerPosition = player.transform.position;

        //Get the position of the pipe
        Vector3 pipePosition = pipe.transform.position;

        //Get the distance between the player and the pipe
        float distanceX = Mathf.Abs(playerPosition.x - pipePosition.x);
        float distanceY = Mathf.Abs(playerPosition.y - pipePosition.y);

        //Check if the player is in the gap
        if (distanceX > (width + radiusOfPlayer) / 2)
        {
            return false;
        }
        if (distanceY > (height + radiusOfPlayer) / 2)
        {
            return false;
        }

        if (distanceX <= (width / 2))
        {
            return true;
        }
        if (distanceY <= (height / 2))
        {
            return true;
        }

        float cornerDistance_sq =
            Mathf.Pow(distanceX - width / 2, 2) +
            Mathf.Pow(distanceY - height / 2, 2);

        return (cornerDistance_sq <= Mathf.Pow(radiusOfPlayer, 2));
    }
}
