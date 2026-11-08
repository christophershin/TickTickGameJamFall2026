using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public PlayerHealth health;

    void Start()
    {
        
    }

    private void Update()
    {

        if (health.isAlive)
        {

            float horizontalInput = Input.GetAxis("Horizontal");

            float verticalInput = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);

            transform.position += moveDirection * Stats.Instance.playerSpeed * Time.deltaTime;
        }

    }

}
