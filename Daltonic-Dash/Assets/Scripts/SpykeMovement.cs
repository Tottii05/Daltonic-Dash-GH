using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpykeMovement : MonoBehaviour
{
    private float speed = -1.5f;
    private SpykeSpawner spykeSpawner;
    void Start()
    {
        
    }

    void Update()
    {
        MoveBackwards();
    }

    public void MoveBackwards()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }

    public void OnBecameInvisible()
    {
        SpykeSpawner spykeSpawner = GameObject.Find("SpykeManager").GetComponent<SpykeSpawner>();
        spykeSpawner.Push(gameObject);
    }
}
