using UnityEngine;

public class LanternSwingController : MonoBehaviour
{

    [SerializeField]
    Transform playerTransform;

    
    private Animator animator;

   
    private Vector3 previousPlayerPosition;

    
    public float movementThreshold = 0.01f;

    void Start()
    {
        
        animator = GetComponent<Animator>();

        if (playerTransform != null)
        {
            previousPlayerPosition = playerTransform.position;
        }
    }

    void Update()
    {
       
        if (playerTransform != null)
        {
            Vector3 currentPlayerPosition = playerTransform.position;
            float playerMovement = (currentPlayerPosition - previousPlayerPosition).magnitude;

            if (playerMovement > movementThreshold)
            {
                
                animator.SetBool("IsMoving", true);
            }
            else
            {
                
                animator.SetBool("IsMoving", false);
            }

           
            previousPlayerPosition = currentPlayerPosition;
        }
    }
}
