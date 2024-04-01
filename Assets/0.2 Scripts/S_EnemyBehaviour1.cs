using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyBehaviour1 : MonoBehaviour
{
    S_EnemyStats stats;
    Rigidbody rb;

    public float tempTime = 10;
    [SerializeField] float temp;

    private void Start()
    {
        stats = GetComponent<S_EnemyStats>();
        rb = GetComponent<Rigidbody>();

        temp = 0;
    }

    private void Update()
    {

        if (temp > 0)
        {
            temp -= Time.deltaTime;
        }

        else
        {
            stats.speed = stats.speed * -1;
            temp = tempTime;
            Movement();
        }
    }

    private void Movement()
    {
        rb.velocity = new Vector3(stats.speed, 0, 0);
        //Debug.Log(new Vector3(stats.speed * Time.deltaTime, 0, 0) + "  " + rb.velocity);
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
