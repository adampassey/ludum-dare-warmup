using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class GameOverScore : MonoBehaviour {

    private Text text;
    private static string scoreText = "Score: ";

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = scoreText + GameManager.score.ToString();
	}
}
