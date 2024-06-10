using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_botonPared : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().botonesCorrectosApretados >= 3)
        {
            GameObject.Find("puerta2").GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GetComponent<MeshRenderer>().material.color == Color.yellow)
            {
                return;
            }
            GetComponent<MeshRenderer>().material.color = Color.yellow;

            GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().botonesCorrectosApretados++;
        }
    }
}
