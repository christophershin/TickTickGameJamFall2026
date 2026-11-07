using UnityEngine;

public class BananaProjectile : MonoBehaviour
{

    public float projectileSpeed = 20;
    public Vector2 dir;

    private float returnTimer;
    private float returnTimerMax = 2;

    public GameObject parent;

    void Start()
    {
        returnTimer = returnTimerMax;
    }

    // Update is called once per frame
    void Update()
    {


    }


    private void FixedUpdate()
    {
        BananaMovement();
    }


    void BananaMovement()
    {
        returnTimer -= Time.deltaTime;


        if (returnTimer > 0)
        {
            GetComponent<Rigidbody2D>().linearVelocity = dir.normalized * projectileSpeed;
        }
        else
        {
            Vector2 playerdir = parent.transform.position - transform.position;


            GetComponent<Rigidbody2D>().linearVelocity = playerdir.normalized * (projectileSpeed*1.5f);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");


        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("hit");
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

}
