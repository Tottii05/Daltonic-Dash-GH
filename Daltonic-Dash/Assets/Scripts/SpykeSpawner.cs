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
    private Color actualColor;
    private Color targetColor;
    private float lerpProgress = -10f;

    void Start()
    {
        ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("SpykeColor"), out actualColor);
        ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("BGColor"), out targetColor);
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
        lerpProgress = Mathf.Clamp01(lerpProgress + 0.1f);
        actualColor = Color.Lerp(actualColor, targetColor, lerpProgress);
        spyke.GetComponent<SpriteRenderer>().color = actualColor;
        spyke.SetActive(true);
        yield return new WaitForSeconds(Random.Range(minTimeSpawn, maxTimeSpawn));
        yield return SpawnSpykes();
    }
}
