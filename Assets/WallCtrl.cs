using UnityEngine;
using System.Collections;

public class WallCtrl : MonoBehaviour
{
    public float Speed = 1f;
    public float DestroyTime = 5f;
    public float YIntervalRange = 5f;

    public Transform UpWall;
    public Transform DownWall;

	void Start ()
    {
        float yinterval = Random.Range(YIntervalRange, 2 * YIntervalRange);
        UpWall.localPosition = new Vector3(0, yinterval, 0);
        DownWall.localPosition = new Vector3(0, -yinterval, 0);

        StartCoroutine(DestroyRoutine());    
	}
	
	void Update ()
    {
        transform.Translate(Vector3.left * Time.deltaTime * Speed);
	}

    IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(DestroyTime);

        GameManager.Instance.AddScore();

        Destroy(gameObject);
    }
}
