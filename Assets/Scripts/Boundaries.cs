using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{

    private float playerHeight;

    void Start()
    {
        playerHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        clampPlayerMovement();
    }

    void clampPlayerMovement()
    {
        Vector2 position = transform.position;

        float botBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y + playerHeight;
        float topBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y - playerHeight;

        position.y = Mathf.Clamp(position.y, botBorder, topBorder);
        transform.position = position;
    }
}
