using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPontos : MonoBehaviour
{
    public static int pontos = 0;
    private Text pontuação;
    void Start()
    {
        pontuação = GetComponent<Text>();
    }

    void Update()
    {
        pontuação.text = "" +pontos;
    }

    public void GanhaPonto(int tantinho)
    {
        pontos += tantinho;
    }
}
