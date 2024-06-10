using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_botonFalso : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            foreach (GameObject a in GameObject.FindGameObjectsWithTag("Boton"))
            {
                a.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            

            GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().botonesCorrectosApretados=0;
        }
    }
}
