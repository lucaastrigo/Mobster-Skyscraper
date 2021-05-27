using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetinho : MonoBehaviour
{
    public int dano;
    public bool foiJogado;
    public AudioSource quebra;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            return;
        }
        if (other.gameObject.CompareTag("Inimigo") && foiJogado)
        {
            other.gameObject.GetComponent<Inimigo>().InimigoTomaDano(dano);
        }

        if (foiJogado)
        {
            quebra.Play();
            StartCoroutine(destroiGarrafa());
        }
        else
        {
            GetComponent<Collider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    IEnumerator destroiGarrafa()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
