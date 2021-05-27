using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicoPreguiça : MonoBehaviour
{
    public float alcanceDeVisão;
    public float cooldownDeAtaque;
    public Transform origemDeTiro;
    public Transform jogador;
    public LayerMask jogadorLayer;
    public AudioSource atira;
    private float últimoAtaque;
    private Animator animMicoPreg;
    public GameObject tiro;

    void Start()
    {
        animMicoPreg = GetComponent<Animator>();
        jogador = FindObjectOfType<Jogador>().transform;
    }
    void Update()
    {
        animMicoPreg.SetBool("idle", true);

        float distMicoPreg = Vector2.Distance(transform.position, jogador.position);
        if (jogador.position.y < transform.position.y)
        {
            if (distMicoPreg < alcanceDeVisão)
            {
                if (Time.time > últimoAtaque + cooldownDeAtaque)
                {
                    atira.Play();
                    Instantiate(tiro, origemDeTiro.position, Quaternion.identity);
                    últimoAtaque = Time.time;
                }
            }

            if (jogador.position.x < transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);

            }
            else if (jogador.position.x > transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(origemDeTiro.position, alcanceDeVisão);
    }
}
