using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bot1 : MonoBehaviour
{
    public float life = 5000; 
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
            if (life <= 5000 & life > 4900)   
            {
                 ataques[0].gameObject.SetActive(true);
                
            }
            else if (life <= 4900 & life > 4750)
            {
                ataques[1].gameObject.SetActive(true);
            }
            else if (life <= 4750 & life > 3000)
            {
                ataques[0].gameObject.SetActive(false);
                ataques[1].gameObject.SetActive(false);
                ataques[2].gameObject.SetActive(true);
                ataques[4].gameObject.SetActive(true);
                bombas[4].gameObject.SetActive(true);
                bombas[5].gameObject.SetActive(true);
            }
            else if (life <= 3000 & life > 2000)
            {
                ataques[4].gameObject.SetActive(false);
                bombas[4].gameObject.SetActive(false);
                bombas[5].gameObject.SetActive(false);
                ataques[3].gameObject.SetActive(true);
                bombas[0].gameObject.SetActive(true);
                bombas[1].gameObject.SetActive(true);
            }
            else if (life <= 2000 & life > 1100)
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
        else if(life <= 0 && !morreu)
        {
            Death();
            morreu = true;
        } 

        if (player.shild)
        {
            dam = 3;
        }else
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

    private void Death()
    {
       // Time.timeScale = 0f;
       // musica.Pause();
        SceneManager.LoadScene("Vitoria", LoadSceneMode.Additive);
    }
}
