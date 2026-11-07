using UnityEngine;

public class Tick : MonoBehaviour
{

    public GameObject player;
    public float moveSpeed = 10;
    public float health = 5;

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

}
