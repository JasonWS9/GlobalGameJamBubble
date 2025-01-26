using UnityEngine;

public class testplayer : MonoBehaviour
{

    public int MaxHealth = 100;
    public int currentHealth;
    
    public MyHealthBar MyHealthBar; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = MaxHealth;
        MyHealthBar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage(10);

        }

        void TakeDamage(int damage)
        {
            currentHealth -= damage;
            MyHealthBar.SetHealth(currentHealth);
        }
    }
}
