using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class binScript_landfill : MonoBehaviour
{
    private Animator animationState;
    private float timer = 0;

    void Start()
    {
        animationState = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (animationState.GetInteger("State") == 1)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                animationState.SetInteger("State", 0);
                timer = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        animationState.SetInteger("State", 1); //switches idle to eating animation
        timer = 0;
    }
}
