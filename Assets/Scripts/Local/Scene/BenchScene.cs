using UnityEngine;
using System.Collections;

public class BenchScene : MonoBehaviour {

    public int timer = 15;

	// Use this for initialization
	void Start () {
        InvokeRepeating("tick", 1f, 1f);
	}

    public void tick() {
        timer--;

        if (timer <= 0) {
            Debug.Log("Transitioning to other scene");
            Application.LoadLevel(Scenes.LEVEL_SCENE);
        }

        Debug.Log(timer);
    }
}
