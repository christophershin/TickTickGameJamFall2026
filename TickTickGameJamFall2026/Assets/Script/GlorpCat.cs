using UnityEngine;

public class GlorpCat : MonoBehaviour
{

    [HideInInspector]
    public GameObject player;
    public float moveSpeed = 10;

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

        if (player != null)
        {
            transform.position += playerdir.normalized * moveSpeed * Time.deltaTime;
        }
    }
}
