using UnityEngine;
using System.Collections;

public class BenchScene : MonoBehaviour {

    public int timer = 15;
    public int divideStaminaBy = 10;
    public static int staminaAddition = 0;

	// Use this for initialization
	void Start () {

        InvokeRepeating("tick", 1f, 1f);
	}

    public void tick() {
        timer--;

        if (timer <= 0) {
            Debug.Log("Transitioning to other scene, adding stamina: " + staminaAddition);

            GameManager.staminaAddition += staminaAddition / divideStaminaBy;
            GameManager.score += staminaAddition / 4;

            Application.LoadLevel(Scenes.LEVEL_SCENE);
        }

        Debug.Log(timer);
    }
}
