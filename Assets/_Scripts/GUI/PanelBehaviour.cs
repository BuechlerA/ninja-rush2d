using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBehaviour : MonoBehaviour
{
    private Text textMessage;
    public Vector3 scaleAmount;

    public ScriptableObject textMessages;

    public virtual void Start()
    {
        gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
        textMessage = GameObject.Find("GameOverMessage").GetComponent<Text>();
    }

    public virtual void OpenPanel()
    {
        LeanTween.scale(gameObject, scaleAmount, 0.5f).setEaseOutBounce();
    }

    public virtual void ClosePanel()
    {
        LeanTween.scale(gameObject, new Vector3(0f, 0f, 0f), 0.5f).setEaseOutBounce();
    }
}
