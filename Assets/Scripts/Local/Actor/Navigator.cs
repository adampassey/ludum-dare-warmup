using UnityEngine;
using System.Collections;

public class Navigator : MonoBehaviour {

    [Range(1f, 100f)]
    public float speed = 1f;

    private Vector3 direction;
    private Animator animator;

    private static readonly string MOVEMENT = "Movement";
    private static readonly string MOVING = "Moving";

    private bool facingRight = true;

    public void Start() {
        animator = GetComponent<Animator>();
    }

    public void Update() {

        //  update animation
        animator.SetFloat(MOVEMENT, direction.x);

        //  if he's not moving
        if (Mathf.Approximately(direction.x, 0f)) {
            animator.SetBool(MOVING, false);
        }
        else {
            animator.SetBool(MOVING, true);
        }

        Vector3 localScale = transform.localScale;

        //  face actor
        if (direction.x < 0f) {
            faceLeft();
        }
        else if (direction.x > 0f) {
            faceRight();
        }
    }

    public void Move(Vector3 direction) {
        this.direction = direction;
    }

    public void FixedUpdate() {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void faceLeft() {
        Vector3 localScale = transform.localScale;
        localScale.x = -1;
        transform.localScale = localScale;
    }

    private void faceRight() {
        Vector3 localScale = transform.localScale;
        localScale.x = 1;
        transform.localScale = localScale;
    }
}
