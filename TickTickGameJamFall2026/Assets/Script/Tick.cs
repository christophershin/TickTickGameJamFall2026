using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tick : MonoBehaviour, IDamagable
{
    [HideInInspector]
    public GameObject player;
    public float moveSpeed = 10;
    public float health = 5;
    public float damage = 2;

    public List<Sprite> sprites;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveTowardsplayer();
    }

    void moveTowardsplayer()
    {

        Vector3 playerdir = player.transform.position - transform.position;

        if(player!=null)
        {
            transform.position += playerdir.normalized * moveSpeed * Time.deltaTime;
        }
    }
    


    public void TakeDamage(float dmg)
    {
        
        health -= dmg;
        StartCoroutine(damageTick());

        if (health<=0)
        {
            LevelManager.Instance.GainExp();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            float dmg = collision.gameObject.GetComponent<BananaProjectile>().bananaDamage;

            TakeDamage(dmg);
            Debug.Log(dmg);
        }
    }

    IEnumerator damageTick()
    {

        GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(0.1f);

        GetComponent<SpriteRenderer>().color = Color.white;
    }




}
