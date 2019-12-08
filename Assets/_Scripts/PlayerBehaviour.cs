using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody2D rb;
    public GameObject splatterPrefab;

    public int jumpCount;
    public int maxJumpCount;

    public bool isGrounded;
    public bool isMoving;
    public bool isSliding;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();

        jumpCount = 0;
        isGrounded = false;
        isMoving = false;
        isSliding = false;
    }

    private void Update()
    {
        if (rb.velocity.magnitude > 0.1f)
        {
            isMoving = true;
        }
        else if (rb.velocity.magnitude <= 0.1f)
        {
            isMoving = false;
        }
        if (isGrounded)
        {
            jumpCount = 0;
        }
        if (GameObject.Find("GameManager").GetComponent<TimeManager>().isTimeSlow && !isGrounded)
        {
            Invoke("SpawnGhosts", 0.01f);
            
        }
    }

    [ContextMenu("PlayerDie")]
    public void PlayerDie()
    {
        GameObject splatter = Instantiate(splatterPrefab, transform.position, Quaternion.identity);
        splatter.GetComponent<SplatCaster>().CastSplat(transform.position);
        gameManager.SetState(GameStates.dead);
        gameObject.SetActive(false);
    }

    public void ApplyForce(Vector2 direction)
    {
        if (jumpCount < maxJumpCount)
        {
            jumpCount++;
            rb.velocity = Vector2.zero;

            rb.AddForce(direction.normalized * direction.magnitude, ForceMode2D.Impulse);
        }
        else
        {
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        rb.velocity = new Vector2(0f, 0f);
        if (collision.gameObject.layer == 10)
        {
            PlayerDie();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        isSliding = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        return;
    }
}
