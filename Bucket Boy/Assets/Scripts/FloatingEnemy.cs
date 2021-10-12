using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnemy : MonoBehaviour
{
    public GameObject Player;
    private float distToPlayer;
    private Vector3 oldPlayerPosition;
    private Vector3 newPlayerPosition;
    public Rigidbody2D enemyBody;
    public float enemySpeed = 2f;
    private Vector3 direction;
    public float enemyPerimeterRadius = 10f;
    private Transform characterTransform;

    void Start() 
    {
        characterTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        oldPlayerPosition = characterTransform.position;    
    }
    void Update()
    {   
        EnemyPerimiter();
    }

    private void EnemyPerimiter()
    {
        characterTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        newPlayerPosition = characterTransform.position;
        distToPlayer = Vector3.Distance(newPlayerPosition, this.transform.position);
        
        // Check if player is close enough 
        // to the enemy to make the enemy initialize a chase
        if (distToPlayer < enemyPerimeterRadius)
        {
            if (newPlayerPosition.x < oldPlayerPosition.x)
            {
                //Debug.Log("MOVING LEFT");
                if (this.transform.position.x > newPlayerPosition.x)
                {
                    MoveTowardsPlayer(newPlayerPosition);
                }
            } 
            else if(newPlayerPosition.x > oldPlayerPosition.x)
            {
                //Debug.Log("MOVING RIGHT");
                if (this.transform.position.x < newPlayerPosition.x)
                {
                    MoveTowardsPlayer(newPlayerPosition);
                }
            } else {

                //Debug.Log("STANDING STILL");
            }
        }

        oldPlayerPosition = characterTransform.position;
    }

    private void MoveTowardsPlayer(Vector3 newPlayerPosition)
    {
        //Debug.Log("TOWARDS PLAYER");
        direction = (newPlayerPosition - transform.position).normalized;
        enemyBody.MovePosition(
            this.transform.position + direction * enemySpeed * Time.fixedDeltaTime);
    }
}
