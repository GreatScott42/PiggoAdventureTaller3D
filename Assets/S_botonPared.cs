using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_botonPared : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject explosion;
    void Start()
    {
        explosion = GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().explosion;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().botonesCorrectosApretados >= 2&&GameObject.Find("bomb")!=null)
        {
            Camera.main.GetComponent<S_camara>().mirarBomba = true;
            GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().botonesCorrectosApretados = 0;
            GameObject.Find("b1").GetComponent<MeshRenderer>().material.color = Color.yellow;
            GameObject.Find("b2").GetComponent<MeshRenderer>().material.color = Color.yellow;
            //playerposog 43.5 3 -7.67
            if (GameObject.Find("bomb") == null)
                return;
            StartCoroutine(explosion2());
            
        }

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
            GetComponent<AudioSource>().clip = GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().buttonsound;
            GetComponent<AudioSource>().Play();
            GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().botonesCorrectosApretados++;
        }
    }
    IEnumerator explosion2()
    {
        foreach (GameObject a in GameObject.FindGameObjectsWithTag("Boton"))
        {
            if (a.GetComponent<MeshRenderer>().material.color == Color.yellow)
            {
                a.GetComponent<BoxCollider>().isTrigger = false;
                a.GetComponent<MeshRenderer>().material.color = Color.blue;
                
            }
            //a.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        yield return new WaitForSeconds(1);
        Destroy(GameObject.Find("crate"));
        Destroy(GameObject.Find("crate2"));
        Destroy(GameObject.Find("crate3"));
        GetComponent<AudioSource>().clip = GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().explosionsound;
        GetComponent<AudioSource>().Play();
        Instantiate(explosion, GameObject.Find("bomb").transform.position, Quaternion.identity);
        Destroy(GameObject.Find("bomb"));
    }
}
