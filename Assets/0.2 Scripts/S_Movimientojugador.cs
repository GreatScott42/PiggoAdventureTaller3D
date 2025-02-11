using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class S_Movimientojugador : MonoBehaviour
{
    public float speed = 1.0f;
    public float jumpForce = 1.0f;

    [SerializeField] private bool canJump = false;

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
        moveDirection = new Vector3(Input.GetAxis("Horizontal")  ,0f, Input.GetAxis("Vertical")).normalized;

        float actualSpeed = Time.deltaTime * speed;
        rb.MovePosition(transform.position + new Vector3(moveDirection.x * actualSpeed, 0, moveDirection.z * actualSpeed));

        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            canJump = false;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground") && 
            collision.transform.position.y + this.gameObject.transform.localScale.y/2 < this.gameObject.transform.position.y)
        {
            canJump = true;
        }
    }
}
