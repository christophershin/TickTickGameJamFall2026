using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamagable
{


    public float MaxHealth = 10;
    private float health = 10;
    public RectTransform healthbar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health >= 0)
        {
            healthbar.localScale = new Vector3(health / MaxHealth, 1, 1);
        }
        
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        

        if (health <= 0)
        {
            Debug.Log("dead");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {

            float dmg = collision.gameObject.GetComponent<Tick>().damage;
            TakeDamage(dmg);
        }
    }
}
