using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayerComb : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    private CharacterController controller;
    private Vector3 moveDirection;
    private float fixedY;
    private Rigidbody rb;

    void Start()
    {
        fixedY = 45f;
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        //transform.eulerAngles = new Vector3(0,Input.GetAxis("Horizontal"),0);
        //if()
        //direccion a la cual se movera
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
        //moveDirection = transform.TransformDirection(moveDirection);
        

        //esto es para rotar al jugador sin alterar el movimiento
        if (moveDirection == Vector3.zero) { return; }
        //obtener rotacion del movimiento del input
        Quaternion rotation = Quaternion.LookRotation(moveDirection);
        //hacerlo mas lento, porque va muy rapido
        rotation = Quaternion.RotateTowards(transform.rotation, rotation, 360 * Time.deltaTime);
        //agregar la gravedad
        moveDirection *= speed;
        moveDirection.y = rb.velocity.y;
        //aplicar rotacion y movimiento
        rb.MoveRotation(rotation);
        rb.MovePosition(rb.position + (Quaternion.AngleAxis(fixedY, Vector3.up) * moveDirection) * 2 * Time.deltaTime);
        //controller.Move(moveDirection * Time.deltaTime);

        
        //rb.velocity = transform.TransformDirection(moveDirection);

    }

    void Update()
    {
        
    }
}
