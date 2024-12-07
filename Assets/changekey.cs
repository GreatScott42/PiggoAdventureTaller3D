using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class changekey : MonoBehaviour
{
    // Start is called before the first frame update

    bool escuchando = false;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(escuchar);
    }
     
    void escuchar()
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().fontSize=18;
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "presiona una tecla";
        escuchando =true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!escuchando)
        {
            return;
        }
        if (Input.anyKeyDown)
        {
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    
                    Debug.Log("Última tecla presionada: " + key);
                    gameObject.GetComponentInChildren<TextMeshProUGUI>().text=key.ToString();                    
                    gameObject.GetComponentInChildren<TextMeshProUGUI>().fontSize = 24;
                    escuchando = false;
                    switch (gameObject.name)
                    {
                        case "atacar":
                            ScriptsGlobal.ataquetecla = key;
                            break;
                        default:
                            break;
                    }


                    break;
                }
            }
        }
    }
}
