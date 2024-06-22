using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemigo 2, ataca con dash
public class S_EnemyBehaviour2 : MonoBehaviour
{
    S_EnemyStats stats;
    Rigidbody rb;
    Collider col;
    GameObject target;
    Color ogcolor;

        
    // el temptime se cambio a 3, para que ataque mas seguido
    public float tempTime = 3;
    [SerializeField] float temp;
    [SerializeField] float JumpForce;

    private Animator animator;

    private void Start()
    {
        animator = GameObject.Find("idlerapi").GetComponent<Animator>();

        ogcolor = GetComponent<MeshRenderer>().material.color;
        target = GameObject.FindGameObjectWithTag("Player");
        stats = GetComponent<S_EnemyStats>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

        temp = 0;
    }

    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (temp > 0)
        {
            temp -= Time.deltaTime;
            GetComponent<MeshRenderer>().material.color = ogcolor;
            
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(new Vector3(target.transform.position.x - transform.position.x, 0, target.transform.position.z - transform.position.z)),1);
        }        
        else
        {
            //stats.speed = stats.speed * -1;                        
            temp = tempTime;
            //Movement();
            DashAttack();            
        }
        if (temp <= 1)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (rb.velocity == Vector3.zero)
        {
            animator.SetBool("attack", false);
        }
        else
        {
            animator.SetBool("attack", true);
        }
    }

    private void Movement()
    {
        rb.velocity = new Vector3(stats.speed, 0, 0);
        //Debug.Log(new Vector3(stats.speed * Time.deltaTime, 0, 0) + "  " + rb.velocity);
    }
    private void DashAttack()
    {
        Vector3 dashForce= new Vector3(target.transform.position.x - transform.position.x,JumpForce, target.transform.position.z - transform.position.z);
        rb.AddForce(dashForce.normalized*stats.speed,ForceMode.Force);                
    }

    private void GetDamage(int dmg)
    {
        stats.life -= dmg;

        if (stats.life <= 0)
            DeadSelf();
    }

    private void DeadSelf()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = new Vector3(0f, rb.velocity.y,0f);
        }
    }

}
