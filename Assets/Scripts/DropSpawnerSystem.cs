using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawnerSystem : MonoBehaviour
{
    public float correctedDifficulty = 0.0f;
    public float minSpawnPoint = -5.5f;
    public float maxSpawnPoint = 5.5f;
    public float heightSpawnArea = 5.0f;

    [Range(0f, 2f)]
    public float spawnFactor = 1f; //Multiplier factor for spawning new spawners by dificulty
    public GameObject dropSpawner;

    private int lastRoundDifficulty = 0;

    //private GameObject[] spawnerList;
    void Start()
    {
        SpawnSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DifficultyChanged(float d)
    {
        Debug.Log("Difficulty changed to " + d);
        correctedDifficulty = d * spawnFactor;

        if (Mathf.RoundToInt(correctedDifficulty) != lastRoundDifficulty)
        {
            SpawnSpawner();
            lastRoundDifficulty = Mathf.RoundToInt(correctedDifficulty);
        }

    }

    void SpawnSpawner()
    {
        float xPos = Random.Range(minSpawnPoint, maxSpawnPoint);
        float yPos = Random.Range(transform.position.y, transform.position.y + heightSpawnArea);
        Vector3 newSpawnerPosition = new Vector3(xPos, yPos, 0);
        Instantiate(dropSpawner, newSpawnerPosition, Quaternion.identity, transform);
    }
}
