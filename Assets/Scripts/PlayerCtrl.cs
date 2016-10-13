using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour
{
    public static PlayerCtrl Instance;

    public bool Alive { get; set; }
    public float Speed = 1f;

    Transform tr;

    void Awake()
    {
        Instance = this;

        tr = GetComponent<Transform>();

        Alive = true;
    }
	
	void Update()
    {
        var dir = Vector3.down;
        if (Input.anyKey) dir = Vector3.up;

        tr.Translate(dir * Time.deltaTime * Speed);    
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (Alive)
        {
            Alive = false;
            Debug.Log("Player dead");
        }
    }
}
