using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI_1 : MonoBehaviour
{

    [SerializeField] GameObject Player;
    PlayerMovement playerMovement;
    NavMeshAgent agent;

    [SerializeField] LayerMask whatIsGround;

    //Dormant means the enemy would be just wandering around the house, can't chase or kill the player
    Vector3 walkPoint;
    bool isWalkPointSet;
    [SerializeField] float walkPointRange;
    float playerSprintTime = 0;
    bool isPlayerSprinting;
    Vector3 playerSpeed;
    bool inRevolveState;

    internal bool objectFell;

    //revolve
    [SerializeField] float distance = 5f; // Distance from the player
    [SerializeField] float rotateSpeed = 5f;
    float enemyRevolveTimer = 0f;
    [SerializeField] float enemyRevolveTime;

    private float angle = 0f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerMovement = Player.GetComponent<PlayerMovement>();

      
    }

  
    void Update()
    {
        
       playerSpeed = new Vector3(playerMovement.moveDirection.x , 0 , playerMovement.moveDirection.z);
        isPlayerSprinting = playerMovement.isSprinting;
        if (!isPlayerSprinting && playerSprintTime<=5f)
        {
            DormantState();
            playerSprintTime = 0f;
        }
        if (isPlayerSprinting)
        {
            playerSprintTime += Time.deltaTime;

        }
         if(playerSprintTime > 5 || objectFell)
        {
            ChaseState();
        }
        if(inRevolveState)
        {
            RevolveState();
        }
       
    }


    void DormantState()
    {
        if(!isWalkPointSet)
        {
            SearchWalkPoint();
        }

        if (isWalkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f)
        {
            isWalkPointSet = false;
        }
    }

    void SearchWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange,walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
       
        if(Physics.Raycast(walkPoint , -transform.up, 2 , whatIsGround))
        {
            isWalkPointSet = true;
        }
    }
    void ChaseState()
    {
        if (!inRevolveState)
        {
            walkPoint = Player.transform.position;
            agent.SetDestination(walkPoint);
            agent.speed = 10f;
            if ((transform.position - walkPoint).magnitude < 8f)
            {
                if (isPlayerSprinting)
                {
                    agent.speed = 25f;
                    KillState();

                }
                if (playerSpeed.x < 1f && playerSpeed.z < 1f)
                {
                    // agent.speed = 5f;
                    inRevolveState = true;
                    RevolveState();
                }
            }
        }
    }

    void RevolveState()
    {   
        agent.enabled = false;  
        transform.RotateAround(Player.transform.position , Vector3.up , rotateSpeed * Time.deltaTime);
        enemyRevolveTimer += Time.deltaTime;
        if(enemyRevolveTimer  > enemyRevolveTime)
        {
            agent.enabled = true;   
            agent.Warp(transform.position);
            enemyRevolveTimer = 0;
            inRevolveState = false;
            playerSprintTime = 0;
            objectFell = false;
        }
    }

    void KillState()
    {
        Debug.Log("Kill");
    }

}
