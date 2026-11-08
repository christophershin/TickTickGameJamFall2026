using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, IDamagable
{


    private CharacterController controller;
    Vector2 moveInput;
    Vector2 velocity;

    float health = 10;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {

        Vector2 move = new Vector2(moveInput.x, moveInput.y);
        controller.Move(move * Stats.Instance.playerSpeed * Time.deltaTime);

    }


    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;

        if(health<=0)
        {
            Debug.Log("dead");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            float dmg = collision.gameObject.GetComponent<Tick>().damage;
            TakeDamage(dmg);
        }
    }
}
