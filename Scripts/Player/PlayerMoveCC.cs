using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCC : MonoBehaviour
{
    public CharacterController cc;

    private float x, z;
    public float speed = 10f;
    private float gravity = -9.81f;
    Vector3 velocity;

    public Transform groundCheck;
    public float radius = 0.3f;
    public LayerMask groundMask;
    public float jumpForce;

    private bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, radius, groundMask);
        // Representación de la gravedad al prescindir de Rigidbody
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        cc.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

    }
}
