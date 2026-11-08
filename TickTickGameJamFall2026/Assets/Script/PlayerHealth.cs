using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{

    float health = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
