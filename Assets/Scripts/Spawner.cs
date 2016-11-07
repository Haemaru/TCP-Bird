using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    public GameObject WallPrefab;
    public float SpawnInterval = 3f;
    public float YRange = 1f;
    public int WallCount = 5;

    Queue<GameObject> wallQueue;

    void Awake()
    {
        Instance = this;

        wallQueue = new Queue<GameObject>();

        for (int i = 0; i < WallCount; i++)
        {
            var ypos = Random.Range(-YRange, YRange);
            var wall = (GameObject)Instantiate(WallPrefab, new Vector3(10, ypos, 0), Quaternion.identity);
            wall.SetActive(false);
            wallQueue.Enqueue(wall);

            if (SpawnInterval > 1) SpawnInterval -= 0.1f;
        }
    }

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(SpawnInterval);

            GetPooledWall();
        }
    }

    public GameObject GetPooledWall()
    {
        Debug.Log("Get Pooled Wall");
        var wall = wallQueue.Dequeue();
        wall.SetActive(true);
        return wall;
    }

    public void ReturnPooledWall(GameObject wall)
    {
        Debug.Log("Return Pooled Wall");
        wall.SetActive(false);
        wallQueue.Enqueue(wall);
    }
}
