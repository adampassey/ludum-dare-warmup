using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Navigator navigator;
    private Player player;

	// Use this for initialization
	void Start () {
        navigator = GetComponent<Navigator>();
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

        float horizontalInput = Input.GetAxis(Inputs.HORIZONTAL);
        Vector3 movementDirection = Vector3.zero;
        movementDirection.x = horizontalInput;

        //  move!
        navigator.Move(movementDirection);

        //  attack
        if (Input.GetKeyDown(KeyCode.Space)) {
            player.Attack();
        }
        
	}
}
