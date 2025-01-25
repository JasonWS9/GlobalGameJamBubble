using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerManager : MonoBehaviour
{

    public float playerSpeed = 5f;
    public Rigidbody2D rb;
    public Weapon weapon;
    private int playerHealth = 5;

    Vector2 moveDirection;
    Vector2 mousePosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if(Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * playerSpeed, moveDirection.y * playerSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    private void playerDamage()
    {
        playerHealth--;
        Debug.Log(playerHealth);

        if (playerHealth <= 0)
        {
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerDamage();
        }
    }

    private void Death()
    {
        SceneChanger.GameOverScene();
    }

}
