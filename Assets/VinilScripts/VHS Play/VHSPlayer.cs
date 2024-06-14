using System.Collections;
using UnityEngine;

public class playVHS : MonoBehaviour
{
    [SerializeField] private GameObject intText, tvoff, tvon, vhs;
    private bool interactable, toggle;
   [SerializeField] private Animator vhsAnim;
    [SerializeField] private float videoTime;
    [SerializeField] private float interactionDistance = 5.0f;

    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.transform.CompareTag("VHS"))
            {
                if (toggle == false && !vhs.activeSelf)
                {
                    intText.SetActive(true);
                    interactable = true;

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        intText.SetActive(false);
                        vhsAnim.SetTrigger("Play");
                        StartCoroutine(playVHSTape());
                        toggle = true;
                        interactable = false;
                    }
                }
            }
        }
        else
        {
            intText.SetActive(false);
            interactable = false;
        }
    }

    IEnumerator playVHSTape()
    {
        yield return new WaitForSeconds(1.0f);
        tvoff.SetActive(false);
        tvon.SetActive(true);
        yield return new WaitForSeconds(videoTime);
        tvoff.SetActive(true);
        tvon.SetActive(false);
    }
}
