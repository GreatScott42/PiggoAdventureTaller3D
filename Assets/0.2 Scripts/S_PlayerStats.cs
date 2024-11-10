using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerStats : MonoBehaviour
{
    //Estadisticas Basicas
    public int life = 5;
    public int dmgAtack = 2;
    public float speed = 5f;
    public float jumpForce = 10f;
    public float dashForce = 5f;
    public float dashCoolDown = 0.4f;
    public float attackCoolDown = 0.2f; 

    //Valores de Salto
    public bool canJump = true;

    //Valores de Ataque
    public bool canAttack = true;
    public bool isAttack = false;

    //Valores de Movimiento
    public bool canMove = true;
    public bool canDash = false;

}
