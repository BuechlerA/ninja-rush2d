using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody2D rb;

    private int jumpCount;

    public float jumpForce = 20f;
    public float fallingSpeed = 0f;

    private bool isGrounded;
    private bool isMoving;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();

        jumpCount = 0;
        isGrounded = false;
        isMoving = false;
    }

    [ContextMenu("PlayerDie")]
    public void PlayerDie()
    {
        gameManager.SetState(GameStates.dead);
        gameObject.SetActive(false);
    }

    public void ApplyForce(Vector2 direction)
    {
        jumpCount++;
        rb.velocity = Vector2.zero;

        rb.AddForce(direction.normalized * direction.magnitude, ForceMode2D.Impulse);
    }
}
