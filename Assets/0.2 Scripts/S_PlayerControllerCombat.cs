using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    private Animator animator;

    bool usingknockback;

    public bool movers;

    GameObject corazon1;
    GameObject corazon2;
    GameObject corazon3;
    GameObject corazon4;
    GameObject corazon5;
    GameObject[] corazones;

    public RawImage fondo;
    public TextMeshProUGUI text;

    void Start()
    {
        usingknockback = false;
        movers = true;
        corazon1 = GameObject.Find("heart");
        corazon2 = GameObject.Find("heart2");
        corazon3 = GameObject.Find("heart3");
        corazon4 = GameObject.Find("heart4");
        corazon5 = GameObject.Find("heart5");
        corazones = new GameObject[] { corazon1,corazon2,corazon3,corazon4,corazon5};

        animator = GameObject.Find("piggoAnim").GetComponent<Animator>();

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

    private void Movement()
    {
        Debug.Log(movers);
        if (!movers)
        {
            return;
        }
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
            animator.SetBool("jumping", false);
        }
        else
        {
            animator.SetBool("jumping", true);
            stats.canJump = false;
        }
            


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


    private void Attack()
    {
        if(Input.GetKeyDown(KeyCode.J) && stats.canAttack)
        {
            StartCoroutine(Attacking());
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(espera());
            foreach(GameObject a in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(a);
            }
            
        }
    } 
    IEnumerator Attacking()
    {
        //meshWeapon.enabled = true;
        animator.SetBool("attacking", true);

        foreach (GameObject t in colWeapon.GetList())
        {
            t.SendMessage("GetDamage", stats.dmgAtack);
            print("Se ha detectado" + t.name);
        }

        stats.canAttack = false;
        stats.isAttack = true;

        yield return new WaitForSeconds(stats.attackCoolDown);
        animator.SetBool("attacking", false);
        meshWeapon.enabled = false;

        stats.canAttack = true;
        stats.isAttack = false;
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
    
    IEnumerator espera()
    {
        yield return new WaitForSeconds(1);
    }
    public IEnumerator moversagain()
    {
        movers = false;
        yield return new WaitForSeconds(1);
        movers = true;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("collider")&&!usingknockback)
        {
            
            if (!usingknockback)
            {
                knockback(other.gameObject);
            }
        }
    }

    IEnumerator Fade(RawImage image,TextMeshProUGUI image2, float duration)
    {
        Color color = image.color;
        float startAlpha = color.a;
        float endAlpha = 1f;
        float elapsed = 0f;

        Color color2 = image2.color;
        float startAlpha2 = color.a;
        float endAlpha2 = 1f;
        float elapsed2 = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            image.color = color;            
            color2.a = Mathf.Lerp(startAlpha2, endAlpha2, elapsed / duration);
            image2.color = color2;
            yield return null;
        }

        color.a = endAlpha;
        image.color = color;
        color2.a = endAlpha2;
        image2.color = color2;
    }
    void death()
    {
        Time.timeScale = 0.2f;
        StartCoroutine(Fade(fondo,text,1));
        StartCoroutine(waits());
    }
    IEnumerator waits()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Sc_menuPrincipal");
        Time.timeScale = 1f;
    }

        void knockback(GameObject collider)
    {
        GetComponent<AudioSource>().clip = GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().golpeado;
        GetComponent<AudioSource>().Play();
        StartCoroutine(knockbackwait());
        Destroy(corazones[stats.life-1]);
        
        stats.life--;
        Debug.Log(stats.life);
        Vector3 pushDirection = collider.transform.position - transform.position;
        pushDirection = pushDirection.normalized;
        Debug.Log("pushdirection: " + pushDirection);
        pushDirection.y = -0.5f;
        //force
        //ForceMode.Acceleration
        //ForceMode.Impulse
        //ForceMode.VelocityChange
        StartCoroutine(moversagain());
        //player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        rb.AddForce(-pushDirection * 300f, ForceMode.Force);
        
    }
    IEnumerator knockbackwait()
    {
        usingknockback=true;
        yield return new WaitForSeconds(0.1f);
        usingknockback = false;
    }

    void Update()
    {        
        Attack();

        if (stats.life <= 0)
        {
            death();
        }

        if (moveDirection == Vector3.zero)
        {
            animator.SetBool("running", false);
        }
        else
        {
            animator.SetBool("running", true);
        }
    }
}
