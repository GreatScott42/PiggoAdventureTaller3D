using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayerComb : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    private CharacterController controller;
    private Vector3 moveDirection;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {                
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        
        moveDirection *= speed;
        moveDirection.y = rb.velocity.y;

        controller.Move(moveDirection * Time.deltaTime);
        //rb.velocity = transform.TransformDirection(moveDirection);

    }
}
