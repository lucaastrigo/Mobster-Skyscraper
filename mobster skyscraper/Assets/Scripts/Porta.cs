using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public GameObject lembrança;
    public int cura;
    private bool entrouUma = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Entra();
                StartCoroutine(Sai());
            }
        }
    }

    void Entra()
    {
        lembrança.SetActive(true);
        Time.timeScale = 0f;
        if (entrouUma == false)
        {
            UIPontos.pontos += 100;
            FindObjectOfType<Jogador>().JogadorTomaDano(-cura);
            FindObjectOfType<UIVida>().JogadorTomaDanoUI(-cura);
            entrouUma = true;
        }
    }
    IEnumerator Sai()
    {
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1f;
        lembrança.SetActive(false);
    }
}
