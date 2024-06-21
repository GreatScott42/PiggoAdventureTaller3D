using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_camara : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; 
    public Vector3 offset;
    void Start()
    {
        target = GameObject.Find("Jugador").GetComponent<Transform>();
        //offset = new Vector3(0,9.66f,-10.8f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position-GameObject.Find("Jugador").GetComponent<Transform>().position);
    }
    void LateUpdate()
    {        
        transform.position = target.position + offset;
    }
}
