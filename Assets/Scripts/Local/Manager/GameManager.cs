using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public int day = 1;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
}
