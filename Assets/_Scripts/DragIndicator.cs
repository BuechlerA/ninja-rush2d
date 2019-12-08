using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragIndicator : MonoBehaviour
{
    private GameManager gameManager;

    private Vector2 startPos;
    private Vector2 endPos;

    private LineRenderer lr;

    [SerializeField]
    private Color[] colors;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        lr = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player") != null)
        {
            int colorIndex = GameObject.Find("Player").GetComponent<PlayerBehaviour>().jumpCount;
            lr.startColor = colors[colorIndex];
        }

        if (gameManager.gameStates == GameStates.play)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lr.enabled = true;
                lr.positionCount = 2;
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                lr.SetPosition(0, startPos);

            }
            if (Input.GetMouseButton(0))
            {
                endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                lr.SetPosition(1, endPos);
            }
            if (Input.GetMouseButtonUp(0))
            {
                lr.positionCount = 0;
                lr.enabled = true;
            }
        }
    }
}
