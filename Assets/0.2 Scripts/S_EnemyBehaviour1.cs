using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class S_EnemyBehaviour1 : MonoBehaviour
{
    S_EnemyStats stats;
    Rigidbody rb;
    Color Colormain;
    MeshRenderer meshren;

    //Datos del sensor
    public GameObject sensor;
    private Vector3 sensorPosition;

    //Datos de stats edibles
    public float attackTime = 5;
    public float invencibleTime = 5;

    //Variables relacionadas con la detección del jugador
    GameObject player;
    public float rangeDamage = 5;
    [SerializeField] private float distancePlayer;

    private Animator animator;

    private bool moverse;
    public GameObject explosion;
    GameObject vida1;
    GameObject vida2;
    GameObject vida3;

    private void Start()
    {
        vida1 = transform.GetChild(0).gameObject;
        vida2 = transform.GetChild(1).gameObject;
        vida3 = transform.GetChild(2).gameObject;
        moverse = true;
        animator = GameObject.Find("Animesqueleto").GetComponent<Animator>();
        stats = GetComponent<S_EnemyStats>();
        rb = GetComponent<Rigidbody>();
        meshren = GetComponent<MeshRenderer>();

        Colormain = meshren.material.color;
        player = GameObject.FindGameObjectWithTag("Player");

        sensorPosition = sensor.transform.localPosition;
    }

    private void Update()
    {
        if (stats.life==2)
        {
            Destroy(vida3);
        }else if (stats.life==1)
        {
            Destroy(vida2);
        }
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            GetDamage(1);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            knockback();
        }

        if(stats.isAttack)
        {
            sensor.SetActive(true);
        }

        else
        {
            sensor.SetActive(false);
        }

        GraphicsUpdate();
    }

    private void FixedUpdate()
    {        
        distancePlayer = Vector3.Distance(transform.position,player.transform.position);
        //Debug.Log(distancePlayer);
        if (!stats.canMove)
        {
            rb.velocity = Vector3.zero;
        }
        //PODRIA CAUSAR BUGS ATENTO LOCO&& !stats.isAttack
        else if (distancePlayer < rangeDamage && stats.canAttack)
        {
            stats.canMove = false;
            StartCoroutine(Attack1Enemy1());
        }

        else
        {
            Movement();
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z)), 1);
        }
    }

    private void GraphicsUpdate()
    {
        if (stats.isAttack)
        {
            meshren.material.color = Color.blue;
            return;
        }

        if (stats.isInvulnerable)
        {
            meshren.material.color = new Color(1,0,1);
            return;
        }

        meshren.material.color = Colormain;
    }


    private void Movement()
    {
        if (moverse)
        {
            Vector3 directionPlayer = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z).normalized;
            rb.velocity = new Vector3(directionPlayer.x * stats.speed, rb.velocity.y, directionPlayer.z * stats.speed);
            animator.SetBool("attack", false);
        }
        
        
        /*if (rb.velocity == Vector3.zero)
        {
            animator.SetBool("run",false);
        }
        else
        {
            animator.SetBool("run", true);
        }*/
    }

    private void GetDamage(int dmg)
    {
        if (!stats.isInvulnerable) 
        { 
            StopAllCoroutines();

            stats.life -= dmg;
            knockback();
            if (stats.life <= 0)
                DeadSelf();

            else
            {
                //REINICIAR TODOS LOS PARAMETROS PARA EVITAR ERRORES 
                stats.isAttack = false;
                stats.canMove = true;
                stats.canAttack = false;

                stats.isInvulnerable = true;
                StartCoroutine(Invulnerability());
            }
        }

    }

    void knockback()
    {
        Vector3 pushDirection = player.transform.position-transform.position;
        pushDirection = pushDirection.normalized;
        Debug.Log("pushdirection: "+pushDirection);
        pushDirection.y = -0.5f;
        //force
        //ForceMode.Acceleration
        //ForceMode.Impulse
        //ForceMode.VelocityChange
        StartCoroutine(moverseagain());
        rb.AddForce(-pushDirection*500f,ForceMode.Force);
    }

    private void DeadSelf()
    {
        //Instantiate(GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().enemyExplosion,transform.position,Quaternion.identity);
        Instantiate(explosion,transform.position,Quaternion.identity);
        //GetComponent<MeshRenderer>().enabled = false;
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        //Destroy(gameObject);
        StartCoroutine(dead());
    }
    IEnumerator moverseagain()
    {
        moverse = false;
        yield return new WaitForSeconds(1.5f);
        moverse = true;

    }
    IEnumerator dead()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    IEnumerator Attack1Enemy1()
    {
        yield return new WaitForSeconds(attackTime/2);
        stats.isAttack = true;
        animator.SetBool("attack",true);

        //Codigo donde le hace daño al jugador

        yield return new WaitForSeconds(attackTime / 2);
        stats.isAttack = false;
        animator.SetBool("attack", false);
        stats.canMove = true;
    }

    IEnumerator Invulnerability()
    {
        yield return new WaitForSeconds(1);
        stats.canAttack = true;

        yield return new WaitForSeconds(invencibleTime);
        stats.isInvulnerable = false;
    }
}