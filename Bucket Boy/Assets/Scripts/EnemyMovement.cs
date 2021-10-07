using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed = 2f;
    public float distance;
    public float chaseRange = 5f;
    private bool movingRight = true;

    public Transform groundDetection;
    private bool enemyUnaware;

    public GameObject player;

    public Vector3 direction;
    private Rigidbody2D enemyBody;
    

    private void Start() 
    {
        enemyUnaware = true;
        enemyBody = this.GetComponent<Rigidbody2D>();   
    }
    
    private void Update() 
    {
        if (enemyUnaware == true)
        {
            PatrollingPlatform();
            EnemySight();
        } else {
            ChasePlayer();
        }
        
    }

    private void PatrollingPlatform()
    {
        transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);  
        RaycastHit2D groundInfo = Physics2D.Raycast(
            groundDetection.position, 
            Vector2.down, 
            distance);  

        if (groundInfo.collider == false) 
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3( 0, -180 , 0 );
                movingRight = false;
            } else {
                transform.eulerAngles = new Vector3( 0, 0, 0 );
                movingRight = true;
            }
        }
    }

    private void EnemySight()
    {
        RaycastHit2D playerInfo = Physics2D.Raycast(
            groundDetection.position, 
            Vector2.right, 
            chaseRange);

        if (playerInfo.collider == true) 
        {
            if (playerInfo.collider.tag == "Player")
            {
                enemyUnaware = false;
            }   
        }
    }

    private void ChasePlayer()
    {
        direction = player.transform.position - transform.position;
        if (direction.x > 0)
        {
            transform.Translate(Vector2.right * enemySpeed * 1.5f * Time.deltaTime);
        } else {
            transform.Translate(Vector2.left * enemySpeed * 1.5f * Time.deltaTime);
        }
    }
    
}
