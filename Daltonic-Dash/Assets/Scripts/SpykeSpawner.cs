using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpykeSpawner : MonoBehaviour
{
    private float minTimeSpawn = 3f;
    private float maxTimeSpawn = 5f;
    public GameObject spykePrefab;
    public GameObject spykeSpawnPoint;
    void Start()
    {
        
    }
    void Update()
    {
        ConstantMoveBackWards();
    }

    public IEnumerator RandomSpawn()
    {
        Vector2 spawnPoint = new Vector2(spykeSpawnPoint.transform.position.x, spykeSpawnPoint.transform.position.y);
        yield return new WaitForSeconds(Random.Range(minTimeSpawn, maxTimeSpawn));
        Instantiate(spykePrefab, spawnPoint, Quaternion.identity);
        Debug.Log("Spyke Spawned");
    }
    public void ConstantMoveBackWards()
    {
        StartCoroutine(RandomSpawn());
    }
}
