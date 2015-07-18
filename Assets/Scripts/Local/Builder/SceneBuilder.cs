using UnityEngine;
using System.Collections;

public class SceneBuilder : MonoBehaviour {

    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        GameObject gameManagerObject = GameObject.FindGameObjectWithTag(Tags.GAME_MANAGER);
        if (gameManagerObject == null) {
            gameManagerObject = GameObject.Instantiate(Resources.Load(Prefabs.GAME_MANAGER) as GameObject);
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
