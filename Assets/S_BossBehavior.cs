using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    bool playonce;
    public GameObject explosion;
    void Start()
    {
        playonce = false;
        wave = 1;
        currentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playonce)
        {
            GetComponent<AudioSource>().clip = GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().jefe;
            GetComponent<AudioSource>().Play();
            playonce = true;
        }
        transform.LookAt(GameObject.Find("Jugador").transform);
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (wave == 1)
        {            
            currentEnemy = enemy1Prefab;
            spawnMinions();
        }else if (wave==2)
        {
           
            currentEnemy = enemy2Prefab;
            spawnMinions();
        }

        if (totalEnemies == 0 && wave == 1 && currentWaypoint >= 2)
        {
            playonce = false;
            wave = 2;
            currentWaypoint = 0;
        }
        //muerte jefe
        if (totalEnemies == 0 && wave == 2 && currentWaypoint >= 2)
        {
            GetComponent<AudioSource>().clip = GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().explosionsound;
            GetComponent<AudioSource>().Play();
            //transform.localScale *= 6;
            Instantiate(explosion, transform);
            StartCoroutine(dead());
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
    IEnumerator dead()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Sc_Creditos");
        Destroy(gameObject);

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
