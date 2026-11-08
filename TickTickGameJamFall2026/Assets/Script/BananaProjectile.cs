using UnityEngine;
using UnityEngine.UIElements;

public class BananaProjectile : MonoBehaviour
{
    public float bananaDamage = 1;
    public float projectileSpeed = 20;
    public Vector2 dir;

    private float returnTimer;
    private float returnTimerMax = 2;

    public GameObject parent;

    private Vector3 rotationSpeed = new Vector3(0,0,10);

    void Start()
    {
        returnTimer = returnTimerMax;
    }

    // Update is called once per frame
    void Update()
    {
        bananaDamage = Stats.Instance.bananaDamage;
        projectileSpeed = Stats.Instance.bananaSpeed;

    }


    private void FixedUpdate()
    {
        Vector3 randRot = new Vector3(0,0, Random.Range(-2, 2));

        BananaMovement();
        transform.Rotate(rotationSpeed + randRot);
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

        if (returnTimer < 0)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(this.gameObject);

            }
        }
    }

}
