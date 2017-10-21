using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private float verticalVelocity;

    public float gravity = 25.0f;
    public float jumpForce = 7.0f;

    // Use this for initialization
    private void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    private void Update()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime; // jump while grounded
            if (Input.GetKeyDown(KeyCode.W))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;// can't jump in the air
        }
        Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
        controller.Move(moveVector * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            // TODO: make it add to inventory
            Destroy(collision.gameObject);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Item"))
        {
            // TODO: make it add to inventory
            Destroy(hit.gameObject);
        }
    }
}
