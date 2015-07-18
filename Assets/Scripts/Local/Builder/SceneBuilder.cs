using UnityEngine;
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
            gameManager = gameManagerObject.GetComponent<GameManager>();
            gameManager.day ++;
        }

        levelScene = GameObject.FindGameObjectWithTag(Tags.LEVEL_SCENE).GetComponent<LevelScene>();
        levelScene.SpawnDoor(gameManager.day);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
