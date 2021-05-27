using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidro : MonoBehaviour
{
    public GameObject elevador;
    public AudioSource quebrando;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if(other.gameObject.CompareTag("Arma"))
        {
            quebrando.Play();
            elevador.SetActive(true);
        }
    }
}
