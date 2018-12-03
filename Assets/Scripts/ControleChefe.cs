using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControleChefe : MonoBehaviour {
    private Transform jogador;
    private NavMeshAgent agente;
    private Status statusChefe;
    private AnimacaoPersonagem animacaoDoChefe;
    private MovimentoPersonagem movimentacaoDoChefe;
    public GameObject KitMedicoPreFab;

	// Use this for initialization
	void Start () {
        jogador = GameObject.FindWithTag("Jogador").transform;
        agente = GetComponent<NavMeshAgent>();
        statusChefe = GetComponent<Status>();
        agente.speed = statusChefe.Velocidade;
        animacaoDoChefe = GetComponent<AnimacaoPersonagem>();
        movimentacaoDoChefe = GetComponent<MovimentoPersonagem>();

        
	}
	
	// Update is called once per frame
	void Update () {
        agente.SetDestination(jogador.transform.position);
        animacaoDoChefe.Movimentar(agente.velocity.magnitude);

        if (agente.hasPath == false)
        {
            bool JogadorEstarPerto = agente.remainingDistance <= agente.stoppingDistance;
            if (JogadorEstarPerto == true)
            {

                animacaoDoChefe.Atacar(true);
                Vector3 direcao = jogador.transform.position - transform.position;
                movimentacaoDoChefe.Rotacionar(direcao);

            }

            else
            {
                animacaoDoChefe.Atacar(false);
            }
        }


    }


    void AtacaJogador()
    {
        int dano = UnityEngine.Random.Range(30, 50);
        jogador.GetComponent<ControlaJogador>().TomarDano(dano);
    }

    public void TomarDano(int dano)
    {
        statusChefe.Vida -= dano;
        if (statusChefe.Vida <= 0)
        {
            Morrer();
        }

    }

    public void Morrer()
    {
        agente.enabled = false;
        animacaoDoChefe.Morrer();
        movimentacaoDoChefe.Morrer();
        this.enabled = false;
        Destroy(gameObject, 2);
        Instantiate(KitMedicoPreFab, transform.position, Quaternion.identity);
    }

    
}
