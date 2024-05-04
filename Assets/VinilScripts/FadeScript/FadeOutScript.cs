using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOutScript : MonoBehaviour
{
    public FadingScript fadingScript;
    [SerializeField]
    private int targetSceneIndex = 4;
    [SerializeField]
    private float delayBeforeTransition = 4.5f;

    private bool hasPlayerEntered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayerEntered)
        {
            fadingScript.FadeOut();
            hasPlayerEntered = true;
            StartCoroutine(LoadNextSceneAfterDelay(delayBeforeTransition));
        }
    }

    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(targetSceneIndex);
    }
}
