using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_menuExploracionCombate : MonoBehaviour
{
    //menu exploracion y combate
    public Button botonContinuar;
    public Button botonMenu;
    public GameObject canvas;

    public GameObject prefab1;
    public GameObject prefab2;

    int enemiesTotal;
    bool changescene;

    float timeScale;
    //public GameObject canvas;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        timeScale = Time.timeScale;

        changescene = false;
        botonContinuar.onClick.AddListener(continuar);
        botonMenu.onClick.AddListener(menu);
        if (prefab1 == null || prefab2 == null)
            return;
        if (GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().nextEnemy==1)
        {
            Instantiate(prefab1,transform.position,Quaternion.identity);
            changescene = true;
        }else if (GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().nextEnemy == 2)
        {
            Instantiate(prefab2, transform.position, Quaternion.identity);
            changescene = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (changescene)
        {
            CombToExpl();
        }       

    }
    void continuar()
    {
        canvas.SetActive(false);
        Time.timeScale = 1.0f;
    }
    void menu()
    {
        canvas.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Sc_menuPrincipal");
    }
    private void CombToExpl()
    {
        enemiesTotal = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log(enemiesTotal);
        if (GameObject.FindGameObjectWithTag("Boss") == null && enemiesTotal <= 0)
        {
            StartCoroutine(espera());
            if(GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().nextEnemy == 2)
            {
                SceneManager.LoadScene("Sc_Creditos");
                return;
            }
            SceneManager.LoadScene("Sc_EscenaExploracion");
        }
    }
    IEnumerator espera()
    {
        yield return new WaitForSeconds(1);
    }
}
