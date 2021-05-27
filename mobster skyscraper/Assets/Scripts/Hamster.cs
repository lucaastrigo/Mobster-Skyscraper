using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamster : MonoBehaviour
{
    public int dano;
    public float alcanceDeAtaque;
    public float cooldownDeAtaque;
    public Transform origemDeAtaque;
    public Transform jogador;
    public LayerMask jogadorLayer;
    public AudioSource ataque;
    private float últimoAtaque;
    private Animator animHamster;

    void Start()
    {
        animHamster = GetComponent<Animator>();
        jogador = FindObjectOfType<Jogador>().transform;
    }
    void Update()
    {
        float distHamster = Vector2.Distance(transform.position, jogador.position);

        if(Time.time > últimoAtaque + cooldownDeAtaque)
        {
            if(distHamster < alcanceDeAtaque)
            {
                Collider2D[] jogador = Physics2D.OverlapCircleAll(origemDeAtaque.position, alcanceDeAtaque, jogadorLayer);
                for (int i = 0; i < jogador.Length; i++)
                {
                    ataque.Play();
                    jogador[i].GetComponent<Jogador>().JogadorTomaDano(dano);
                    jogador[i].GetComponent<UIVida>().JogadorTomaDanoUI(dano);
                }
                últimoAtaque = Time.time;
            }
        }

        if(GetComponent<Inimigo>().vida <= 0)
        {
            dano = 0;
            alcanceDeAtaque = 0;
        }
    }
}
