using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_WeaponDmg : MonoBehaviour
{
    S_EnemyStats stats;

    private void Awake()
    {
        stats = transform.GetComponentInParent<S_EnemyStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.SendMessage("GetDamage",stats.dmg);
        }
    }



}
