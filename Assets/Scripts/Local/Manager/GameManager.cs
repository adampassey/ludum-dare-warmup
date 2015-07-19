using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static int day = 1;
    public static int staminaAddition = 0;
    public static int score = 0;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}

    public static void Reset() {
        day = 0;
        staminaAddition = 0;
        score = 0;
    }
}
