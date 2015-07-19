using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float lifespan = 5;
    public float speed = 50;
    public Vector3 direction = Vector3.zero;

	// Use this for initialization
	void Start () {
        Invoke("Die", lifespan);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction * speed * Time.deltaTime);
	}

    private void Die() {
        Destroy(gameObject);
    }
}
