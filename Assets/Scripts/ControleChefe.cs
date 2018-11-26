using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControleChefe : MonoBehaviour {
    private Transform jogador;
    private NavMeshAgent agente;
	// Use this for initialization
	void Start () {
        jogador = GameObject.FindWithTag("Jogador").transform;
        agente = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        agente.SetDestination(jogador.transform.position);
	}
}
