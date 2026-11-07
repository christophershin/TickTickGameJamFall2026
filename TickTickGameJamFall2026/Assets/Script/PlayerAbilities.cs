using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilities : MonoBehaviour
{

    public Camera cam;
    private Vector2 mouseWorldPosition;

    [SerializeField]
    GameObject banana;

    private float bananaTimer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        bananaTimer -= Time.deltaTime;
        


        if(bananaTimer<=0)
        {
            fireBanana(Stats.Instance.bananaSpeed);

            bananaTimer = Stats.Instance.bananaMaxTimer;
        }

    }


    void fireBanana(float projSpeed)
    {

        // get direction to mouse
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos3D = cam.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, Mathf.Abs(cam.transform.position.z)));
        mouseWorldPosition = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);


        GameObject bana = Instantiate(banana, transform.position, transform.rotation);
        bana.GetComponent<BananaProjectile>().parent = this.gameObject;
        bana.GetComponent<BananaProjectile>().dir = mouseWorldPosition - (Vector2)transform.position;
        bana.GetComponent<BananaProjectile>().projectileSpeed = projSpeed;
    }

}
