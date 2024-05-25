using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_menuExploracionCombate : MonoBehaviour
{
    //menu exploracion y combate
    public Button botonContinuar;
    public Button botonMenu;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {        
        botonContinuar.onClick.AddListener(continuar);
        botonMenu.onClick.AddListener(menu);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void continuar()
    {
        canvas.SetActive(false);
        Time.timeScale = 1.0f;
    }
    void menu()
    {
        canvas.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Sc_menuPrincipal");
    }
}
