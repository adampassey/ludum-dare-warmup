using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float stamina = 10f;
    public float fatiguePerSecond = 0.1f;

    public void Start() {
        InvokeRepeating("applyFatigue", 1f, 1f);
    }

    public void applyFatigue() {
        stamina -= fatiguePerSecond;

        //  player died
        if (stamina <= 0f) {
            //  TODO: might want to do a die animation or something
            Application.LoadLevel(Scenes.GAME_OVER_SCENE);
        }
    }
}
