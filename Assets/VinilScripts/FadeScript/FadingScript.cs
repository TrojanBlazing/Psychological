using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingScript : MonoBehaviour
{
    [SerializeField]
    internal float fduration = 4.8f;

    [SerializeField]
    private CanvasGroup canvasGroup;

    [SerializeField]
    private bool fadeIn = false;


   private void Start()
    {
        if(fadeIn)
        {
            FadeIn();
        }
        else
        {
            FadeOut();
        }
    }

    public void FadeIn()
    {
        StartCoroutine(FadeCanavasGroup( canvasGroup,canvasGroup.alpha,0,fduration));
    }
    public void FadeOut()
    {
        StartCoroutine(FadeCanavasGroup(canvasGroup, canvasGroup.alpha, 1, fduration));
    }



    private IEnumerator FadeCanavasGroup(CanvasGroup cg,float start,float end,float duration)
    {
        float elapsedTime = 0.0f;

        while(elapsedTime<fduration)
        {
            elapsedTime += Time.deltaTime;
            cg.alpha = Mathf.Lerp(start, end, elapsedTime / duration);
            yield return null;
        }
        cg.alpha = end;
    }




   
}


