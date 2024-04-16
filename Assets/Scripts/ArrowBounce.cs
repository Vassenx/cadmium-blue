using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBounce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Bounce());
    }

    IEnumerator Bounce() {
        while (true) {
            if (transform.position.y < 1.4f) {
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.05f);
                yield return new WaitForSeconds(0.1f);
            }
            if (transform.position.y > 0.8f) {
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.05f);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
