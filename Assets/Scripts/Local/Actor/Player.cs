using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float totalStamina = 10f;
    public float stamina = 10f;
    public float fatiguePerSecond = 0.1f;
    public float fatigueOnPunch = 1f;
    public int killsToInitiateReaping = 10;
    public float reapTime = 10;

    public GameObject staminaSliderObject;
    public GameObject reapingLabelObject;

    private static readonly string ATTACKING = "Attacking";
    private static readonly string REAPING = "Reaping";
    private bool attacking = false;
    private bool reaping = false;

    private Animator animator;
    private Navigator navigator;
    private Slider staminaSlider;
    private PlayerController controller;
    private ReapingLabel reapingLabel;

    private bool alive = true;

    public void Start() {

        animator = GetComponent<Animator>();
        navigator = GetComponent<Navigator>();
        staminaSlider = staminaSliderObject.GetComponent<Slider>();
        controller = GetComponent<PlayerController>();
        reapingLabel = reapingLabelObject.GetComponent<ReapingLabel>();

        InvokeRepeating("applyFatigue", 1f, 1f);

        stamina = totalStamina;
    }

    public void Update() {
        if (!alive) {
            return;
        }

        if (GameManager.killCount >= killsToInitiateReaping && !reaping) {
            reap();
        }
    }

    public void applyFatigue() {
        if (!alive || reaping) {
            return;
        }

        stamina -= fatiguePerSecond;

        if (staminaSlider != null) {
            staminaSlider.value = (stamina / totalStamina);
        }

        //  player died
        if (stamina <= 0f) {
            Die();
        }
    }

    public void Attack() {
        if (reaping) {
            //  shoot bullet
            Vector3 position = transform.position;
            Vector2 direction = Vector2.right;

            position.x += 1.5f;
            position.y = 0.141f;
            position.z = 0.5f;

            if (!navigator.FacingRight()) {
                direction = -Vector2.right;
                position.x -= 3f;
            }

            GameObject bulletGameObject = GameObject.Instantiate(Resources.Load(Prefabs.BULLET)) as GameObject;
            bulletGameObject.transform.position = position;

            Bullet bullet = bulletGameObject.GetComponent<Bullet>();
            bullet.direction = direction;
        }
        else {
            attacking = true;
            animator.SetBool(ATTACKING, attacking);
            stamina -= fatigueOnPunch;
        }
    }

    public void StopAttacking() {
        attacking = false;
        animator.SetBool(ATTACKING, attacking);
    }

    public bool IsAttacking() {
        return attacking;
    }

    private void Die() {
        controller.gameObject.SetActive(false);
        GameObject.Instantiate(Resources.Load(Prefabs.BLOOD_SPLOSION), transform.position, Quaternion.identity);
        Invoke("displayGameOverScreen", 3f);
        alive = false;
    }

    private void displayGameOverScreen() {
        Application.LoadLevel(Scenes.GAME_OVER_SCENE);
    }

    private void reap() {
        reaping = true;
        animator.SetBool(REAPING, true);
        reapingLabel.Show();

        Invoke("stopReaping", reapTime);
    }

    private void stopReaping() {
        reaping = false;
        animator.SetBool(REAPING, false);
        GameManager.killCount = 0;
    }
}
