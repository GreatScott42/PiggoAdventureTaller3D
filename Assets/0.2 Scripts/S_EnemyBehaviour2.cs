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

    public GameObject explosion;

        
    // el temptime se cambio a 3, para que ataque mas seguido
    public float tempTime = 3;
    [SerializeField] float temp;
    [SerializeField] float JumpForce;

    private Animator animator;
    GameObject attackarea;

    private void Start()
    {
        attackarea = transform.GetChild(0).gameObject;

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
        if (stats.life <= 0)
        {
            DeadSelf();
            stats.life = 9999;
        }
            

        target = GameObject.FindGameObjectWithTag("Player");
        if (temp > 0)
        {
            temp -= Time.deltaTime;
            GetComponent<MeshRenderer>().material.color = ogcolor;
            //attackarea.SetActive(false);
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(new Vector3(target.transform.position.x - transform.position.x, 0, target.transform.position.z - transform.position.z)),1);
        }        
        else
        {
            //stats.speed = stats.speed * -1;                        
            temp = tempTime;
            //attackarea.SetActive(true);
            //Movement();
            DashAttack();            
        }
        if (temp <= 1)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            animator.SetBool("attack", false);
            attackarea.SetActive(false);
        }
        else
        {
            animator.SetBool("attack", true);
            attackarea.SetActive(true);
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

        /*if (stats.life <= 0)
            DeadSelf();*/
    }

    private void DeadSelf()
    {
        //Instantiate(GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().enemyExplosion, transform.position, Quaternion.identity);
        Instantiate(explosion,transform.position,Quaternion.identity);
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        StartCoroutine(dead());
        //Destroy(gameObject);
    }
    IEnumerator dead()
    {
        yield return new WaitForSeconds(0.7f);
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
