using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionImage : MonoBehaviour
{

    public float startWidth;

    public float endWidth;

    public float timeFactor = 0.4f;

    private RectTransform rectTrans;

    private void Start()
    {
        Canvas.ForceUpdateCanvases();

        rectTrans = GetComponent<RectTransform>();

    }

    [ContextMenu("Transition")]
    public void Transition()
    {
        LeanTween.moveLocalX(gameObject, endWidth, timeFactor).setEaseInOutBack();
    }

    [ContextMenu("Retransition")]
    public void Retransition()
    {
        LeanTween.moveLocalX(gameObject, startWidth, timeFactor).setEaseInOutBack();
    }
}
