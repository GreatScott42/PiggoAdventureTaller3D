using Esper.ESave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_checkpoint : MonoBehaviour
{
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
        //guardar posicion checkpoint
        if (other.CompareTag("Player"))
        {
            saveFile.AddOrUpdateData("checkpoint", other.transform.position);
            saveFile.Save();
        }
    }
}
