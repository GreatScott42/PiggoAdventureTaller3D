using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_ChangeScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private Transform t;
    public GameObject transicion;
    private void Awake()
    {
        if (GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().destroyEnemy1 == true)
        {
            Destroy(GameObject.Find("Enemigos"));
        }
    }
    private void Start()
    {
        if (GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().destroyEnemy1 == true)
        {
            Destroy(GameObject.Find("Enemigos"));
        }
        if (GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().destroyEnemy2 == true)
        {
            Destroy(GameObject.Find("Enemigo2"));
        }
        //destruir enemigo en if (GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().destroyEnemy1 == true)
        /*{
            Destroy(gameObject);
        }
        el cambio de combate a exploracion*/

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (gameObject.name == "Enemigos"&&!GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().destroyEnemy1)
            {
                GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().nextEnemy = 1;
                GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().destroyEnemy1 = true;
                //Debug.Log("KLINGON");
                StartCoroutine(Fade(0));
                //
            }
            else if(gameObject.name == "Enemigo2"&&!GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().destroyEnemy2)
            {
                GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().nextEnemy = 2;
                GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().destroyEnemy2 = true;
                StartCoroutine(Fade(0));
                //SceneManager.LoadScene(sceneName);
            }else if(gameObject.name == "boss")
            {
                GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().nextEnemy = 0;
                GetComponent<AudioSource>().clip = GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().jefe;
                GetComponent<AudioSource>().Play();
                StartCoroutine(Fade(1));
            }

            /*if (GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().destroyEnemy1 == true)
            {
                Destroy(GameObject.Find("Enemigos"));
            }
            if (GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().destroyEnemy2 == true)
            {
                Destroy(GameObject.Find("Enemigo2"));
            }*/
            //t = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            //GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().setPos(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position);
            //GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().setRot(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().rotation);

            //GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().destroyEnemy1 = true;
            GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().guardarEscenaLvl1();

            //Debug.Log("guardando Transform: "+t.ToString());
            /*if (GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().destroyEnemy2)
            {
                SceneManager.LoadScene("Sc_Creditos");
            }*/

            //!
            /*if (GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().destroyEnemy1 == false)
            {
                //Destroy(GameObject.Find("Enemigos"));
                SceneManager.LoadScene(sceneName);
            }*/

            

            //SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            //Destroy(gameObject);
        }
    }
    IEnumerator Fade(int boss)
    {
        
        transicion.SetActive(true);
        transicion.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(2f);
        //transicion.GetComponent<Animator>().enabled = false;
        //transicion.SetActive(false);        
        if (boss == 1)
        {
            SceneManager.LoadScene("Sc_Boss");

        }
        else
        {
            SceneManager.LoadScene("Sc_PantallaCombate");
        }
        
    }

}
