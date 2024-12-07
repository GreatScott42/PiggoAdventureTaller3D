using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.VR;
using UnityEngine;
using UnityEngine.UI;

public class music : MonoBehaviour
{
    // Start is called before the first frame update
    //128 music
    //127 sonid

    public Sprite verde;
    public Sprite rojo;
    public int actual;
    void Start()
    {
        actual = 0;
        gameObject.GetComponent<Button>().onClick.AddListener(musica);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void musica()
    {
        //GameObject go = GameObject.fin
        if (actual == 0)
        {
            actual = 1;
            gameObject.GetComponent<Image>().sprite = rojo;
        }
        else if (actual == 1)
        {
            actual = 0;
            gameObject.GetComponent<Image>().sprite = verde;
        }

        if (gameObject.name == "music")
        {
            AudioSource[] au = GameObject.FindObjectsOfType<AudioSource>();
            foreach (AudioSource au2 in au)
            {
                if (au2.priority == 128)
                {
                    if (au2.volume != 0)
                    {
                        au2.volume = 0;
                    }
                    else if (au2.volume != 1)
                    {
                        au2.volume = 1;
                    }
                }
            }
        }else if (gameObject.name == "sonido")
        {
            AudioSource[] au = GameObject.FindObjectsOfType<AudioSource>();
            foreach (AudioSource au2 in au)
            {
                if (au2.priority == 127)
                {
                    if (au2.volume != 0)
                    {
                        au2.volume = 0;
                    }
                    else if (au2.volume != 1)
                    {
                        au2.volume = 1;
                    }
                }
            }
        }

        
        
    }
}
