using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class S_Movimientojugador : MonoBehaviour
{
    public float speed = 1.0f;
    public float jumpForce = 1.0f;

    private Vector3 moveDirection;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;

        float actualSpeed = Time.deltaTime * speed;
        rb.MovePosition(transform.position + new Vector3(moveDirection.x * actualSpeed, 0, moveDirection.z * actualSpeed));


        //salto, falta arreglar que no pueda saltar otra vez al presionar
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            Physics.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
        }
        */
    }
}
