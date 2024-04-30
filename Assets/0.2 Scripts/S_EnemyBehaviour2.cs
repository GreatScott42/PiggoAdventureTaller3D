using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyBehaviour2 : MonoBehaviour
{
    S_EnemyStats stats;
    Rigidbody rb;
    GameObject target;
    Color ogcolor;

    public float tempTime = 3;
    [SerializeField] float temp;

    private void Start()
    {
        ogcolor = GetComponent<MeshRenderer>().material.color;
        target = GameObject.Find("Jugador");
        stats = GetComponent<S_EnemyStats>();
        rb = GetComponent<Rigidbody>();

        temp = 0;
    }

    private void Update()
    {

        if (temp > 0)
        {
            temp -= Time.deltaTime;
            GetComponent<MeshRenderer>().material.color = ogcolor;
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(target.transform.position-transform.position),1);
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
    }

    private void Movement()
    {
        rb.velocity = new Vector3(stats.speed, 0, 0);
        //Debug.Log(new Vector3(stats.speed * Time.deltaTime, 0, 0) + "  " + rb.velocity);
    }
    private void DashAttack()
    {
        rb.AddForce((target.transform.position-transform.position).normalized*600,ForceMode.Force);                
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

}
