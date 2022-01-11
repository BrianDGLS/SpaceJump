using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut : MonoBehaviour
{
    public float upForce = 1600f;
    private bool isDead = false;
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private bool jetpackAlt = false;
    public float fallMultiplier = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody2D.velocity = Vector2.zero;
                rigidbody2D.AddForce(new Vector2(0, upForce));
                string jetpack = "JetPack" + (jetpackAlt ? "Alt" : "");
                if (!animator.IsInTransition(0))
                {
                    animator.SetTrigger(jetpack);
                }
                jetpackAlt = !jetpackAlt;
                if (rigidbody2D.velocity.y < 0)
                {
                    Jump(fallMultiplier);
                }
            }
        }
    }

    void Jump(float modifier)
    {
        rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (modifier - 1) * Time.deltaTime;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        animator.SetTrigger("Death");
        GameControl.Instance.PlayerDied();
    }
}
