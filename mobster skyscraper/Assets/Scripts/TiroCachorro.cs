using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroCachorro : MonoBehaviour
{
    public float velocidadeDoTiro;
    public int dano;
    private Transform jogador;
    private Vector2 alvo;

    void Start()
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Jogador>().JogadorTomaDano(dano);
            other.gameObject.GetComponent<UIVida>().JogadorTomaDanoUI(dano);
        }
    }
}
