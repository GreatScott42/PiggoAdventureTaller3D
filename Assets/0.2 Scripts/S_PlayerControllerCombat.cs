using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerControllerCombat : MonoBehaviour
{
    // Start is called before the first frame update
    private S_PlayerStats stats;
    private Vector3 moveDirection;
    private Vector3 lastMoveDirection;
    private Rigidbody rb;

    private S_Detect colWeapon;

    private float groundCheckDistance;

    void Start()
    {
        stats = GetComponent<S_PlayerStats>();
        rb = GetComponent<Rigidbody>();

        colWeapon = GameObject.FindWithTag("Weapon").GetComponent<S_Detect>();

        groundCheckDistance = (GetComponent<CapsuleCollider>().height / 2) + 0.05f;
    }

    private void FixedUpdate()
    {
        if(stats.canMove)
            Movement();

        Rotation();
        Attack();
    }

    private void Movement()
    {
        //CODIGO DE MOVIMIENTO DEL PERSONAJE
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
        float actualSpeed = Time.deltaTime * stats.Speed;
        
        if(moveDirection == Vector3.zero)
            rb.velocity = new Vector3(0f,rb.velocity.y,0f);
        else
            lastMoveDirection = moveDirection;
        rb.MovePosition(transform.position + new Vector3(moveDirection.x * actualSpeed, 0, moveDirection.z * actualSpeed));


        //CODIGO DE SALTO DEL PERSONAJE      
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, groundCheckDistance))
        {
            stats.canJump = true;
            stats.canDash = true;
        }

        else
            stats.canJump = false;

        if (Input.GetKey(KeyCode.Space) && stats.canJump)
        {
            rb.AddForce(new Vector3(0, stats.JumpForce, 0), ForceMode.Impulse);
            stats.canJump = false;
        }


        //DASH
        if (Input.GetKey(KeyCode.E) && stats.canDash)
            StartCoroutine(Dash());
    }

    IEnumerator Dash()
    {
        stats.canDash = false;
        stats.canMove = false;
        rb.AddForce(lastMoveDirection * stats.DashForce, ForceMode.Impulse);

        yield return new WaitForSeconds(stats.DashCoolDown);

        stats.canMove = true;
        rb.velocity = Vector3.zero;
    }


    private void Attack()
    {
        if(Input.GetKeyDown(KeyCode.J) && stats.canAttack)
        {
            foreach(GameObject t in colWeapon.GetList())
            {
                t.SendMessage("GetDamage",stats.DmgAtack);
            }
        }
    }


    // ESTA WEA SE VA A TENER QUE QUITAR
    private void Rotation()
    {
        //esto es para rotar al jugador sin alterar el movimiento
        if (rb.rotation == Quaternion.LookRotation(lastMoveDirection)) { return; }
        
        Quaternion rotation = Quaternion.LookRotation(lastMoveDirection);

        //hacerlo mas lento, porque va muy rapido
        rotation = Quaternion.RotateTowards(transform.rotation, rotation, 360 * Time.deltaTime);

        //aplicar rotacion y movimiento
        rb.MoveRotation(rotation);
    }

    void Update()
    {
        
    }
}
