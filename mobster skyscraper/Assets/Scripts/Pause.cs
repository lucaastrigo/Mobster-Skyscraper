using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool estáPausado = false;
    public GameObject menuDePausaUI;
    void Update()
    {
        if (estáPausado)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SceneManager.LoadScene("Primeiro Prédio");
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SceneManager.LoadScene("Segundo Prédio");
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SceneManager.LoadScene("Terceiro Prédio");
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                SceneManager.LoadScene("Tela de Vitória");
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene("Menu");
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estáPausado)
            {
                Resume();
            }
            else
            {
                Pausa();
            }
        }
    }
    public void Resume()
    {
        menuDePausaUI.SetActive(false);
        Time.timeScale = 1f;
        estáPausado = false;
    }
    public void Recomeçar()
    {
        SceneManager.LoadScene("Primeiro Prédio");
        UIPontos.pontos = 0;
    }
    void Pausa()
    {
        menuDePausaUI.SetActive(true);
        Time.timeScale = 0f;
        estáPausado = true;
    }
    public void Opções()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Sair()
    {
        Application.Quit();
    }
}
