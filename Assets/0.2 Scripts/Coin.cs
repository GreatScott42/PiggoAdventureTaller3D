using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Puntos que se sumarán al recolectar la moneda
    public int puntos = 1;

    // Método que se llama cuando un objeto colisiona con la moneda
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Sumar puntos al jugador
            //GameManager.instance.AgregarPuntos(puntos);

            PlayerPrefs.SetInt("coins",(PlayerPrefs.GetInt("coins",0)+1));
            GetComponent<AudioSource>().clip = GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().moneda;
            GetComponent<AudioSource>().Play();
            // Desactivar la moneda 
            StartCoroutine(daed());
            

        }
    }

    IEnumerator daed()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false); // Desactivar el objeto
    }
}

