using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{
    public int vida;
    public int dano;
    public float velocidadeDoJogador;
    public float forçaDoPulo;
    public float forçaDeAtaque;
    public float alcanceDoAtaque;
    public float cooldownDoAtaque;
    public LayerMask inimigos;
    public Transform origemDoAtaque;
    public Transform origemDoObjetinho;
    public GameManager gameManager;
    public AudioSource pulo;
    public AudioSource ataque;
    public AudioSource arremessa;
    public AudioSource danoTomado;
    private Animator anim;
    private float últimoAtaque;
    private float movimentaçãoX;
    private float desaparecer = 0.75f;
    private bool podePular;
    private bool vaiPular;
    private bool praDireita = false;
    private bool temObjetinho = false;
    private Transform objetinho;
    public GameObject arma;
    //public GameObject mira;
    Rigidbody2D rb;
    public float timer = 0;
    public float limit = 0.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        movimentaçãoX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movimentaçãoX * velocidadeDoJogador, rb.velocity.y);
    }

    void Update()
    {
        Debug.Log(vaiPular);

        if(movimentaçãoX != 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }

        if (movimentaçãoX < 0.0f && praDireita == false)
        {
            Inverter();
            praDireita = true;
        }
        if (movimentaçãoX > 0.0f && praDireita == true)
        {
            Inverter();
            praDireita = false;
        }
        if (podePular == true && Input.GetButtonDown("Jump"))
        {
            vaiPular = true;
            podePular = false;
        }
        if (vaiPular == true)
        {
            pulo.Play();
            anim.SetTrigger("jump");
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * forçaDoPulo);
            vaiPular = false;
        }

        if (vida <= 0)
        {
            StartCoroutine(Desaparecer());
        }

        if (vida >= 14)
        {
            vida = 14;
        }

        if (!temObjetinho) //se não tem objeto...
        {
            if (últimoAtaque <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) && !temObjetinho)
                {
                    arma.SetActive(true); 
                    Collider2D[] inimigo = Physics2D.OverlapCircleAll(origemDoAtaque.position, alcanceDoAtaque, inimigos);
                    for (int i = 0; i < inimigo.Length; i++)
                    {
                        if (inimigo[i].gameObject.GetComponent<Inimigo>() != null)
                        {
                            inimigo[i].gameObject.GetComponent<Inimigo>().InimigoTomaDano(dano);
                        }
                    }
                    ataque.Play();
                    anim.SetTrigger("attack");
                    últimoAtaque = cooldownDoAtaque;
                }
            }
            if(arma.activeSelf)
            {
                timer += Time.deltaTime;
                if(timer>=limit)
                {
                    arma.SetActive(false);
                    timer = 0f;
                }
            }
            else
            {
                últimoAtaque -= Time.deltaTime;
            }
        }

        if (temObjetinho) //se tem objeto...
        {
            objetinho.position = origemDoObjetinho.transform.position;
            //mira.SetActive(true);

            //devolver para o chão
            if (Input.GetKeyDown(KeyCode.Q)) 
            {
                //mira.SetActive(false);
                objetinho.parent = null;
                temObjetinho = false;
                objetinho.GetComponent<Collider2D>().enabled = true;
                objetinho.GetComponent<Collider2D>().isTrigger = false;
                objetinho.GetComponent<Rigidbody2D>().gravityScale = 1;
                objetinho.GetComponent<Objetinho>().foiJogado = false;

            }

            //jogar o objetinho
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //mira.SetActive(false);
                arremessa.Play();
                temObjetinho = false;
                objetinho.parent = null;
                objetinho.GetComponent<Collider2D>().enabled = true;
                objetinho.GetComponent<Collider2D>().isTrigger = false;
                objetinho.GetComponent<Rigidbody2D>().gravityScale = 1;
                objetinho.GetComponent<Rigidbody2D>().AddForce(origemDoAtaque.TransformDirection(new Vector3(1, 0.82f)) * forçaDeAtaque, ForceMode2D.Impulse);
                objetinho.GetComponent<Objetinho>().foiJogado = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(origemDoAtaque.position, alcanceDoAtaque);
    }
    IEnumerator Desaparecer()
    {
        anim.SetTrigger("death");
        yield return new WaitForSeconds(desaparecer);
        Destroy(gameObject);
        FindObjectOfType<GameManager>().Perdeu();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        podePular = true;
    }
    IEnumerator espera()
    {
        yield return new WaitForSeconds(0.3f);
    }
    void Inverter()
    {
        praDireita = !praDireita;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }    
    public void JogadorTomaDano(int tanto)
    {
        danoTomado.Play();
        anim.SetTrigger("dano");
        vida -= tanto;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Objeto Arremessável"))
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                anim.SetTrigger("catch");
                temObjetinho = true;
                objetinho = collision.transform;
                objetinho.parent = origemDoObjetinho;
                collision.gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}




