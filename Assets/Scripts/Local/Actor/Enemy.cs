using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public void OnTriggerStay(Collider other) {
        Player player = other.GetComponent<Player>();
        Bullet bullet = other.GetComponent<Bullet>();

        if (player != null) {
            if (player.IsAttacking()) {
                Die();
                return;
            }
        }

        if (bullet != null) {
            Destroy(bullet.gameObject);
            Die();
        }
    }

    public void Die() {
        GameObject bloodSplosion = GameObject.Instantiate(Resources.Load(Prefabs.BLOOD_SPLOSION), transform.position, Quaternion.identity) as GameObject;
        GameManager.killCount++;
        GameManager.score += 10;
        Destroy(gameObject);
    }
}
