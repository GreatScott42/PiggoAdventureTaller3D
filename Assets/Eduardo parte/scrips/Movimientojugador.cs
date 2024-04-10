using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientojugador : MonoBehaviour
{
    public float Speed = 1.0f;
    public float JumpForce = 1.0f;

    private Rigidbody Physics;

    // Start is called before the first frame update
    void Start()
    {
        Physics = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * Speed);

        //salto, falta arreglar que no pueda saltar otra vez al presionar
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            Physics.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
        }
        */
    }
}
