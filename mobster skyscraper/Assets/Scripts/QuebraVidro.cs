using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuebraVidro : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Vidro"))
        {
            StartCoroutine(espera());
            Destroy(other.gameObject);
            UIPontos.pontos += 100;
        }
    }

    IEnumerator espera()
    {
        yield return new WaitForSeconds(0.3f);
    }
}
