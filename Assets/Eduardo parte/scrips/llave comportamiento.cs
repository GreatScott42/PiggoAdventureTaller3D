using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llavecomportamiento : MonoBehaviour
{
    public GameObject Objetollave;
    public GameObject ColliderPuerta;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ColliderPuerta.gameObject.SetActive(false);
            Destroy(Objetollave);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
