using UnityEngine;
using System.Collections;

public class Navigator : MonoBehaviour {

    [Range(1f, 100f)]
    public float speed = 1f;

    private Vector3 direction;

    public void Move(Vector3 direction) {
        this.direction = direction;
    }

    public void FixedUpdate() {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
