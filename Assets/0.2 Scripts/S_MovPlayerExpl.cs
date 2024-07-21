using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class S_MovPlayerExpl : MonoBehaviour
{
    public float speed = 1.0f;
    public float jumpForce = 1.0f;

    //El personaje puede Saltar
    [SerializeField] private bool canJump = false;
    [SerializeField] private float groundCheckDistance; 

    private Vector3 moveDirection;
    private Vector3 lastmovedirection;

    private GameObject lvl2;

    private Rigidbody rb;

    private Animator animator;

    private bool startCAM;
    private string horizontal;
    private string vertical;

    public GameObject uin2p1;
    public GameObject ui2p2;
    // Start is called before the first frame update
    void Start()
    {
        startCAM = false;
        //for (int i = 0; i < 10; i++) { Camera.main.GetComponent<Transform>().LookAt(transform); }
        
        lvl2 = GameObject.Find("Escenario2");
        animator = GameObject.Find("piggoAnim").GetComponent<Animator>();
        //GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().setTransform(transform);
        //Debug.Log("cargando transform: "+GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().getTransform().ToString());
        if (GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().getPos() != null)
        {
            //Debug.Log("aplicando tranform");
            //transform.position = GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().getPos();
            //transform.rotation = GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().getRot();
            
            GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().cargarEscenaLvl1();
        }
        else
        {
            //Debug.Log("transform no aplicado");
        }
        rb = GetComponent<Rigidbody>();

        if (GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().destroyEnemy2)
        {
            lvl2.transform.position = new Vector3(lvl2.transform.position.x, 15f, lvl2.transform.position.z);
        }

        horizontal = "Horizontal";
        vertical = "Vertical";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        moveDirection = new Vector3(Input.GetAxis(horizontal)  ,0f, Input.GetAxis(vertical)).normalized;
        if(horizontal == "Vertical")
        {
            moveDirection.z *= -1;
        }

        float actualSpeed = Time.deltaTime * speed;
        rb.MovePosition(transform.position + new Vector3(moveDirection.x * actualSpeed, 0, moveDirection.z * actualSpeed));

        
    }
    private void Update()
    {
        if (startCAM)
        {
            Camera.main.GetComponent<Transform>().LookAt(transform.position);            
        }            

        if (moveDirection == Vector3.zero && (rb.velocity.x!=0||rb.velocity.z!=0))
        {
            rb.velocity = new(0,rb.velocity.y,0);
        }


        if (moveDirection != Vector3.zero)
            lastmovedirection = moveDirection;



        Rotation();
        if (moveDirection==Vector3.zero)
        {
            animator.SetBool("running",false);
        }else
        {
            animator.SetBool("running", true);
        }
        

        groundCheckDistance = (GetComponent<CapsuleCollider>().height / 2) + 0.1f; //-> Hardcodeado

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);            
        }
            
        

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, groundCheckDistance))
        {            
            canJump = true;
            animator.SetBool("jumping", false);
        }
        else
        {            
            canJump = false;
            animator.SetBool("jumping", true);
        }


        //cargar lvl2
        if (GameObject.Find("Enemigos")==null)
        {
            if (lvl2.transform.position.y >= 16)
            {
                lvl2.transform.position = Vector3.MoveTowards(lvl2.transform.position, new Vector3(lvl2.transform.position.x, 15f, lvl2.transform.position.z), 5f*Time.deltaTime);
            }
            //Destroy(gameObject);
        }
    }
    private void Rotation()
    {
        //esto es para rotar al jugador sin alterar el movimiento
        if (rb.rotation == Quaternion.LookRotation(moveDirection)) { return; }

        Quaternion rotation = Quaternion.LookRotation(lastmovedirection);

        //hacerlo mas lento, porque va muy rapido
        rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2520 * Time.deltaTime);//2520=360*7

        //aplicar rotacion y movimiento
        rb.MoveRotation(rotation);
    }
    private void LateUpdate()
    {
        //startCAM = false;
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
    /*private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Equals("nivel2parte1"))
        {
            Camera.main.GetComponent<S_camara>().transform.LookAt(transform);
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("nivel2parte1"))
        {
            uin2p1.SetActive(true);


            Camera.main.GetComponent<S_camara>().rotar = true;            
            float a = Camera.main.GetComponent<S_camara>().offset.x;
            Camera.main.GetComponent<S_camara>().offset.x = Camera.main.GetComponent<S_camara>().offset.z;
            Camera.main.GetComponent<S_camara>().offset.z = a;
            horizontal = "Vertical";
            vertical = "Horizontal";
            StartCoroutine(camera3());
            //Camera.main.GetComponent<Transform>().LookAt(GameObject.Find("Jugador").transform);
        }
        if (other.gameObject.name.Equals("nivel2p2"))
        {
            ui2p2.SetActive(true);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("nivel2parte1"))
        {
            uin2p1.SetActive(false);

            Camera.main.GetComponent<S_camara>().rotar = false;
            Camera.main.GetComponent<S_camara>().offset = Camera.main.GetComponent<S_camara>().offsetog;
            horizontal = "Horizontal";
            vertical = "Vertical";
            StartCoroutine(camera3());
            //Camera.main.GetComponent<Transform>().LookAt(GameObject.Find("Jugador").transform);
        }
        if (other.gameObject.name.Equals("nivel2p2"))
        {
            ui2p2.SetActive(false);
        }
    }
    IEnumerator camera3()
    {
        yield return new WaitForSeconds(0.005f);
        Camera.main.GetComponent<Transform>().LookAt(GameObject.Find("Jugador").transform);
    }
}
