using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DayLabel : MonoBehaviour {

    public float displayForSeconds = 5f;
    private Text text;
    private static readonly string dayText = "Day: ";

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.text = dayText + GameManager.day;

        Invoke("DestroyLabel", displayForSeconds);
	}

    private void DestroyLabel() {
        Destroy(gameObject);
    }
}
