using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public void OpenPanel()
    {
        LeanTween.moveX(gameObject, 550f, 0.5f).easeMethod();
        
    }
}
