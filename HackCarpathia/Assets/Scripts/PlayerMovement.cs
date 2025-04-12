using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] Transform cam;
    [SerializeField] float speed = 6f;
    private float minSpeed = 0.1f;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;

    [SerializeField] float lookSpeedX = 2f;
    [SerializeField] float lookSpeedY = 2f;
    [SerializeField] float upperLimit = -80f;
    [SerializeField] float lowerLimit = 80f; 

    private float rotationX = 0f;

    public bool IsWalking { get; set; }
    public bool IsSprinting { get; set; }

    private void Update()
    {
        MovePlayer();
        RotateCamera();
    }

    public void MovePlayer()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        bool sprintInput = Input.GetKey(KeyCode.LeftShift);

        Vector3 moveDirection = Vector3.zero;

        IsWalking = false;
        IsSprinting = false;

        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (direction.magnitude >= minSpeed)
        {
            Vector3 camForward = cam.forward;
            camForward.y = 0;
            camForward.Normalize();

            Vector3 camRight = cam.right;
            camRight.y = 0;
            camRight.Normalize();

            moveDirection = camForward * verticalInput + camRight * horizontalInput;

            characterController.Move(moveDirection.normalized * speed * Time.deltaTime);
            IsWalking = true;
        }

        if (sprintInput)
        {
            characterController.Move(moveDirection.normalized * speed * Time.deltaTime);
            IsWalking = false;
            IsSprinting = true;
        }
    }

    public void SetPlayerPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationX -= mouseY * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, upperLimit, lowerLimit);

        cam.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX * lookSpeedX);
    }
}
