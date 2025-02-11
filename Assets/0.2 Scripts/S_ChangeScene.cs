using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_ChangeScene : MonoBehaviour
{
    [SerializeField] private string sceneName;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
