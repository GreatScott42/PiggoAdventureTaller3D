using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestr : MonoBehaviour
{
    // Start is called before the first frame update
    public static dontdestr Instancia;
    void Start()
    {
        if (Instancia == null)
        {
            Debug.Log("null");
            Instancia = this;
            Debug.Log("notdestroy");
            DontDestroyOnLoad(gameObject);

        }
        else if (Instancia != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
