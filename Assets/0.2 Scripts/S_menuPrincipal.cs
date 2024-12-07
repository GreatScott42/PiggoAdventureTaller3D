using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using Esper.ESave;
using System.IO;

public class S_menuPrincipal : MonoBehaviour
{
    //menu principal
    public static S_menuPrincipal Instancia;
    public Button botonJugar;

    public Button botonSalir;
    public Button botonCreditos;
    public Button botonOpciones;
    public Button botonOpciones2;
    public Button botoncontroles;
    public Button volvercontrolaopciones;

    public Canvas c2;
    public Canvas c3;

    public Camera cam1;
    public Camera cam2;

    public SaveFile saveFile;
    public SaveFileSetup saveFileSetup;

    public GameObject canvas6;

    //menu exploracion y combate
    // Start is called before the first frame update
    void Start()
    {
        cam1 = Camera.main;
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(c2.gameObject);
            DontDestroyOnLoad(c3.gameObject);
            DontDestroyOnLoad(cam2.gameObject);
        }
        else if (Instancia != this)
        {
            Destroy(gameObject);
            Destroy(c2.gameObject);
            Destroy(c3.gameObject);
            Destroy(cam2.gameObject);
        }

        saveFileSetup = GameObject.Find("SaveFile").GetComponent<SaveFileSetup>();
        saveFile = saveFileSetup.GetSaveFile();
        botonJugar.onClick.AddListener(jugar);
        botonSalir.onClick.AddListener(salir);
        botonCreditos.onClick.AddListener(creditos);
        botonOpciones.onClick.AddListener(opciones);
        botonOpciones2.onClick.AddListener(opciones2);

        botoncontroles.onClick.AddListener(controles);
        volvercontrolaopciones.onClick.AddListener(controles2);
    }
    void controles2()
    {
        c3.gameObject.SetActive(false);
        c2.gameObject.SetActive(true);
    }
    void controles()
    {
        c2.gameObject.SetActive(false);
        c3.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (cam1 == null)
        {
            cam1=Camera.main;
        }
        if (botonOpciones == null)
        {
            botonOpciones = GameObject.Find("botonopciones").GetComponent<Button>();
            botonOpciones.onClick.AddListener(opciones);
        }
    }

    void jugar()
    {                        
        File.Delete(saveFile.fullPath);
        if (File.Exists(saveFile.fullPath))
        {
            File.Delete(saveFile.fullPath);
            
            //Console.WriteLine("Archivo borrado exitosamente.");
        }
        SceneManager.LoadScene("Sc_EscenaExploracion");
        GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().saveFile.DeleteData("checkpoint");
        GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().saveFile.DeleteData("destroyenemy1");
        GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().saveFile.DeleteData("usedkey");
        GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().saveFile.DeleteData("botones");
        GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().saveFile.DeleteData("rot");
        GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().saveFile.DeleteData("pos");
        GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().saveFile.Save();
        GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().pos = new Vector3(43.5f, 2f, -7.67f);
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
    public void opciones()
    {
        //SceneManager.LoadScene("opciones");
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(true);
        if (GameObject.Find("Canvas6") != null)
        {
            canvas6 = GameObject.Find("Canvas6");
            GameObject.Find("Canvas6").SetActive(false);
        }
    }
    void opciones2()
    {
        cam2.gameObject.SetActive(false);

        cam1.gameObject.SetActive(true);
        canvas6.SetActive(true);
        /*if (GameObject.Find("Canvas6") != null)
        {
            GameObject.Find("Canvas6").SetActive(true);
        }*/
    }
}
