using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour // player nao vai precisar clicar para atirar, vai automatico
{
    public int life = 3;
    public int currentLife;
    public int numEstrelas = 3;
    public float speed;
    public float dano;
    public bool hit;
    public bool morreu = false;
    public bool revive = false;

    public int mortes = 0;

    public float timeCount;   
    public bool timeOver;

    public float timeCount2;
    public bool timeOver2;
    public bool OnInvencivel = false;   

    public GameObject[] coracoes;
    public GameObject[] estrelas;
    public GameObject icon;
    public GameObject especial;
    public bool shild = false;

    public AudioSource musica;
    public AudioSource specialEffect;

    private Rigidbody2D rb2d;
   // private BoxCollider2D col;
    private CircleCollider2D col;

    public Bullet bullet; // vou ter que criar outro codigo do BulletSpawner por causa do "mainModule.simulationSpace = ParticleSystemSimulationSpace.World;"
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();

        currentLife = life;
    }

    // Update is called once per frame
    void Update()
    {

      /*  if (life <= 0 & !morreu) // em algumas situacoes os coracoes somem em ordem errada // player esta tomando 2 hits ao mesmo tempo, a vida diminui ent o cod pula a pri condicao
        {
            coracoes[2].gameObject.SetActive(false);
            morreu = true;
            mortes++;
            Death();
        }
        else if (life == 3 && revive)
        {
            for (int i = 0; i < 3; i++)
            {
                coracoes[i].SetActive(true);
                
            }
            TimeCount();
        }
        else if (life == 2 && hit) // life > 0
        {
            coracoes[0].gameObject.SetActive(false);
            TimeCount();
        }
        else if (life == 1 && hit) // life > 0
        {
            coracoes[1].gameObject.SetActive(false);
            TimeCount();
        }*/

        
        if (currentLife > 0 && !morreu)
        {
            if (hit && !OnInvencivel)
            {
                col.enabled = false;
                OnInvencivel = true;
                currentLife--;
                timeCount = 3;
                hit = false;

            }

            if (OnInvencivel)
            {
                TimeCount();
            }
        }else if(!morreu)
        {
            mortes++;
            hit = false;
            OnInvencivel = false;
            timeCount = 0;
            morreu = true; 
        }

        if (revive)
        {
            col.enabled = false;
            currentLife = life;
            timeCount = 5;
            OnInvencivel = true;
            morreu = false;
            revive = false;
        }

        if (numEstrelas >= 0) 
        {
            if(!shild && numEstrelas > 0)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    numEstrelas--;
                    shild = true;
                    special();
                }
            }else
            {
                TimeCount2();
            }
        }
        

    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // tempo de resposta muito baixo
        float moveVertical = Input.GetAxis("Vertical");

        rb2d.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
    }

    private void OnParticleCollision(GameObject other)
    {
       
       if (this.gameObject.layer == 6) // player esta tomando 2 hits ao mesmo tempo 
        {
          /*  if (life > 0)
            {
                life--;
                hit = true;
                col.enabled = false;
                timeCount = 3;
                // TimeCount();
                //  col.enabled = true; 

            }*/
          if(!hit)
            {
                hit = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collid");

        if (collision.gameObject.layer == 12) // quando recupera vida para 3 se tiver com inven o time cont para 
        {
            if (life == 2)
            {
                coracoes[0].gameObject.SetActive(true);
                life++;
            }else if (life == 1)
            {
                coracoes[1].gameObject.SetActive(true);
                life++;
            }
        }

        if (collision.gameObject.layer == 13) // quando recupera vida para 3 se tiver com inven o time cont para 
        {
            if (numEstrelas == 2)
            {
                estrelas[0].gameObject.SetActive(true);
                numEstrelas++;
            }
            else if (numEstrelas == 1)
            {
                estrelas[1].gameObject.SetActive(true);
                numEstrelas++;
            }
        }
    }

    void TimeCount()
    {
        timeOver = false;

        if (!timeOver && timeCount > 0)
        {
            icon.gameObject.SetActive(true);
            timeCount -= Time.deltaTime;

            if(timeCount < 0)
            {
                timeCount = 0;
              //  revive = false;
                OnInvencivel = false;
                timeOver = true;
                icon.gameObject.SetActive(false);
                col.enabled = true;
            }
        }
    }

    void TimeCount2()
    {
        timeOver2 = false;

        if (!timeOver2 && timeCount2 > 0)
        {
            timeCount2 -= Time.deltaTime;

            if (timeCount2 < 0)
            {
                timeCount2 = 0;
                especial.gameObject.SetActive(false);
                this.gameObject.layer = 6;
                shild = false;
                timeOver2 = true;
            }
        }
    }

    private void Death()
    {
        /* Time.timeScale = 0f;
         musica.Pause();
         SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
         */
        morreu = true;
        mortes++;
    }

    public void special()
    {
        specialEffect.Play();
        especial.gameObject.SetActive(true);
        this.gameObject.layer = 11;
        timeCount2 = 6;
    }
}
