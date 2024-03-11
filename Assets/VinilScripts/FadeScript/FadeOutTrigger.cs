using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOutTrigger : MonoBehaviour
{
    public FadingScript fadingScript;
    private bool hasPlayerEntered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayerEntered)
        {
            fadingScript.FadeOut();
            hasPlayerEntered = true;
             StartCoroutine(LoadNextSceneAfterDelay(4.5f));
           
        }
    }

   
   IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
    }
}
