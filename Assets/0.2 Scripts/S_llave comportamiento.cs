using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_llavecomportamiento : MonoBehaviour
{
    public GameObject Objetollave;
    public GameObject ColliderPuerta;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ColliderPuerta.gameObject.SetActive(false);
            GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().usedKey = true;
            Destroy(Objetollave);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //por si ya se uso la llave antes del combate
        if (GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().usedKey == true)
        {
            ColliderPuerta.gameObject.SetActive(false);
            Destroy(Objetollave);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
