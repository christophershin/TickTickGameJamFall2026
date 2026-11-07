using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]
    private float moveSpeed = 10;


    private CharacterController controller;
    Vector2 moveInput;
    Vector2 velocity;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {

        Vector2 move = new Vector2(moveInput.x, moveInput.y);
        controller.Move(move * moveSpeed * Time.deltaTime);

    }


    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
