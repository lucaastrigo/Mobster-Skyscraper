using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cachorro : MonoBehaviour
{
    public float alcanceDeVisão;
    public float cooldownDeAtaque;
    private float limitMin;
    private float limitMax;
    public Transform origemDeTiro;
    public Transform jogador;
    public LayerMask jogadorLayer;
    private float últimoAtaque;
    private Animator animCachorro;
    public GameObject tiro;
    public AudioSource shoota;

    void Start()
    {
        animCachorro = GetComponent<Animator>();
        jogador = FindObjectOfType<Jogador>().transform;
    }

    void Update()
    {
        limitMin = jogador.position.y - 0.5f;
        limitMax = jogador.position.y + 0.5f;


        float distCachorro = Vector2.Distance(transform.position, jogador.position);

        if (distCachorro < alcanceDeVisão)
        {
            if (transform.position.y > limitMin && transform.position.y < limitMax)
            {
                Inimigo.velocidadeAuxiliar = 0;
                if (jogador.position.x < transform.position.x)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                }
                else if (jogador.position.x > transform.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }

                if (Time.time > últimoAtaque + cooldownDeAtaque)
                {
                    animCachorro.SetTrigger("shoot");
                    Invoke("atira", 0.25f);
                    últimoAtaque = Time.time;
                }
            }
            else
            {
                Inimigo.velocidadeAuxiliar = 1;
            }
        }
        else
        {
            Inimigo.velocidadeAuxiliar = 1;
        }
    }
    void atira()
    {
        shoota.Play();
        Instantiate(tiro, origemDeTiro.position, Quaternion.identity);
    }
}
    
