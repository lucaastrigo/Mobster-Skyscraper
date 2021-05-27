using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIVida : MonoBehaviour
{
    public int vida;
    public int vidaMax;

    public Image[] vidas;
    public Sprite vidaCheia;
    public Sprite vidaVazia;

    void Update()
    {
        if(vida > vidaMax)
        {
            vida = vidaMax;
        }

        for(int i = 0; i < vidas.Length; i++)
        {
            if(i < vida)
            {
                vidas[i].sprite = vidaCheia;
            }
            else
            {
                vidas[i].sprite = vidaVazia;
            }

            if(i < vidaMax)
            {
                vidas[i].enabled = true;
            }
            else
            {
                vidas[i].enabled = false;
            }
        }
    }

    public void JogadorTomaDanoUI(int tanto)
    {
        vida -= tanto;
    }
}
