using UnityEngine;
using UnityEngine.Rendering;

public class MiniPlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float playerSpeed = 5f;
    public Rigidbody2D rb;
    public Weapon weapon;
    
    public Transform player;
    public float radius;
    public Vector2 offset;

    Vector2 moveDirection;
    Vector2 mousePosition;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = Random.insideUnitCircle.normalized * radius;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(player.position.x - offset.x, player.position.y - offset.y);
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if(Input.GetMouseButtonDown(0))
        {
            weapon.FireBullet();
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * PlayerManager.Instance.playerSpeed, moveDirection.y * PlayerManager.Instance.playerSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerManager.Instance.playerDamage();
        }
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            PlayerManager.Instance.playerDamage();
        }
    }
}