using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class seguro : MonoBehaviour
{
    // Start is called before the first frame update
    public Button si;
    public Button no;
    public static seguro Instancia;

    private void Awake()
    {
        Debug.Log("awake");
        
        gameObject.SetActive(false);
    }
    void Start()
    {
        
        
        si.onClick.AddListener(salir);
        no.onClick.AddListener(cerrar);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void salir()
    {
        if (SceneManager.GetActiveScene().Equals("Sc_menuPrincipal")) 
        {
            Application.Quit();
        }
        else 
        {
            Time.timeScale = 1.0f;

            SceneManager.LoadScene("Sc_menuPrincipal");
            gameObject.SetActive(false);
        }
        
    }
    void cerrar()
    {
        gameObject.SetActive(false);
    }
}
