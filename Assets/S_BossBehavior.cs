using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BossBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] waypoints;
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject currentEnemy;
    public int currentWaypoint;
    public int wave;
    public int totalEnemies;

    void Start()
    {
        wave = 1;
        currentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameObject.Find("Jugador").transform);
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (wave == 1)
        {
            currentEnemy = enemy1Prefab;
            spawnMinions();
        }else if (wave==2)
        {
            currentEnemy=enemy2Prefab;
            spawnMinions();
        }

        if (totalEnemies == 0 && wave == 1 && currentWaypoint >= 2)
        {
            wave = 2;
            currentWaypoint = 0;
        }

        
    }

    void spawnMinions()
    {
        Debug.Log(Vector3.Distance(transform.position, waypoints[currentWaypoint].position));
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position)>1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position,5f*Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Waypoint"))
        {
            if (currentWaypoint < 3)
            {
                currentWaypoint++;
                Instantiate(currentEnemy, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
                transform.localScale = new Vector3(transform.localScale.x - 0.3f, transform.localScale.y - 0.3f, transform.localScale.z-0.3f);
            }            
        }
    }
}
