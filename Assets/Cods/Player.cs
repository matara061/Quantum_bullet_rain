using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour // player nao vai precisar clicar para atirar, vai automatico
{
    public int life = 3; // dano estilo touhou, 1 hit perde uma vida
    public float speed;
    public float dano;
    public bool hit;
    public bool morreu = false;
    public bool revive = false;

    public float timeCount;   
    public bool timeOver;

    public GameObject[] coracoes;
    public GameObject icon;

    private Rigidbody2D rb2d;
   // private BoxCollider2D col;
    private CircleCollider2D col;

    public Bullet bullet; // vou ter que criar outro codigo do BulletSpawner por causa do "mainModule.simulationSpace = ParticleSystemSimulationSpace.World;"
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (life <= 0 & !morreu)
        {
            coracoes[2].gameObject.SetActive(false);
            morreu = true;
            Death();
        }
        else if (life == 3 && revive)
        {
            for (int i = 0; i < 3; i++)
            {
                coracoes[i].SetActive(true);
                Debug.Log(i);
            }
            TimeCount();
            revive = false;
        }
        else if (life == 3 && hit) // life > 0
        {
            TimeCount();
            coracoes[0].gameObject.SetActive(false);
        }
        else if (life == 2 && hit) // life > 0
        {
            TimeCount();
            coracoes[1].gameObject.SetActive(false);
        }
        else if (life == 1 && hit) // life > 0
        {
            TimeCount();
            coracoes[2].gameObject.SetActive(false);
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
       // Debug.Log("particle");
       if (life > 0)
        {
            life--;
            hit = true;
            col.enabled = false;
            timeCount = 3;
           // TimeCount();
          //  col.enabled = true; 
            
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collid");
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
                hit = false;
                timeOver = true;
                icon.gameObject.SetActive(false);
                col.enabled = true;
            }
        }
    }

    private void Death()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
         //Debug.Log("morreu");
    }

    public void special()
    {

    }

    public void special2()
    {

    }

    public void special3()
    {

    }
}
