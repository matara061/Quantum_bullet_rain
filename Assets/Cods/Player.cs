using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour // player nao vai precisar clicar para atirar, vai automatico
{
    public int life = 3; // dano estilo touhou, 1 hit perde uma vida
    public float speed;
    public float dano;
    public bool hit;

    public float timeCount;   
    public bool timeOver;

    private Rigidbody2D rb2d;
    private BoxCollider2D col;

    public Bullet bullet; // vou ter que criar outro codigo do BulletSpawner por causa do "mainModule.simulationSpace = ParticleSystemSimulationSpace.World;"
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb2d.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);

        if (life <= 0)
        {
            Death();
        }
        else if (life > 0 && hit)
            TimeCount();

        
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

    void TimeCount()
    {
        timeOver = false;

        if (!timeOver && timeCount > 0)
        {
            timeCount -= Time.deltaTime;

            if(timeCount < 0)
            {
                timeCount = 0;
                hit = false;
                timeOver = true;
                col.enabled = true;
            }
        }
    }

    private void Death()
    {
       // Debug.Log("morreu");
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
