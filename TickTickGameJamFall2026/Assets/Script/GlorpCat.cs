using UnityEngine;

public class GlorpCat : MonoBehaviour
{

    [HideInInspector]
    public GameObject player;
    public float moveSpeed = 10;
    public float followDis = 10;

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
        float dis = Vector2.Distance(transform.position, player.transform.position);

        if (dis > followDis)
        {
            if (player != null)
            {
                transform.position += playerdir.normalized * moveSpeed * Time.deltaTime;
            }
        }

    }
}
