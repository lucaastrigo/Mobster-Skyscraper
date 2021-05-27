using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MataElevador : MonoBehaviour
{
    public int dano;
    private Transform jogador;

    private void Start()
    {
        jogador = FindObjectOfType<Jogador>().transform;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(collision.gameObject.GetComponent<Jogador>() != null)
            {
                collision.gameObject.GetComponent<Jogador>().JogadorTomaDano(dano);
                collision.gameObject.GetComponent<UIVida>().JogadorTomaDanoUI(dano);
            }
        }
    }
}
