using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionIndicator : MonoBehaviour
{
    public GameObject arrow;
    private InputManager inputManager;
    private Vector2 direction;

    private void Start()
    {
        arrow = GameObject.Find("DirectionArrow");
        inputManager = GameObject.Find("GameManager").GetComponent<InputManager>();
    }

    private void Update()
    {
        if (inputManager.gameManager.gameStates == GameStates.play)
        {
            if(!Input.GetMouseButton(0))
            {
                arrow.transform.localScale = new Vector3(0, 0, 0);
                arrow.SetActive(false);
            }
            if (Input.GetMouseButton(0))
            {
                arrow.SetActive(true);
                IndicateDirection();
            } 
        }
    }

    public void IndicateDirection()
    {
        direction = inputManager.directionVector;
        float magnitude = direction.magnitude;
        arrow.transform.localScale = new Vector3(1, 1, 1) * (magnitude / 100f);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }

}
