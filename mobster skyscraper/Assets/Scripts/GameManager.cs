using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void PróximaFase(string proxFase)
    {
        SceneManager.LoadScene(proxFase);
    }
    public void Perdeu()
    {
        SceneManager.LoadScene("Tela de Derrota");
    }
    public void Ganhou()
    {
        SceneManager.LoadScene("Tela de Vitória");
    }
}
