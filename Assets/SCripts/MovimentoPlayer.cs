using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    public Rigidbody2D oRigidbody2D;
    public GameObject laserDoJogador;
    public Transform localDoDisparoUnico;
    public float velocidadeDoNave;
    public bool temLaserDuplo;
    
    private Vector2 teclasApertadas;

    void Start()
    {
        temLaserDuplo = false;
    }

    void Update()
    {
        MovimentarJogador();
        AtirarLaser(); // Chamar o método AtirarLaser aqui
    }

    private void MovimentarJogador()
    {
        teclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        oRigidbody2D.velocity = teclasApertadas.normalized * velocidadeDoNave;
    }

    private void AtirarLaser()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Atirou");
            if (temLaserDuplo == false)
            {
                Debug.Log("Disparando laser único");
                Instantiate(laserDoJogador, localDoDisparoUnico.position, localDoDisparoUnico.rotation);
            }
        }
    }
}
