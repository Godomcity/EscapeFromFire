using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    Image image;

    private void Awake()
    {
        image = panel.GetComponent<Image>();
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(1));
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(0));
    }

    IEnumerator Fade(float startOrEnd)
    {
        float fadeCount = 0;

        if (startOrEnd == 0)
        {
            fadeCount = 1;
        }
        
        while (fadeCount < startOrEnd || fadeCount > startOrEnd)
        {
            image.raycastTarget = true;
            if (startOrEnd == 0)
            {
                fadeCount -= 0.01f;
            }
            else
            {
                fadeCount += 0.01f;
            }
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
            if (fadeCount > 1 || fadeCount < 0)
            {
                break;
            }
        }
        image.raycastTarget = false;
    }
}
