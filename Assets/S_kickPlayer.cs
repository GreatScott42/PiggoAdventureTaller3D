using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_kickPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Jugador");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag.Equals("Player"))
        {
            knockback();
        }*/
    }
    /*void knockback()
    {
        Vector3 pushDirection = transform.position - player.transform.position;
        pushDirection = pushDirection.normalized;
        Debug.Log("pushdirection: " + pushDirection);
        pushDirection.y = -0.5f;
        //force
        //ForceMode.Acceleration
        //ForceMode.Impulse
        //ForceMode.VelocityChange
        StartCoroutine(GameObject.Find("Jugador").GetComponent<S_PlayerControllerCombat>().moversagain());
        //player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().AddForce(-pushDirection * 700f, ForceMode.Force);
    }*/
    /*IEnumerator moversagain()
    {
        GameObject.Find("Jugador").GetComponent<S_PlayerControllerCombat>().movers = false;
        yield return new WaitForSeconds(1);
        GameObject.Find("Jugador").GetComponent<S_PlayerControllerCombat>().movers = true;

    }*/
}
