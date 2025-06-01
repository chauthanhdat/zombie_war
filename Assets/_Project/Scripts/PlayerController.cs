using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float rotationSpeed = 10f;
    public FixedJoystick fixedJoystick;

    [Header("Components")]
    public Animator animator;
    public Rigidbody rb;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(fixedJoystick.Horizontal, 0, fixedJoystick.Vertical);
        direction.Normalize();

        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);
        }

        rb.linearVelocity = new Vector3(fixedJoystick.Horizontal * speed, rb.linearVelocity.y, fixedJoystick.Vertical * speed);

        animator.SetFloat("Velocity", direction.magnitude);
    }
}
