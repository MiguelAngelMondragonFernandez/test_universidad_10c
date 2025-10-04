using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    public Transform cameraTransform;
    private CharacterController characterController;

    private float movementSpeed = 5f;

    private float rotationSpeed = 10f;

    public float gravity = -9.81f;

    public float jumpForce = 10f;

    private float movementNormalized;



    /* Variables de animación */
    public Animator animator;

    private readonly int movementSpeedHash = Animator.StringToHash("MovementSpeed");

    private void Update_animator()
    {
        animator.SetFloat(movementSpeedHash, movementNormalized);
     }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            gravity = Physics.gravity.y * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space)) gravity = jumpForce;
        }
        else
        {
            gravity += Physics.gravity.y * Time.deltaTime;
        }

        var gravityVector = Vector3.up * gravity;

        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var cameraForward = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z);
        var cameraRight = new Vector3(cameraTransform.right.x, 0, cameraTransform.right.z);
        var direction = cameraForward * vertical + cameraRight * horizontal;
        movementNormalized = direction.normalized.magnitude;
        characterController.Move((direction.normalized * movementSpeed + gravityVector) * Time.deltaTime);

        if (direction != Vector3.zero)
        {
            var targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
            Update_animator();

    }
}
