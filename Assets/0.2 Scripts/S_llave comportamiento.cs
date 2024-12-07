using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_llavecomportamiento : MonoBehaviour
{
    public GameObject Objetollave;
    public GameObject ColliderPuerta;
    AudioSource coinsound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinsound.Play();
            GetComponent<MeshRenderer>().enabled = false;
            ColliderPuerta.gameObject.SetActive(false);
            GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().usedKey = true;
            StartCoroutine(waitte());
            keyui.cooins++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        coinsound = GetComponent<AudioSource>();
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
    IEnumerator waitte()
    {
        yield return new WaitForSeconds(1f);
        Destroy(Objetollave);
    }
}
