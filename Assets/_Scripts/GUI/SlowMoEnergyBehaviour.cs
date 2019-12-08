using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoEnergyBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private TimeManager timeManager;
    [SerializeField]
    private SpriteRenderer sprite;

    [SerializeField]
    private float currentSlowMoEnergy;
    public float maxSlowMoEnergy;
    public float slowMoEnergyMagnitude;

    public float depleteSpeed;
    public float regenSpeed;

    private bool isEnergyDepleted;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        timeManager = GameObject.Find("GameManager").GetComponent<TimeManager>();
        //sprite = GetComponent<SpriteRenderer>();
        currentSlowMoEnergy = maxSlowMoEnergy;
    }

    private void Update()
    {
        transform.position = player.position;
        slowMoEnergyMagnitude = currentSlowMoEnergy / maxSlowMoEnergy;
        currentSlowMoEnergy = Mathf.Clamp(currentSlowMoEnergy, 0f, 1f);
        slowMoEnergyMagnitude = Mathf.Clamp(slowMoEnergyMagnitude, 0f, 1f); 
        
        if (timeManager.isTimeSlow && !player.GetComponent<PlayerBehaviour>().isGrounded)
        {
            currentSlowMoEnergy -= Time.deltaTime * depleteSpeed;
        }
        if (!timeManager.isTimeSlow && !isEnergyDepleted)
        {
            currentSlowMoEnergy += Time.deltaTime * regenSpeed;
        }
        if (isEnergyDepleted)
        {
            if (player.GetComponent<PlayerBehaviour>().isGrounded)
            {
                currentSlowMoEnergy += Time.deltaTime * regenSpeed;
                if (currentSlowMoEnergy == maxSlowMoEnergy)
                {
                    isEnergyDepleted = false;
                }
            }
        }
        if (slowMoEnergyMagnitude <= 0.3f)
        {
            isEnergyDepleted = true;
            timeManager.UnSlowMo();
        }

        sprite.transform.localScale = new Vector2(slowMoEnergyMagnitude, slowMoEnergyMagnitude);
    }
}
