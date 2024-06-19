using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_PlayerControllerCombat : MonoBehaviour
{
    // Start is called before the first frame update
    private S_PlayerStats stats;
    private Vector3 moveDirection;
    private Vector3 lastMoveDirection;
    private Rigidbody rb;

    private S_Detect colWeapon;
    private MeshRenderer meshWeapon;

    private float groundCheckDistance;

    int enemiesTotal;

    void Start()
    {
        
        Debug.Log("enemigos en la escena: "+enemiesTotal);
        stats = GetComponent<S_PlayerStats>();
        rb = GetComponent<Rigidbody>();

        colWeapon = GameObject.FindWithTag("Weapon").GetComponent<S_Detect>();
        meshWeapon = colWeapon.GetComponent<MeshRenderer>();
        meshWeapon.enabled = false;

        groundCheckDistance = (GetComponent<CapsuleCollider>().height / 2) + 0.05f;
    }

    private void FixedUpdate()
    {
        if(stats.canMove)
            Movement();

        Rotation();
        //Attack();
    }

    //Bloque de Movimiento
    private void Movement()
    {
        //CODIGO DE MOVIMIENTO DEL PERSONAJE
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
        float actualSpeed = Time.deltaTime * stats.speed;
        
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
            rb.AddForce(new Vector3(0, stats.jumpForce, 0), ForceMode.Impulse);
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
        rb.AddForce(lastMoveDirection * stats.dashForce, ForceMode.Impulse);

        yield return new WaitForSeconds(stats.dashCoolDown);

        stats.canMove = true;
        rb.velocity = Vector3.zero;
    }

    //Bloque de Combate
    private void Attack()
    {
        if(Input.GetKeyDown(KeyCode.J) && stats.canAttack)
        {
            StartCoroutine(Attacking());
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            foreach(GameObject a in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(a);
            }
            
        }
    } 
    IEnumerator Attacking()
    {
        meshWeapon.enabled = true;

        foreach (GameObject t in colWeapon.GetList())
        {
            if (t != null)
            {
                t.SendMessage("GetDamage", stats.dmgAtack);
                print("Se ha detectado" + t.name);
            }
        }

        stats.canAttack = false;
        stats.isAttack = true;

        yield return new WaitForSeconds(stats.attackCoolDown);

        meshWeapon.enabled = false;

        stats.canAttack = true;
        stats.isAttack = false;
    }

    private void GetDamage(int dmg)
    {
        if (!stats.isInvulnerable)
        {
            StopAllCoroutines();

            stats.life -= dmg;
            if (stats.life <= 0)
                print("El jugador se ha eliminado");

            else
            {
                //REINICIAR TODOS LOS PARAMETROS PARA EVITAR ERRORES 
                stats.isAttack = false;
                stats.canMove = false;
                stats.canAttack = false;

                stats.isInvulnerable = true;
                StartCoroutine(Invulnerability());
            }
        }

    }

    IEnumerator Invulnerability()
    {
        yield return new WaitForSeconds(1f);
        stats.canMove = true;
        stats.canAttack = true;

        yield return new WaitForSeconds(stats.invencibleTime);
        stats.isInvulnerable = false;
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
    private void CombToExpl()
    {
        enemiesTotal = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log(enemiesTotal);
        if (GameObject.FindGameObjectWithTag("Boss")==null&&enemiesTotal<=0)
        {            
            SceneManager.LoadScene("Sc_EscenaExploracion");
        }
    }

    void Update()
    {
        CombToExpl();
        Attack();
    }
}
