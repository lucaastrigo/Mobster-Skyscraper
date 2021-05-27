using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroMicoPreg : MonoBehaviour
{
    public float velocidadeDoTiro;
    private Transform jogador;
    private Vector2 alvo;
    public int dano;

    private void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
        alvo = new Vector2(jogador.position.x, jogador.position.y);
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, alvo, velocidadeDoTiro * Time.deltaTime);

        if (transform.position.x == alvo.x && transform.position.y == alvo.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Jogador>().JogadorTomaDano(dano);
            other.gameObject.GetComponent<UIVida>().JogadorTomaDanoUI(dano);
        }
    }
}
