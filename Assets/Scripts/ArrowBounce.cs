using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBounce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Bounce());
    }

    IEnumerator Bounce() {
        while (transform.position.y < 1.4f) {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
            yield return new WaitForSeconds(0.2f);
        }
        while (transform.position.y > 0.9f) {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
