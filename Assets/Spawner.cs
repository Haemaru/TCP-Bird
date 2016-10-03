using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject WallPrefab;
    public float SpawnInterval = 3f;
    public float YRange = 5f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            var ypos = Random.Range(-YRange, YRange);
            Instantiate(WallPrefab, new Vector3(10, ypos, 0), Quaternion.identity);

            yield return new WaitForSeconds(SpawnInterval);
        }
    }
}
