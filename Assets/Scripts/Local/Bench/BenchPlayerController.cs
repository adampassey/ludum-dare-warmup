using UnityEngine;
using System.Collections;

public class BenchPlayerController : MonoBehaviour {

    private Animator animator;
    private AudioSource audioSource;

    private static readonly string GET_SOME = "Getting Some";

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0)) {
            animator.SetBool(GET_SOME, true);
        }
        else {
            animator.SetBool(GET_SOME, false);
        }
	}

    public void Benched() {
        BenchScene.staminaAddition++;
    }
}
