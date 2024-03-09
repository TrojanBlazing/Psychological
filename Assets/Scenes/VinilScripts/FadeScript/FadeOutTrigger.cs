using UnityEngine;

public class FadeOutTrigger : MonoBehaviour
{
    public FadingScript fadingScript; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fadingScript.FadeOut();
        }
    }
}
