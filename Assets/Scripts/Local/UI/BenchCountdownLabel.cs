using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class BenchCountdownLabel : MonoBehaviour {

    private Text text;
    private BenchScene benchScene;
    private bool countdownStarted = false;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        benchScene = GameObject.FindGameObjectWithTag(Tags.BENCH_SCENE).GetComponent<BenchScene>();

        Invoke("startCountdown", 3);
	}
	
	// Update is called once per frame
	void Update () {
        if (countdownStarted) {
            text.text = benchScene.timer.ToString();
        }
	}

    private void startCountdown() {
        countdownStarted = true;
    }
}
