using Esper.ESave;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptsGlobal : MonoBehaviour
{
    // Start is called before the first frame update    
    // Script global que guarda informacion entre escena de combate y exploracion, no se elimina entre cambio de escenas
    // pos del jugador
    public Vector3 pos;
    public Quaternion rot;
    // para que no se duplique al recargar la primera escena
    public static ScriptsGlobal Instancia;
    // bools para eliminar enemigo y la puerta una vez se gane al enemigo
    public bool destroyEnemy1;
    public bool destroyEnemy2;
    public bool usedKey;

    public int botonesCorrectosApretados;

    // guardado persistente, guardado en %appdata%/locallow/defaultcompany/(carpeta del proyecto)/Stylish/Esave 
    //(al menos en mi caso, se puede cambiar en el script del objeto savefile)
    private SaveFileSetup saveFileSetup;
    public SaveFile saveFile;
    /*
     * la destruccion de la puerta y llave se hacen en el script del comportamiento de llave
    public GameObject Objetollave;
    public GameObject ColliderPuerta;*/

    public Vector3 checkpointPos;

    public int nextEnemy;

    // evitar duplicaciones
    private void Awake()
    {

        checkpointPos = pos;
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instancia != this)
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(this);        
    }
    void Start()
    {
        nextEnemy = 1;

        saveFileSetup = GameObject.Find("SaveFile").GetComponent<SaveFileSetup>();
        saveFile = saveFileSetup.GetSaveFile();


        foreach (GameObject a in GameObject.FindGameObjectsWithTag("Boton"))
        {
            a.GetComponent<MeshRenderer>().material.color = Color.red;
        }


        botonesCorrectosApretados = 0;
        destroyEnemy1 = false;
        usedKey = false;
        //playerTransform.position = 
        //playerTransform.rotation = 
        pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        rot = GameObject.FindGameObjectWithTag("Player").transform.rotation;

        if (saveFile.HasData("pos"))
        {
            LoadGame();
        }

        //SaveGame();


        //destruir llave y puerta, Script S_llaveComportamiento
        
    }

    // guardado persistente
    public void SaveGame()
    {
        //escena 1        
        saveFile.AddOrUpdateData("pos", pos);
        saveFile.AddOrUpdateData("rot", rot);
        saveFile.AddOrUpdateData("destroyenemy1",destroyEnemy1);
        saveFile.AddOrUpdateData("usedkey",usedKey);
        saveFile.AddOrUpdateData("botones",botonesCorrectosApretados);
        saveFile.Save();

        Debug.Log("Saved game.");
    }
    
    public void LoadGame()
    {
        //escena 1
        
        if (!saveFile.HasData("rot"))
        {
            return;
        }
        pos = saveFile.GetVector3("pos");
        rot = saveFile.GetQuaternion("rot");
        destroyEnemy1 = saveFile.GetData<bool>("destroyenemy1");
        usedKey = saveFile.GetData<bool>("usedkey");
        botonesCorrectosApretados = saveFile.GetData<int>("botones");
    }

    public Vector3 getPos()
    {
        return pos;
    }
    public Quaternion getRot()
    {
        return rot;
    }
    public void setPos(Vector3 newpos)
    {
        pos = newpos;
        saveFile.AddOrUpdateData("pos", pos);
    }
    public void setRot(Quaternion newrot)
    {
        rot = newrot;

    }
    public void guardarEscenaLvl1()
    {
        //pos del jugador, script S_MovPlayerExpl
        pos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        rot = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().rotation;

        //destruir enemigo del lvl1, Script S_ChangeScene
        //destroyEnemy1 = true;
        SaveGame();
    }
    public void cargarEscenaLvl1()
    {
        LoadGame();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = pos;
        player.transform.rotation = rot;
    }
    public void resetsave()
    {
        Debug.Log(saveFile.fullPath);
        if (File.Exists(saveFile.fullPath))
        {
            File.Delete(saveFile.fullPath);
            SceneManager.LoadScene("Sc_menuPrincipal");
            //Console.WriteLine("Archivo borrado exitosamente.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            resetsave();
        }
        //pos = playerTransform.position;
        //Debug.Log(playerTransform.position);
        //playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
}
