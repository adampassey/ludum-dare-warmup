using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float stamina = 10f;
    public float fatiguePerSecond = 0.1f;

    private static readonly string ATTACKING = "Attacking";
    private bool attacking = false;
    private Animator animator;

    public void Start() {

        animator = GetComponent<Animator>();

        InvokeRepeating("applyFatigue", 1f, 1f);
    }

    public void applyFatigue() {
        stamina -= fatiguePerSecond;

        //  player died
        if (stamina <= 0f) {
            //  TODO: might want to do a die animation or something
            Application.LoadLevel(Scenes.GAME_OVER_SCENE);
        }
    }

    public void Attack() {
        attacking = true;
        animator.SetBool(ATTACKING, attacking);
    }

    public void StopAttacking() {
        attacking = false;
        animator.SetBool(ATTACKING, attacking);
    }
}
