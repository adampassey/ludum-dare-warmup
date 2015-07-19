using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static int day = 1;
    public static int staminaAddition = 0;
    public static int score = 0;
    public static int killCount = 0;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}

    public static void Reset() {
        day = 1;
        staminaAddition = 0;
        score = 0;
        killCount = 0;
    }

    public static void IncrementDay(int additionalStamina, int additionalScore) {
        staminaAddition = additionalStamina;
        score += additionalScore;
        day++;
        killCount = 0;
    }
}
