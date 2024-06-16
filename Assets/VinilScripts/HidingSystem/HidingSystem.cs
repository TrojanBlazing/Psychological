using UnityEngine;

public class HidingSystem : MonoBehaviour
{
    public float rayDistance = 2.0f;
    private bool isHiding = false;
    private PlayerMovement playerController;
    private Camera playerCamera;
    private GameObject currentHidingSpot;
    //[SerializeField]
   // private Animator anim;

 
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        playerController = GetComponent<PlayerMovement>();
        playerCamera = Camera.main; 
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isHiding)
            {
                ExitHidingSpot();
            }
            else
            {
                RaycastHit hit;
                Vector3 raycastOrigin = playerCamera.transform.position;
                Vector3 raycastDirection = playerCamera.transform.forward;

                if (Physics.Raycast(raycastOrigin, raycastDirection, out hit, rayDistance))
                {
                    GameObject hitObject = hit.collider.gameObject;

                    
                    if (IsHidingSpot(hitObject))
                    {
                        
                        Vector3 toHidingSpot = hitObject.transform.position - transform.position;
                        float angle = Vector3.Angle(transform.forward, toHidingSpot);
                        float maxAngle = 90f; 

                        if (angle <= maxAngle)
                        {
                            EnterHidingSpot(hitObject);
                        }
                        else
                        {
                            Debug.Log("Player is not facing the hiding spot.");
                        }
                    }
                }
            }
        }
    }

    bool IsHidingSpot(GameObject obj)
    {
        if (obj.CompareTag("HidingSpot"))
        {
            return true;
        }

      
        if (obj.transform.parent != null && obj.transform.parent.CompareTag("HidingSpot"))
        {
            return true;
        }

        return false;
    }

    void EnterHidingSpot(GameObject hidingSpot)
    {
        
        if (isHiding)
        {
            return;
        }

      
        Transform hidingPosition = hidingSpot.transform.Find("HidingPos");

        if (hidingPosition != null)
        {

            playerController.enabled = false;

            originalPosition = transform.position;
            originalRotation = transform.rotation;


         
            transform.position = hidingPosition.position;
            transform.rotation = hidingPosition.rotation;
            

            isHiding = true;
            currentHidingSpot = hidingSpot;
        }
        else
        {
            Debug.LogError("No HidingPosition found in the hiding spot!");
        }
    }

    void ExitHidingSpot()
    {
       
        if (!isHiding || currentHidingSpot == null)
        {
            return;
        }

       
        playerController.enabled = true;

        
        currentHidingSpot = null;

       
        transform.position = originalPosition;
        transform.rotation = originalRotation;
      

        isHiding = false;
    }
}
