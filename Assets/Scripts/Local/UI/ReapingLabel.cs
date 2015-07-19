using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class ReapingLabel : MonoBehaviour {

    public float showForSeconds = 2;
    public string textLabel = "REAPING!";

    private Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        Hide();

        text.text = textLabel;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Show() {
        if (!gameObject.active) {
            Invoke("Hide", showForSeconds);
        }

        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
}
