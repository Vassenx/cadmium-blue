using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    bool inStart = false;
    bool inCredits = false;
    bool scrolled = false;
    bool inSettings = false;
    public Canvas canvas;
    RectTransform first;
    RectTransform second;
    public AnimationClip leftWalk;
    public AnimationClip leftIdle;
    public AnimationClip rightWalk;
    public AnimationClip rightIdle;
    public AnimationClip upIdle;
    bool lastRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        first = canvas.gameObject.transform.GetChild(0).GetComponent<RectTransform>();
        second = canvas.gameObject.transform.GetChild(1).GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A)) {
            rb.velocity = new Vector2(-300 * Time.deltaTime, 0);
            anim.Play(leftWalk.name);
            lastRight = false;
        }
        else if (Input.GetKey(KeyCode.D)) {
            rb.velocity = new Vector2(300 * Time.deltaTime, 0);
            anim.Play(rightWalk.name);
            lastRight = true;
        }
        else if (Input.GetKey(KeyCode.E)) {
            anim.Play(upIdle.name);
        }
        else {
            if (lastRight) anim.Play(rightIdle.name);
            else anim.Play(leftIdle.name);
            rb.velocity = Vector2.zero;
        }
    }

    void Update() {
        if (Input.GetKey(KeyCode.E)) {
            if (inStart) SceneManager.LoadScene(0);
            if (inCredits) StartCoroutine(ScrollToCredits());
            if (inSettings) canvas.gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Escape) && canvas.gameObject.transform.GetChild(2).gameObject.activeSelf) {
            canvas.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.transform.childCount > 0)
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            other.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        if (other.name == "Start") inStart = true;
        if (other.name == "Credits") {
            scrolled = false;
            inCredits = true;
        }
        if (other.name == "Settings") inSettings = true;
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
        if (other.name == "Settings") inSettings = false;
    }

    IEnumerator StartGame() {
        // Play fire animation
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }

    IEnumerator ScrollToCredits() {
        inCredits = false;
        scrolled = true;
        for (var i = 0; i < 115; i++) {
            first.anchoredPosition = new Vector2(first.anchoredPosition.x, first.anchoredPosition.y+5);
            second.anchoredPosition = new Vector2(second.anchoredPosition.x, second.anchoredPosition.y+5);
            yield return new WaitForSeconds(0.05f);
        }
        inCredits = true;
        if (second.anchoredPosition.y >= 635) {
            first.anchoredPosition = new Vector2(first.anchoredPosition.x, 150);
            second.anchoredPosition = new Vector2(second.anchoredPosition.x, -515);
        }
    }     

    public void QuitToDesktop() {
        Application.Quit();
    }                                                                                                                   
}
