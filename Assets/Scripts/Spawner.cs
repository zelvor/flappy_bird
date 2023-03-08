using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    private float spawnRate = 1f;
    private float minHeight = 1.5f;
    private float maxHeight = 4f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        var position = transform.position;
        position.y = Random.Range(minHeight, maxHeight);
        Instantiate(prefab, position, Quaternion.identity);
        FindObjectOfType<GameManager>().IncreaseScore();
    }

}
