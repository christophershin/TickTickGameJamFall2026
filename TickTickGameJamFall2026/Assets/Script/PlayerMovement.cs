using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{


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
        controller.Move(move * Stats.Instance.playerSpeed * Time.deltaTime);

    }


    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
