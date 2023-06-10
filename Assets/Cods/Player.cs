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

    //public AudioSource musica;
    public AudioSource specialEffect;
    public AudioSource pegaItem;
    public AudioSource dano;

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
        }else if(!morreu && !revive)
        {
            mortes++;
            hit = false;
            OnInvencivel = false;
            timeCount = 0;
            morreu = true; 
        }

      /*  if (revive)
        {
            col.enabled = false;
            currentLife = life;
            timeCount = 5;
            OnInvencivel = true;
            morreu = false;
            revive = false;
        }*/

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
       
       if (this.gameObject.layer == 6)  
        {
          if(!hit)
            {
                dano.Play();
                hit = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 12) // quando recupera vida para 3 se tiver com inven o time cont para 
        {
            pegaItem.Play();
            if (currentLife == 2)
            {
                coracoes[0].gameObject.SetActive(true);
                currentLife++;
            }else if (currentLife == 1)
            {
                coracoes[1].gameObject.SetActive(true);
                currentLife++;
            }
        }

        if (collision.gameObject.layer == 13) // quando recupera vida para 3 se tiver com inven o time cont para 
        {
            pegaItem.Play();
            if (numEstrelas == 2)
            {
                estrelas[0].gameObject.SetActive(true);
                numEstrelas++;
            }
            else if (numEstrelas == 1)
            {
                estrelas[1].gameObject.SetActive(true);
                numEstrelas++;
            }else if (numEstrelas == 0)
            {
                estrelas[2].gameObject.SetActive(true);
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

    public void Revive()
    {
        col.enabled = false;
        currentLife = life;
        timeCount = 5;
        OnInvencivel = true;
        morreu = false;
        revive = false;
    }
    public void special()
    {
        specialEffect.Play();
        especial.gameObject.SetActive(true);
        this.gameObject.layer = 11;
        timeCount2 = 6;
    }
}
