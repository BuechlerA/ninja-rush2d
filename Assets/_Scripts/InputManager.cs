using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject player;

    public Vector2 touchOne;
    public Vector2 touchTwo;
    public Vector2 directionVector;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameStates == GameStates.play)
        {
            if (Input.GetMouseButtonDown(0))
            {
                touchOne = Input.mousePosition;
                GetComponent<TimeManager>().DoSlowMo();
            }
            if (Input.GetMouseButton(0))
            {
                touchTwo = Input.mousePosition;
                directionVector = touchOne - touchTwo;
            }
            if (Input.GetMouseButtonUp(0))
            {
                GetComponent<TimeManager>().UnSlowMo();
                player.GetComponent<PlayerBehaviour>().ApplyForce(CalculateJumpVector(touchOne, touchTwo));
            }
        }
    }

    private Vector2 CalculateJumpVector(Vector2 touchOne, Vector2 touchTwo)
    {
        return touchOne - touchTwo;
    }
}
