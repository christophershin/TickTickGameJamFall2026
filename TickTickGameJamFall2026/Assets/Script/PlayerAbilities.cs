using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilities : MonoBehaviour
{

    public Camera cam;
    private Vector2 mouseWorldPosition;

    [SerializeField]
    GameObject banana, GlorpCat;

    private float bananaTimer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject cat = Instantiate(GlorpCat, transform.position + new Vector3(10,0,0), Quaternion.identity);
        cat.GetComponent<GlorpCat>().player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        bananaTimer -= Time.deltaTime;
        


        if(bananaTimer<=0)
        {
            fireBanana(Stats.Instance.bananaSpeed);

            bananaTimer = Stats.Instance.bananaShotMaxTimer;
        }

    }


    void fireBanana(float projSpeed)
    {

        // get direction to mouse
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos3D = cam.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, Mathf.Abs(cam.transform.position.z)));
        mouseWorldPosition = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);


        for (int i = 0; i < Stats.Instance.bananaCount; i++)
        {
            float rotAmount = 3 * Stats.Instance.bananaCount;
            Vector2 randRot = new Vector2(Random.Range(-rotAmount, rotAmount), Random.Range(-rotAmount, rotAmount));

            GameObject bana = Instantiate(banana, transform.position, transform.rotation);
            bana.GetComponent<BananaProjectile>().parent = this.gameObject;
            bana.GetComponent<BananaProjectile>().dir = (mouseWorldPosition - (Vector2)transform.position) + randRot;
            bana.GetComponent<BananaProjectile>().projectileSpeed = projSpeed;
        }
    }

}
