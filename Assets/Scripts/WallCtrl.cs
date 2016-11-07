using UnityEngine;
using System.Collections;

public class WallCtrl : MonoBehaviour
{
    public float DestroyTime = 5f;
    public float YIntervalRange = 1f;

    public Transform UpWall;
    public Transform DownWall;

    Transform tr;
    Vector3 originalPos;

    void Awake()
    {
        tr = GetComponent<Transform>();
        originalPos = new Vector3(tr.position.x, tr.position.y, tr.position.z);
    }

    void OnEnable()
    {
        float yInterval = Random.Range(0, YIntervalRange);
        UpWall.localPosition = new Vector3(0, UpWall.position.y + yInterval, 0);
        DownWall.localPosition = new Vector3(0, DownWall.position.y - yInterval, 0);

        StartCoroutine(DestroyRoutine());
    }
	
	void Update()
    {
        tr.Translate(Vector3.left * Time.deltaTime * GameManager.Instance.WallSpeed);
	}

    IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(DestroyTime);

        tr.position = originalPos;
        Spawner.Instance.ReturnPooledWall(gameObject);
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Score" && PlayerCtrl.Instance.Alive) GameManager.Instance.AddScore();
    }
}
