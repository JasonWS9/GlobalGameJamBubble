using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float playerSpeed = 5f;
    public float damage = 10f;
    public float buddyDamage = 5f;
    public MyHealthBar HealthBar;
    public Slider slider;
    public GameObject buddy;


    // public void SetHealth(int health)
    // {
    //     slider.value = health;
    // }
    
    
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
        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        // if (Input.GetMouseButtonDown(0))
        // {
        //     TakeDamage(1);
        //
        // }
        //
        // void TakeDamage(int damage)
        // {
        //     currentHealth -= damage;
        //     HealthBar.SetHealth(currentHealth);
        // }
        
        
        
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

    public void playerDamage()
    {
        playerHealth-= 10; 
        Debug.Log(playerHealth);
        HealthBar.SetHealth(playerHealth); 

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
        if (collision.gameObject.CompareTag("EnemyProjectile"))
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

    public void AddBuddy()
    {
        Instantiate(buddy, Vector2.zero, Quaternion.identity);
    }

}
