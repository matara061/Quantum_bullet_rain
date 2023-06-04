using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bot2 : MonoBehaviour
{
    public float life = 6000;
    public float speed;
    private float dam = 1.2f;
    public bool morreu = false;

    public GameObject[] ataques;
    public GameObject[] bombas;

    public BulletHellSpawner hell;
    public BarraVida healthBar;
    public Player player;

    public AudioSource musica;


    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(life);
    }

    // Update is called once per frame
    void Update()
    {

        if (life > 0)
        {
            if (life > 3000)
            {
                if (life <= 6000 & life > 5900)
                {
                    //ataques[0].gameObject.SetActive(true);

                }
                else if (life <= 5900 & life > 5200)
                {
                    ataques[1].gameObject.SetActive(true);
                    ataques[2].gameObject.SetActive(true);
                }
                else if (life <= 5200 & life > 4600)
                {
                    ataques[0].gameObject.SetActive(false);
                    ataques[1].gameObject.SetActive(false);
                    ataques[2].gameObject.SetActive(true);
                    ataques[4].gameObject.SetActive(true);
                    bombas[4].gameObject.SetActive(true);
                    bombas[5].gameObject.SetActive(true);
                }
                else if (life <= 4600 & life > 3700)
                {
                    ataques[4].gameObject.SetActive(false);
                    bombas[4].gameObject.SetActive(false);
                    bombas[5].gameObject.SetActive(false);
                    ataques[3].gameObject.SetActive(true);
                    bombas[0].gameObject.SetActive(true);
                    bombas[1].gameObject.SetActive(true);
                }
                else if (life <= 3700 & life > 3000)
                {
                    ataques[2].gameObject.SetActive(false);
                    ataques[3].gameObject.SetActive(false);
                    bombas[0].gameObject.SetActive(false);
                    bombas[1].gameObject.SetActive(false);
                    ataques[4].gameObject.SetActive(true);
                    ataques[5].gameObject.SetActive(true);
                    bombas[2].gameObject.SetActive(true);
                    bombas[3].gameObject.SetActive(true);
                }
            }
            else
            {
                if (life > 2350)
                {
                    ataques[4].gameObject.SetActive(false);
                    ataques[5].gameObject.SetActive(false);
                    bombas[2].gameObject.SetActive(false);
                    bombas[3].gameObject.SetActive(false);
                    ataques[6].gameObject.SetActive(true);
                    ataques[7].gameObject.SetActive(true);
                }
                else if (life <= 2350 & life > 1200)
                {
                    ataques[6].gameObject.SetActive(false);
                    ataques[7].gameObject.SetActive(false);
                    ataques[8].gameObject.SetActive(true);
                    ataques[9].gameObject.SetActive(true);
                    ataques[0].gameObject.SetActive(true);
                }
                else if (life <= 1200 & life > 500)
                {
                    ataques[8].gameObject.SetActive(false);
                    ataques[9].gameObject.SetActive(false);
                    ataques[0].gameObject.SetActive(false);
                    bombas[0].gameObject.SetActive(true);
                    bombas[1].gameObject.SetActive(true);
                    bombas[6].gameObject.SetActive(true);
                    bombas[7].gameObject.SetActive(true);
                    bombas[8].gameObject.SetActive(true);
                    bombas[9].gameObject.SetActive(true);
                    bombas[10].gameObject.SetActive(true);
                    bombas[11].gameObject.SetActive(true);
                }
                else if (life <= 500 & life > 0)
                {
                    ataques[1].gameObject.SetActive(true);
                }
            }
        }
        else if (!morreu)
        {
            Death();
            morreu = true;
        }

        if (player.shild)
        {
            dam = 3;
        }
        else
            dam = 1.2f;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (life > 0)
        {
            life -= dam;
            healthBar.SetHealth(life);

        }

    }

    private void ParaAtaque()
    {
        for (int i = 0; i < 10; i++)
        {
            ataques[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < 12; i++)
        {
            bombas[i].gameObject.SetActive(false);
        }
    }

    private void Death()
    {
        // Time.timeScale = 0f;
        // musica.Pause();
        SceneManager.LoadScene("Vitoria", LoadSceneMode.Additive);
    }
}
