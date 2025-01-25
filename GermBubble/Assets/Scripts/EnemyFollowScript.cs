using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowScript : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public float moveSpeed;
    public float comfyDistance;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement = player.transform.position - transform.position;
    }

    private void FixedUpdate()
    {
        if(Mathf.Abs(movement.x) > comfyDistance && Mathf.Abs(movement.y) > comfyDistance)
            rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            Debug.Log("Enemy destroyed");
            //Destroy(gameObject);
            EnemyManager.Instance.enemyCount--;
            GameManager.Instance.score++;
            // EnemyManager.Instance.xp+=5;
        }
        
            
    }
}