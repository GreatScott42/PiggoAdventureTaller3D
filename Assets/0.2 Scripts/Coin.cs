using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Puntos que se sumarán al recolectar la moneda
    public int puntos = 100;

    // Método que se llama cuando un objeto colisiona con la moneda
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Sumar puntos al jugador
            //GameManager.instance.AgregarPuntos(puntos);

            // Desactivar la moneda 
            gameObject.SetActive(false); // Desactivar el objeto

        }
    }
}

