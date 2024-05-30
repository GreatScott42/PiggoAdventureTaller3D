using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScriptsGlobal : MonoBehaviour
{
    // Start is called before the first frame update    
    // Script global que guarda informacion entre escena de combate y exploracion, no se elimina entre cambio de escenas
    // pos del jugador
    private Vector3 pos;
    private Quaternion rot;
    // para que no se duplique al recargar la primera escena
    public static ScriptsGlobal Instancia;
    // bools para eliminar enemigo y la puerta una vez se gane al enemigo
    public bool destroyEnemy1;
    public bool usedKey;

    // evitar duplicaciones
    private void Awake()
    {
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
        destroyEnemy1 = false;
        usedKey = false;
        //playerTransform.position = 
        //playerTransform.rotation = 
        pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        rot = GameObject.FindGameObjectWithTag("Player").transform.rotation;
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
        
    }
    public void setRot(Quaternion newrot)
    {
        rot = newrot;

    }

    // Update is called once per frame
    void Update()
    {
        //pos = playerTransform.position;
        //Debug.Log(playerTransform.position);
        //playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
}
