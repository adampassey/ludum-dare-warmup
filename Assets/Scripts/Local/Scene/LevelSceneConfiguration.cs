using UnityEngine;
using System.Collections;

public class LevelSceneConfiguration : MonoBehaviour {

    public int staminaAddition = 0;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
}
