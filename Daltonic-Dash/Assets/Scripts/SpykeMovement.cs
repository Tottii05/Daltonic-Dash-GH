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
        if (gameObject.activeInHierarchy)
        {
            GameObject spykeManager = GameObject.Find("SpykeManager");
            if (spykeManager != null)
            {
                SpykeSpawner spykeSpawner = spykeManager.GetComponent<SpykeSpawner>();
                spykeSpawner.Push(gameObject);
            }
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
