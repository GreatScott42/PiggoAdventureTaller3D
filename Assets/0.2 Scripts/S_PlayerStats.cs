using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerStats : MonoBehaviour
{
    //Estadisticas Basicas
    public int life = 5;
    public int DmgAtack = 2;
    public float Speed = 5f;
    public float JumpForce = 10f;
    public float DashForce = 5f;
    public float DashCoolDown = 0.4f;

    //Valores de Salto
    public bool canJump = true;

    //Valores de Ataque
    public bool canAttack = true;
    public bool isAttack = false;

    //Valores de Movimiento
    public bool canMove = true;
    public bool canDash = false;

}
