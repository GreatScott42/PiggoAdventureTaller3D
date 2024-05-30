using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_ChangeScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private Transform t;

    private void Start()
    {
        if(GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().destroyEnemy1 == true)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //t = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().setPos(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position);
            GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().setRot(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().rotation);

            GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().destroyEnemy1 = true;
            //Debug.Log("guardando Transform: "+t.ToString());
            SceneManager.LoadScene(sceneName);

            //SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            //Destroy(gameObject);
        }
    }
}
