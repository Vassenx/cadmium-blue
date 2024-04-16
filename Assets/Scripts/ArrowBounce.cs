using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBounce : MonoBehaviour
{
    int floatDirection;

    // Start is called before the first frame update
    void Start()
    {
        floatDirection = 1;
        StartCoroutine(Bounce());
    }

    IEnumerator Bounce() {
        while (true) {
            if (transform.localPosition.y > 1f) {
                floatDirection = -1;
            }
            else if (transform.localPosition.y < 0.8f) {
                floatDirection = 1;
            }

            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + (floatDirection * 0.05f));
            yield return new WaitForSeconds(0.1f);
        }
    }
}
