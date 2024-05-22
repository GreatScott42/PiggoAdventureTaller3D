using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_menuPrincipal : MonoBehaviour
{
    //menu principal
    public Button botonJugar;
    public Button botonSalir;
    public Button botonCreditos;

    //menu exploracion y combate
    // Start is called before the first frame update
    void Start()
    {
        botonJugar.onClick.AddListener(jugar);
        botonSalir.onClick.AddListener(salir);
        botonCreditos.onClick.AddListener(creditos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void jugar()
    {
        SceneManager.LoadScene("Sc_EscenaExploracion");
    }
    void salir()
    {
        Application.Quit();
    }
    void creditos()
    {
        SceneManager.LoadScene("Sc_Creditos");
    }
}
