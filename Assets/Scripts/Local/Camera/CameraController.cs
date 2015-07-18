using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject target;
    public float speed = 5f;

    private Vector3 moveDirection;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 targetPos = target.transform.position;
        targetPos.z = transform.position.z;

        moveDirection = targetPos - transform.position;
	}

    public void FixedUpdate() {

        transform.Translate(moveDirection * speed * Time.deltaTime);
        
        moveDirection = Vector3.zero;
    }
}
