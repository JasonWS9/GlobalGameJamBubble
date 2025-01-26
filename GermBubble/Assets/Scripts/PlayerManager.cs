using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public int maxHealth = 5;
    public float playerSpeed = 5f;
    public float damage = 10f;

    public FireType fireType = FireType.Bullet;
    
    public Rigidbody2D rb;
    public Weapon weapon;
    public int playerHealth = 5;
    

    Vector2 moveDirection;
    Vector2 mousePosition;

    public static PlayerManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

    }

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
            switch (fireType)
            {
                case FireType.Bullet:
                    weapon.FireBullet();
                    break;
                case FireType.Beam:
                    weapon.FireBeam();
                    break;
            }
            
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

    public enum FireType
    {
        Bullet, Beam
    }

}
