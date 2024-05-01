using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MovPlayerComb : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    private Vector3 moveDirection;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();
        Rotation();
    }

    private void Movement()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
        float actualSpeed = Time.deltaTime * speed;
        rb.MovePosition(transform.position + new Vector3(moveDirection.x * actualSpeed, 0, moveDirection.z * actualSpeed));
    }


    private void Rotation()
    {
        //esto es para rotar al jugador sin alterar el movimiento
        if (moveDirection == Vector3.zero) { return; }
        
        Quaternion rotation = Quaternion.LookRotation(moveDirection);

        //hacerlo mas lento, porque va muy rapido
        rotation = Quaternion.RotateTowards(transform.rotation, rotation, 360 * Time.deltaTime);

        //aplicar rotacion y movimiento
        rb.MoveRotation(rotation);
    }

    void Update()
    {
        
    }
}
