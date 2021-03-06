﻿using UnityEngine;
using System.Collections;

public class SceneBuilder : MonoBehaviour {

    private GameManager gameManager;
    private LevelScene levelScene;

	// Use this for initialization
	void Start () {

        GameObject gameManagerObject = GameObject.FindGameObjectWithTag(Tags.GAME_MANAGER);
        if (gameManagerObject == null) {
            gameManagerObject = GameObject.Instantiate(Resources.Load(Prefabs.GAME_MANAGER) as GameObject);
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }
        else {
            //  increment stamina accordingly
            GameObject playerObject = GameObject.FindGameObjectWithTag(Tags.PLAYER);
            Player player = playerObject.GetComponent<Player>();
            player.totalStamina += GameManager.staminaAddition;
            player.stamina = player.totalStamina;
        }

        levelScene = GameObject.FindGameObjectWithTag(Tags.LEVEL_SCENE).GetComponent<LevelScene>();
        levelScene.SpawnDoor(GameManager.day);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
