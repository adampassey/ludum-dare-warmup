using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Navigator navigator;

	// Use this for initialization
	void Start () {
        navigator = GetComponent<Navigator>();
	}
	
	// Update is called once per frame
	void Update () {

        float horizontalInput = Input.GetAxis(Inputs.HORIZONTAL);
        Vector3 movementDirection = Vector3.zero;
        movementDirection.x = horizontalInput;

        navigator.Move(movementDirection);
	}
}
