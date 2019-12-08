using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpEnergyBehaviour : MonoBehaviour
{
    public Image[] dots;

    private PlayerBehaviour player;

    private int currentJumpCount;
    private int lastJumpCount;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
        player.jumpCount = currentJumpCount;
    }
    private void Update()
    {
        if (currentJumpCount != player.jumpCount)
        {
            currentJumpCount = lastJumpCount;
            currentJumpCount = player.jumpCount;
            RoutineStarter();
        }
        
        if (player.isGrounded)
        {
            //for (int i = 0; i < dots.Length; i++)
            //{
            //    dots[i].fillAmount += Time.deltaTime * 10f;
            //}
            StartCoroutine(Fill());
        }

    }

    [ContextMenu("RoutineStarter")]
    void RoutineStarter()
    {
        StartCoroutine(Unfill(player.jumpCount -1));
    }

    private IEnumerator Unfill(int jumpIndex)
    {
        float fillValue = 1f;

        while (dots[jumpIndex].fillAmount > 0f)
        {
            fillValue -= Time.deltaTime * 10f;
            dots[jumpIndex].fillAmount = fillValue;
            yield return new WaitForSeconds(Time.deltaTime);
        }
       
        yield return null;
    }

    private IEnumerator Fill()
    {
        for (int i = 0; i < dots.Length; i++)
        {
            if (dots[i].fillAmount < 1f)
            {
                dots[i].fillAmount += Time.deltaTime * 10f;
                yield return new WaitForSeconds(Time.deltaTime);
            }
            else
            {
                yield return null;
            }
        }     
    }

}
