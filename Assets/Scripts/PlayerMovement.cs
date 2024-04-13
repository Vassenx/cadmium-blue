using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 1;
    public int dashModifier = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) {
            float right = 0;
            float up = 0;
            if (Input.GetKey(KeyCode.W)) {
                up += speed;
            }
            if (Input.GetKey(KeyCode.A)) {
                right -= speed;
            }
            if (Input.GetKey(KeyCode.S)) {
                up -= speed;
            }
            if (Input.GetKey(KeyCode.D)) {
                right += speed;
            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                StartCoroutine(Dash());
            }
            rb.velocity = new UnityEngine.Vector2(right, up);
        }
        else rb.velocity = UnityEngine.Vector2.zero;
    }

    IEnumerator Dash()
    {
        speed *= dashModifier;
        yield return new WaitForSeconds(0.1f);
        speed /= dashModifier;
    }
}
