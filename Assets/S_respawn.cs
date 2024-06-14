using Esper.ESave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class S_respawn : MonoBehaviour
{
    // Start is called before the first frame update
    private SaveFileSetup saveFileSetup;
    private SaveFile saveFile;
    // Start is called before the first frame update
    void Start()
    {
        saveFileSetup = GameObject.Find("SaveFile").GetComponent<SaveFileSetup>();
        saveFile = saveFileSetup.GetSaveFile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //cargar posicion checkpoint
        if (other.CompareTag("Player"))
        {
            if(!saveFile.HasData("checkpoint"))
            {
                return;
            }
            other.transform.position = saveFile.GetVector3("checkpoint");
            other.GetComponent<Rigidbody>().velocity = new(0,0);
        }
    }
}
