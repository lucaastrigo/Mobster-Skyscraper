using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int vida;
    public int bônus;
    public float velocidadeDoInimigo;
    public bool anda;
    //public float alcanceDeVista;
    //public float alcanceDoAtaque;
    //public float cooldownDoAtaque;
    //public Transform origemDoAtaque;
    public Transform detectorHorizontal;
    public Transform detectorVertical;
    //public Transform jogador;
    //public LayerMask jogadorLayer;
    //public GameObject tiro;
    public AudioSource tomaDano;
    private Animator anim;
    private bool praDireita = true;
    private bool morto = false;
    private float distHorizontal = 0.1f;
    private float distVertical = 0.1f;
    //private float últimoAtaque;
    public float desaparecer = 0.5f;
    public static float velocidadeAuxiliar = 1;


    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (!morto) //se está vivo...
        {
            if (anda) //se é inimigo que anda...
            {
                //código de movimentação 

                transform.Translate(Vector2.right * velocidadeDoInimigo * velocidadeAuxiliar * Time.deltaTime);

                if (velocidadeAuxiliar != 0)
                {
                    anim.SetBool("walk", true);
                }
                else
                {
                    anim.SetBool("walk", false);
                }

                RaycastHit2D vertical = Physics2D.Raycast(detectorVertical.position, Vector2.down, distVertical);
                RaycastHit2D horizontal = Physics2D.Raycast(detectorHorizontal.position, Vector2.right, distHorizontal);
                if (vertical.collider == false || horizontal == true)
                {
                    if (praDireita == true)
                    {
                        ViraPraEsquerda();
                    }
                    else
                    {
                        ViraPraDireita();
                    }
                }
            }
            else
            {
                anim.SetBool("idle", true);
            }
        }

        //se está morto...
        if(vida <= 0)
        {
            morto = true;
            anim.SetTrigger("death");
            StartCoroutine(Desaparecer());
            UIPontos.pontos += bônus;
        }
    }
    public void ViraPraEsquerda()
    {
        transform.eulerAngles = new Vector3(0, -180, 0);
        praDireita = false;
    }
    public void ViraPraDireita()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        praDireita = true;
    }
    IEnumerator Desaparecer()
    {
        yield return new WaitForSeconds(desaparecer);
        Destroy(gameObject);
    }
    public void InimigoTomaDano(int tanto)
    {
        anim.SetTrigger("hurt");
        tomaDano.Play();
        vida -= tanto;
    }
}
