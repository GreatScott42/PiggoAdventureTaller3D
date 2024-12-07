using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class keyui : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider boxc;
    public Canvas canvas;
    public static int cooins;
    bool puerta2 = false;
    void Start()
    {
        boxc = gameObject.GetComponentInChildren<BoxCollider>();
        canvas = gameObject.GetComponentInChildren<Canvas>();
        canvas.gameObject.SetActive(false);
        if (gameObject.name == "llave1")
        {
            canvas.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "0/1";
        }else if (gameObject.name=="llave2")
        {
            canvas.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "0/2";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!puerta2&&cooins>=1)
        {
            puerta2 = true;
            cooins = 0;
        }
        if (gameObject.name == "llave1")
        {
            if (cooins==0&&!puerta2)
            {
                canvas.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "0/1";
            }
            else
            {
                canvas.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "1/1";
            }
            
        }
        else if (gameObject.name == "llave2")
        {
            if (cooins==2)
            {
                canvas.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = cooins+"/2";
            }else if (cooins == 1)
            {
                canvas.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "1/2";
            }
            else if (cooins==0)
            {
                canvas.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "0/2";
            }
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("AAAAAAAAAAAA");
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("AAAAAAAAAAAA");
            canvas.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("eeeeeeeeee");
            canvas.gameObject.SetActive(false);
        }
    }
}
