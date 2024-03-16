using UnityEngine;

public class FollowPLayer : MonoBehaviour
{
     [SerializeField] float moveSpeed = 3f;
    [SerializeField]  float rotationSpeed = 3f;

    private bool isFollowingPlayer = false;
    private Transform playerTransform;


    private void Start()
    {
        
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FixedUpdate()
    {
      
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * hit.distance, Color.green);
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
            if (hit.collider.gameObject == gameObject)
            {
                isFollowingPlayer = false;
            }
            else
            {
               
                isFollowingPlayer = true;
                
            }
        }
    }

   private void FollowPlayer()
    {
        if (isFollowingPlayer)
        {

            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;


            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }    
}
