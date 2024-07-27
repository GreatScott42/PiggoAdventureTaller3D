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
            GetComponent<AudioSource>().clip = GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().buttonsound;
            GetComponent<AudioSource>().Play();
            foreach (GameObject a in GameObject.FindGameObjectsWithTag("Boton"))
            {
                a.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            if(GameObject.Find("b1")!=null)
                GameObject.Find("b1").GetComponent<MeshRenderer>().material.color = Color.red;
            if(GameObject.Find("b2")!=null)
                GameObject.Find("b2").GetComponent<MeshRenderer>().material.color = Color.red;
            if(GameObject.Find("b5")!=null)
                GameObject.Find("b5").GetComponent<MeshRenderer>().material.color = Color.red;
            if(GameObject.Find("b6"))
                GameObject.Find("b6").GetComponent<MeshRenderer>().material.color = Color.red;
            if(GameObject.Find("b7")!=null)
                GameObject.Find("b7").GetComponent<MeshRenderer>().material.color = Color.red;

            GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().botonesCorrectosApretados=0;
        }
    }
}
