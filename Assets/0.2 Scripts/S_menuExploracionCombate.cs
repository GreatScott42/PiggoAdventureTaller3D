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
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {        
        botonContinuar.onClick.AddListener(continuar);
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
}
