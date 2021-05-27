using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevador : MonoBehaviour
{
    private bool praCima = true;
    public float velocidadeDoElevador;
    private float origem;
    private float alvo;
    public Transform origemY;
    public Transform alvoY;
    void Start()
    {
        origem = origemY.position.y;
        alvo = alvoY.position.y;
        velocidadeDoElevador = Random.Range(2, 3f);
    }

    void Update()
    {
        if(transform.position.y >= alvo)
        {
            praCima = false;
        }
        if(transform.position.y <= origem)
        {
            praCima = true;
        }

        if(praCima == true)
        {
            transform.Translate(Vector2.up * Time.deltaTime * velocidadeDoElevador);
        }
        if(praCima == false)
        {
            transform.Translate(Vector2.down * Time.deltaTime * velocidadeDoElevador);
        }
    }
}
