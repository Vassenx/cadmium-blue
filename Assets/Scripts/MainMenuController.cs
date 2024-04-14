using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    Rigidbody2D rb;
    bool inStart = false;
    bool inCredits = false;
    bool scrolled = false;
    public Canvas canvas;
    RectTransform first;
    RectTransform second;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        first = canvas.gameObject.transform.GetChild(0).GetComponent<RectTransform>();
        second = canvas.gameObject.transform.GetChild(1).GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A)) {
            rb.velocity = new Vector2(-300 * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.D)) {
            rb.velocity = new Vector2(300 * Time.deltaTime, 0);
        }
        else rb.velocity = Vector2.zero;
    }

    void Update() {
        if (inStart && Input.GetKey(KeyCode.E)) SceneManager.LoadScene(0);
        if (inCredits && !scrolled && Input.GetKey(KeyCode.E)) StartCoroutine(ScrollToCredits());
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.transform.childCount > 0)
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            other.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        if (other.name == "Start") inStart = true;
        if (other.name == "Credits") inCredits = true;
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.transform.childCount > 0)
            other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            other.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        if (other.name == "Start") inStart = false;
        if (other.name == "Credits"){
            if (scrolled) {
                StartCoroutine(ScrollToCredits());
            }
            inCredits = false;
        }
    }

    IEnumerator StartGame() {
        // Play fire animation
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }

    IEnumerator ScrollToCredits() {
        inCredits = false;
        scrolled = !scrolled;
        for (var i = 0; i < 115; i++) {
            first.anchoredPosition = new Vector2(first.anchoredPosition.x, first.anchoredPosition.y+5);
            second.anchoredPosition = new Vector2(second.anchoredPosition.x, second.anchoredPosition.y+5);
            yield return new WaitForSeconds(0.05f);
        }
        inCredits = true;
        if (!scrolled) {
            first.anchoredPosition = new Vector2(first.anchoredPosition.x, first.anchoredPosition.y - 1150);
            second.anchoredPosition = new Vector2(second.anchoredPosition.x, second.anchoredPosition.y - 1150);
        }
    }                                                                                                                          
}
