using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float rotationSpeed = 10f;
    public FloatingJoystick floatingJoystick;

    [Header("Components")]
    public Animator animator;
    public Rigidbody rb;

    private bool isFiring = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Fire");
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(floatingJoystick.Horizontal, 0, floatingJoystick.Vertical);
        direction.Normalize();

        if (direction.magnitude > 0.1f)
        {
            Debug.LogError("Rotate");
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);
        }

        rb.linearVelocity = new Vector3(floatingJoystick.Horizontal * speed, rb.linearVelocity.y, floatingJoystick.Vertical * speed);

        animator.SetFloat("Velocity", direction.magnitude);
    }
}
