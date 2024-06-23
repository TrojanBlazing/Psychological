using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class playVHS : MonoBehaviour
{
    [SerializeField] private GameObject intText, tvoff, tvon, vhs;
    private bool interactable, toggle;
    [SerializeField] private Animator vhsAnim;
    [SerializeField] private float videoTime;
    [SerializeField] private float interactionDistance = 5.0f;

    PlayerInputAction pa;
    private InputAction interactAction;

    private void Awake()
    {
        pa = new PlayerInputAction();
    }

    private void OnEnable()
    {
        pa.PlayerMovement.Enable();
        interactAction = pa.PlayerMovement.Interaction; 
        interactAction.performed += OnInteractionPerformed;
    }

    private void OnDisable()
    {
        interactAction.performed -= OnInteractionPerformed;
        pa.PlayerMovement.Disable();
    }

    private void Update()
    {
        if (Camera.main != null)
        {

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                if (hit.transform.CompareTag("VHS"))
                {
                    if (!toggle && !vhs.activeSelf)
                    {
                        intText.SetActive(true);
                        interactable = true;
                    }
                }
                else
                {
                    intText.SetActive(false);
                    interactable = false;
                }
            }
            else
            {
                intText.SetActive(false);
                interactable = false;
            }
        }
    }

    private void OnInteractionPerformed(InputAction.CallbackContext context)
    {
        if (interactable)
        {
            intText.SetActive(false);
            vhsAnim.SetTrigger("Play");
            StartCoroutine(playVHSTape());
            toggle = true;
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
