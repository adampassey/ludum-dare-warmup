using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public void OnTriggerStay(Collider other) {
        Player player = other.GetComponent<Player>();
        if (player == null) {
            return;
        }

        if (player.IsAttacking()) {
            Die();
        }
    }

    public void Die() {
        Debug.Log("I'm dead...");
    }
}
