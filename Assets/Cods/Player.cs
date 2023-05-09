using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour // player nao vai precisar clicar para atirar, vai automatico
{
    private int life = 3; // dano estilo touhou, 1 hit perde uma vida
    public float speed;
    public float dano; 

    private Rigidbody2D rb2d;

    public Bullet bullet; // vou ter que criar outro codigo do BulletSpawner por causa do "mainModule.simulationSpace = ParticleSystemSimulationSpace.World;"
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("particle");
        life--;
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
