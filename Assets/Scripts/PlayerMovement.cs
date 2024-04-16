using System;
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

    //0: up, 1: down, 2: left, 3: right
    [SerializeField] private Vector2 playerDirection;
    [SerializeField] private Vector2 lastDirection;
    [SerializeField] private CombatController combatController;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(gameObject);
    }
    
    void HandleOrientation()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if ((horizontal == 0 && vertical == 0) && (playerDirection.x != 0 || playerDirection.y != 0))
        {
            lastDirection = playerDirection;
        }
        
  
        
        playerDirection.x = Input.GetAxisRaw("Horizontal");
        playerDirection.y = Input.GetAxisRaw("Vertical");
        
        combatController.SetAnimParamFloat(horizontal, "DirX");
        combatController.SetAnimParamFloat(vertical, "DirY");
        combatController.SetAnimParamFloat(lastDirection.x, "LastX");
        combatController.SetAnimParamFloat(lastDirection.y, "LastY");
        combatController.SetAnimParamFloat(playerDirection.magnitude, "motion");
    }

    void FixedUpdate()
    {
        HandleOrientation();
            if (Input.anyKey)
            {
                float right = 0;
                float up = 0;
                if (Input.GetKey(KeyCode.W))
                {
                    up += 0.5f;
                }

                if (Input.GetKey(KeyCode.A))
                {
                    right -= 1;
                }

                if (Input.GetKey(KeyCode.S))
                {
                    up -= 0.5f;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    right += 1;
                }

                if (!combatController.inAttackingMotion)
                {
                    rb.velocity = new UnityEngine.Vector2(right, up) * Time.deltaTime * speed;
                }
            }
            else rb.velocity = UnityEngine.Vector2.zero;
    }

    // TODO move camera code to LateUpdate()
    void Update() {
        if (!combatController.isAttacking)
        {
            transform.rotation = UnityEngine.Quaternion.identity;
            if (Input.GetKeyDown(KeyCode.Space)) {
                StartCoroutine(Dash());
            }
            if (Input.GetKeyDown(KeyCode.E) && interactables.Any()) {
                rb.velocity = UnityEngine.Vector2.zero;
                interactables.Last().GetComponent<Interactable>().Interact();
            }
            combatController.Attack();
        }
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (interactables.Any()) interactables.Last().transform.GetChild(0).gameObject.SetActive(false);
        if (other.gameObject.tag == "Interactable") {
            interactables.Add(other.gameObject);
        }
    }
    void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject.tag == "Interactable") {
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
