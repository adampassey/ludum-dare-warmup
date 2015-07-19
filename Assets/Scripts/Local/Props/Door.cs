using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public void OnTriggerEnter(Collider other) {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController != null) {
            Debug.Log("Player reached door!");
            GameManager.score += 25;
            Application.LoadLevel(Scenes.BENCH_SCENE);
        }
    }
}
