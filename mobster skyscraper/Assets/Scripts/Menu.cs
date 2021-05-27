using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Cutscene()
    {
        SceneManager.LoadScene("Cutscene");
    }
    public void Jogar()
    {
        SceneManager.LoadScene("Primeiro Prédio");
        UIPontos.pontos = 0;
    }
    public void Menuar()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Sair()
    {
        Application.Quit();
    }
    public void RestartCutscene()
    {
        SceneManager.LoadScene("Cutscene");
    }
}
