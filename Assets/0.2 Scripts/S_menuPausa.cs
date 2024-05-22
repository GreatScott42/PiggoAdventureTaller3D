using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_menuPausa : MonoBehaviour
{
    // Start is called before the first frame update
    float timeScale;
    public GameObject canvas;
    void Start()
    {
        timeScale = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)||Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                canvas.SetActive(false);
                Time.timeScale = timeScale;
            }
            else
            {
                canvas.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
