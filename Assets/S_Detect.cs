using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Detect : MonoBehaviour
{
    private List<GameObject> listEnemies = new List<GameObject>();

    private void Update()
    {
    }

    public List<GameObject> GetList()
    {
        return listEnemies;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy"))
            listEnemies.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
            listEnemies.Clear();
    }
}
