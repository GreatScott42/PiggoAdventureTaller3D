using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Creditos : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject creditos;
    float altura;
    Vector3 posInicial;
    void Start()
    {
        altura = creditos.transform.position.y+(Time.deltaTime*6000);
        posInicial = creditos.transform.position;
        posInicial.y -= 200f;
    }

    // Update is called once per frame
    void Update()
    {
        creditos.transform.position = new Vector3(creditos.transform.position.x, creditos.transform.position.y + Time.deltaTime * 40, creditos.transform.position.z);
        /*if (creditos.transform.position.y<altura)
        {
            
        }
        else
        {
            creditos.transform.position = posInicial;
        }*/
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Sc_menuPrincipal");
        }
    }
}
