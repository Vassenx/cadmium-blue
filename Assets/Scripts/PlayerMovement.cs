using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 200;
    int dashModifier = 5;
    List<GameObject> interactables = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.anyKey) {
            float right = 0;
            float up = 0;
            if (Input.GetKey(KeyCode.W)) {
                up += 0.5f;
            }
            if (Input.GetKey(KeyCode.A)) {
                right -= 1;
            }
            if (Input.GetKey(KeyCode.S)) {
                up -= 0.5f;
            }
            if (Input.GetKey(KeyCode.D)) {
                right += 1;
            }
            rb.velocity = new UnityEngine.Vector2(right, up) * Time.deltaTime * speed;
        }
        else rb.velocity = UnityEngine.Vector2.zero;
    }

    void Update() {
        transform.rotation = UnityEngine.Quaternion.identity;
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(Dash());
        }
        if (Input.GetKeyDown(KeyCode.E) && interactables.Any()) {
            rb.velocity = UnityEngine.Vector2.zero;
            interactables.Last().GetComponent<Interactable>().Interact();
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (interactables.Any()) interactables.Last().transform.GetChild(0).gameObject.SetActive(false);
        if (other.gameObject.tag == "Interactable") {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            interactables.Add(other.gameObject);
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Interactable") {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            interactables.Remove(other.gameObject);
        }
    }

    IEnumerator Dash()
    {
        speed *= dashModifier;
        yield return new WaitForSeconds(0.1f);
        speed /= dashModifier;
    }
}
