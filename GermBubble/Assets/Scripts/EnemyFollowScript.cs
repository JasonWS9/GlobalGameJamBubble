using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowScript : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public float moveSpeed;


    public bool shoots;
    public GameObject bullet;
    public float comfyDistance;
    public float coolDown = 3f;
    public float shotspeed = 6f;

    private Vector2 shootDirection;
    private float timer = 0.0f;
    Vector2 movement;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        movement = player.position - transform.position;
        if (shoots)
        {
            // Calculate the direction vector from the center to the mouse.
            Vector3 directionToPlayer = player.position - transform.position;
        
            // Calculate the rotation while keeping the Y-axis (yaw) rotation fixed.
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, directionToPlayer);
            transform.rotation = targetRotation;
            
            shootDirection = player.position - transform.position;
            if (timer >= coolDown)
            {
                //Instantiate a canon ball
                GameObject shot = Instantiate(bullet, transform.position, Quaternion.identity);
                //Apply force
                Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
                rb.AddForce(shotspeed * shootDirection.normalized, ForceMode2D.Force);
                timer = 0.0f;
            }
            timer += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (shoots)
        {
            if (Mathf.Abs(movement.x) > Mathf.Abs(player.position.x - comfyDistance) &&
                Mathf.Abs(movement.y) > Mathf.Abs(player.position.y - comfyDistance))
                rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        }
        else
            rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            Debug.Log("Enemy destroyed");
            Destroy(gameObject);
            EnemyManager.Instance.enemyCount--;
            GameManager.Instance.increaseScore(1);
            // EnemyManager.Instance.xp+=5;
        }
        
            
    }
}