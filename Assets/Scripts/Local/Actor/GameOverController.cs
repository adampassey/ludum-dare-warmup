﻿using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.N)) {
            GameManager.Reset();
            Application.LoadLevel(Scenes.LEVEL_SCENE);
        }
	}
}
