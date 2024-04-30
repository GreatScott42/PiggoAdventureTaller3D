using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_scr : MonoBehaviour
{
    [SerializeField] int dmg = 5;

    //pivote de donde gira el arma, es un cubito chico dentro del jugador
    public GameObject pivot;
    //rotacion original del arma para despues de atacar volverla a la misma
    Quaternion ogrot;
    //posicion original //   //
    Vector3 ogpos;
    //animador para mover el arma, obsoleto
    Animator animator;
    //bool para mover el arma al hacer clic izquierdo
    bool atacando;


    BoxCollider bc;
    MeshRenderer mr;

    void Start()
    {
        bc = GetComponent<BoxCollider>();
        mr = GetComponent<MeshRenderer>();
        bc.enabled = false;
        mr.enabled = false;
        atacando = false;
        ogrot = transform.localRotation;//new Vector3 (-2, -41, -61);
        ogpos = transform.localPosition;//new Vector3(0.9f, 0.3f, 0.3f);
        animator = GetComponent<Animator>();

    }

    // Update is called once per framed
    void Update()
    {
        //si se hizo clic el arma se rotara alrededor del pivote
        if (atacando) {
            transform.RotateAround(pivot.transform.position, Vector3.down, 250f * Time.deltaTime);
        }
        //clic izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ataque());
            //transform.RotateAround(transform.parent.transform.position, Vector3.down, 50f);
            //animator.SetBool("ataque", true);
        }
        else
        {
            //transform.rotation = ogrot;
            //animator.SetBool("ataque", false);
        }
    }

    //al hacer clic izquierdo por 0.5 segundos se rotara el arma y luego se reiniciaran su posicion y rotacion inicial
    IEnumerator ataque()
    {
        atacando = true;
        mr.enabled = true;
        bc.enabled = true;
        yield return new WaitForSeconds(0.5f);
        bc.enabled = false;
        mr.enabled = false;
        transform.localRotation = ogrot;
        transform.localPosition = ogpos;
        atacando = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.SendMessage("GetDamage", dmg);
        }
    }
}
