using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitMedico : MonoBehaviour

    
{

    private int quantidadeDeCura = 15;
    private int tempoRestante = 5;


    private void Start()
    {
        Destroy(gameObject, tempoRestante);
    }
    void OnTriggerEnter(Collider objetoDeColisao)
    {
        if (objetoDeColisao.tag == "Jogador")
        {
            objetoDeColisao.GetComponent<ControlaJogador>().CuraVida(quantidadeDeCura);
            Destroy(gameObject);
        }
    }
}
