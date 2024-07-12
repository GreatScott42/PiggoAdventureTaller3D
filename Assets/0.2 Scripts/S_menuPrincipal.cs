using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

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
        GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().saveFile.DeleteData("checkpoint");
        GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().saveFile.DeleteData("destroyenemy1");
        GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().saveFile.DeleteData("usedkey");
        GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().saveFile.DeleteData("botones");
        GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().saveFile.DeleteData("rot");
        GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().saveFile.DeleteData("pos");
        GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().saveFile.Save();
        GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().pos = new Vector3(43.5f,2f, -7.67f);
        GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().rot = new Quaternion(0, 0, 0, 0);
        GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().usedKey = false;
        GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().destroyEnemy1 = false;
        GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().destroyEnemy2 = false;
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
