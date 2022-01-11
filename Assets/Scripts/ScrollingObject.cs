using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(GameControl.Instance.scrollSpeed, 0);
    }

    void Update()
    {
        if (GameControl.Instance.gameOver)
        {
            rigidbody2D.velocity = Vector2.zero;
        }
    }
}
