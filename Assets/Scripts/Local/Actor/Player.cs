using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float totalStamina = 10f;
    public float stamina = 10f;
    public float fatiguePerSecond = 0.1f;
    public float fatigueOnPunch = 1f;

    public GameObject staminaSliderObject;

    private static readonly string ATTACKING = "Attacking";
    private static readonly string REAPING = "Reaping";
    private bool attacking = false;

    private Animator animator;
    private Slider staminaSlider;
    private PlayerController controller;

    private bool alive = true;

    public void Start() {

        animator = GetComponent<Animator>();
        staminaSlider = staminaSliderObject.GetComponent<Slider>();
        controller = GetComponent<PlayerController>();

        InvokeRepeating("applyFatigue", 1f, 1f);
        animator.SetBool(REAPING, true);

        stamina = totalStamina;
    }

    public void applyFatigue() {
        if (!alive) {
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
        attacking = true;
        animator.SetBool(ATTACKING, attacking);
        stamina -= fatigueOnPunch;
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
}
