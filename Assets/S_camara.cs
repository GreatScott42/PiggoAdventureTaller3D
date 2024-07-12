using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class S_camara : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; 
    public Vector3 offset;
    public Vector3 lk;
    bool lookp;
    void Start()
    {
        lk = Vector3.zero;
        lookp = false;
        if (GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().destroyEnemy1)
        {
            lookp=true;
            StartCoroutine(looklvl2());
        }
        target = GameObject.Find("Jugador").GetComponent<Transform>();
        //offset = new Vector3(0,9.66f,-10.8f);
    }

    // Update is called once per frame
    void Update()
    {
        //lookup();
        //Debug.Log(transform.position-GameObject.Find("Jugador").GetComponent<Transform>().position);
    }
    void LateUpdate()
    {
        
        transform.position = target.position + offset;
    }
    void lookup()
    {
        if (lookp)
        {            
            transform.LookAt(GameObject.Find("target").transform);
        }
        else
        {
            transform.LookAt(target.transform);
        }
    }
    IEnumerator looklvl2()
    {
        yield return new WaitForSeconds(6);
        lookp = false;
    }


}
