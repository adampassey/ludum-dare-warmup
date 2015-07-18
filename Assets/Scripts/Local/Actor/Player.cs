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
    private bool attacking = false;

    private Animator animator;
    private Slider staminaSlider;

    public void Start() {

        animator = GetComponent<Animator>();
        staminaSlider = staminaSliderObject.GetComponent<Slider>();

        InvokeRepeating("applyFatigue", 1f, 1f);

        stamina = totalStamina;
    }

    public void applyFatigue() {
        stamina -= fatiguePerSecond;

        if (staminaSlider != null) {
            staminaSlider.value = (stamina / totalStamina);
        }

        //  player died
        if (stamina <= 0f) {
            //  TODO: might want to do a die animation or something
            Application.LoadLevel(Scenes.GAME_OVER_SCENE);
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
}
