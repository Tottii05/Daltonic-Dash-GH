using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpykeSpawner : MonoBehaviour
{
    private float minTimeSpawn = 1f;
    private float maxTimeSpawn = 3f;
    public GameObject spykePrefab;
    public GameObject spykeSpawnPoint;
    public Stack<GameObject> spykeStack;
    void Start()
    {
        Vector2 spawnPoint = new Vector2(spykeSpawnPoint.transform.position.x, spykeSpawnPoint.transform.position.y);
        spykeStack = new Stack<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            GameObject spyke = Instantiate(spykePrefab, spawnPoint, Quaternion.identity);
            spyke.SetActive(false);
            spykeStack.Push(spyke);
        }
        StartCoroutine(SpawnSpykes());
    }
    void Update()
    {

    }

    public void Push(GameObject spyke)
    {
        spyke.SetActive(false);
        spykeStack.Push(spyke);
    }

    public GameObject Pop()
    {
        return spykeStack.Pop();
    }

    public IEnumerator SpawnSpykes()
    {
        GameObject spyke = Pop();
        spyke.transform.position = new Vector2(spykeSpawnPoint.transform.position.x, spykeSpawnPoint.transform.position.y);
        spyke.SetActive(true);
        yield return new WaitForSeconds(Random.Range(minTimeSpawn, maxTimeSpawn));
        yield return SpawnSpykes();
    }
}
