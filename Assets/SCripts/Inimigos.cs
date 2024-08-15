using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{

    public GameObject laserDoInimigo;
    
    public Transform localDoDisparo;

    public float velocidadeDoInimigo;

    public int vidaMaximaDoInimigo;

    public int vidaAtualDoInimigo;

    public float tempoMaximoEntreOsLasers;

    public float tempoAtualDosLasers;

    // Start is called before the first frame update
    void Start()
    {
        vidaAtualDoInimigo = vidaMaximaDoInimigo;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarInimigo();
        AtirarLaser();
    }

    private void MovimentarInimigo()
    {
        transform.Translate(Vector3.up * velocidadeDoInimigo * Time.deltaTime);
    }

    private void AtirarLaser()
    {
        tempoAtualDosLasers -= Time.deltaTime;

        if(tempoAtualDosLasers <= 0)
        {
            Instantiate(laserDoInimigo, localDoDisparo.position, Quaternion.Euler(0f, 0f, 90f));
            tempoAtualDosLasers = tempoMaximoEntreOsLasers;
        }
    }

    public void MachucarInimigo(int danoParaReceber)
    {
        vidaAtualDoInimigo -= danoParaReceber;

        if(vidaAtualDoInimigo <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
