using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_movimiento : MonoBehaviour
{
    // Velocidad de movimiento en unidades por segundo
    public float velocidad = 2.0f;

    // Distancia máxima en unidades desde el punto de inicio
    public float distancia = 5.0f;

    // Almacena la posición inicial del objeto
    private Vector3 posicionInicial;
    // Variable para controlar la dirección del movimiento
    private float direccion = 1.0f;

    void Start()
    {
        // Guardar la posición inicial al empezar
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Calcular el movimiento en función del tiempo y la velocidad
        float movimiento = velocidad * Time.deltaTime * direccion;

        // Mover el objeto
        transform.Translate(movimiento, 0, 0);

        // Verificar si el objeto ha alcanzado el límite de distancia
        if (Mathf.Abs(transform.position.x - posicionInicial.x) >= distancia)
        {
            // Cambiar la dirección del movimiento
            direccion *= -1;
        }
    }
}
