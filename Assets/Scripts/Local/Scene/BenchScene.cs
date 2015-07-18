using UnityEngine;
using System.Collections;

public class BenchScene : MonoBehaviour {

    public int timer = 15;
    public int divideStaminaBy = 10;
    public static int staminaAddition = 0;

    private GameManager gameManager;

	// Use this for initialization
	void Start () {

        gameManager = GameObject.FindGameObjectWithTag(Tags.GAME_MANAGER).GetComponent<GameManager>();

        InvokeRepeating("tick", 1f, 1f);
	}

    public void tick() {
        timer--;

        if (timer <= 0) {
            Debug.Log("Transitioning to other scene, adding stamina: " + staminaAddition);

            if (gameManager == null) {
                Debug.Log("Unable to find Game Manager.");
            }
            else {
                gameManager.staminaAddition += staminaAddition / divideStaminaBy;
            }

            Application.LoadLevel(Scenes.LEVEL_SCENE);
        }

        Debug.Log(timer);
    }
}
