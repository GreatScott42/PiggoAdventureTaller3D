using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class S_MovPlayerExpl : MonoBehaviour
{
    public float speed = 1.0f;
    public float jumpForce = 1.0f;

    //El personaje puede Saltar
    [SerializeField] private bool canJump = false;
    [SerializeField] private float groundCheckDistance; 

    private Vector3 moveDirection;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().setTransform(transform);
        //Debug.Log("cargando transform: "+GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().getTransform().ToString());
        if (GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().getPos() != null)
        {
            Debug.Log("aplicando tranform");
            //transform.position = GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().getPos();
            //transform.rotation = GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().getRot();
            
            GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().cargarEscenaLvl1();
        }
        else
        {
            Debug.Log("transform no aplicado");
        }
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        groundCheckDistance = (GetComponent<CapsuleCollider>().height / 2) + 0.1f; //-> Hardcodeado

        moveDirection = new Vector3(Input.GetAxis("Horizontal")  ,0f, Input.GetAxis("Vertical")).normalized;

        float actualSpeed = Time.deltaTime * speed;
        rb.MovePosition(transform.position + new Vector3(moveDirection.x * actualSpeed, 0, moveDirection.z * actualSpeed));

        if(Input.GetKeyDown(KeyCode.Space) && canJump)
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, groundCheckDistance))
            canJump = true;
        else
            canJump = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
       /*
        if(collision.gameObject.CompareTag("Ground") && 
            collision.transform.position.y + this.gameObject.transform.localScale.y/2 < this.gameObject.transform.position.y)
        {
            canJump = true;
        }*/
    }
}
