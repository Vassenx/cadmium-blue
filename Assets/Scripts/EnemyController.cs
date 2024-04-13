using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float speed = 20;
    public int healthState = 1;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (healthState <= 0) {
            StartCoroutine(Die());
        }
        Vector2 direction = new Vector2(playerRb.position.x - rb.position.x, (playerRb.position.y - rb.position.y) * 0.5f);
        rb.velocity = direction * Time.deltaTime * speed;
    }

    IEnumerator Die() {
        gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        yield return new WaitForSeconds(1);
    }
}
