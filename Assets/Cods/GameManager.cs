using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player = null;
    public Bot1 bot1;
    public Bot2 bot2;
    public Bot3 bot3;
    public AudioSource musica;
    public AudioSource musica2;

    public GameObject som;
    public GameObject som2;

    public TextMeshProUGUI timeText;
    public float timeCount;

    public int playerMortes;
    public bool bossMorte;

    public int fase;

    public bool triger = false;

    public GameObject[] coracoes;
    public GameObject[] estrelas;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    void Start()
    {
        if (bot1 != null)
        {
            fase = 3;
        }else if (bot2 != null)
        {
            fase = 1;
        }else if(bot3 != null)
        {
            fase = 2;
        }


    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        timeText.text = timeCount.ToString("F0");

        
  
        playerMortes = player.mortes;

        if(bot1 != null)
        {
            bossMorte = bot1.morreu;
            if (bot1.life <= 2350)
            {
                som.SetActive(false);
                som2.SetActive(true);
            }else
            {
                som2.SetActive(false);
                som.SetActive(true);
            }
        }
        else if(bot2 != null)
        {
            bossMorte = bot2.morreu;
            if (bot2.life <= 2350)
            {
                som.SetActive(false);
                som2.SetActive(true);
            }
            else
            {
                som2.SetActive(false);
                som.SetActive(true);
            }
        }
        else if(bot3 != null)
        {
            bossMorte = bot3.morreu;
            if (bot3.life <= 2350)
            {
                som.SetActive(false);
                som2.SetActive(true);
            }
            else
            {
                som2.SetActive(false);
                som.SetActive(true);
            }
        }

        if(bossMorte)
        {
            Time.timeScale = 0f;
           // musica.Pause();
           PauseMusic();
        }

        if(player.revive)
        {
            player.Revive();
            for (int i = 0; i < 3; i++)
            {
                coracoes[i].SetActive(true);
            }
            Time.timeScale = 1f;
           // musica.Play();
           PlayMusic();
            triger = false;
        }

        if(!player.morreu)
        {
            if(player.currentLife == 2)
            {
                coracoes[0].gameObject.SetActive(false);
            }else if(player.currentLife == 1)
            {
                coracoes[1].gameObject.SetActive(false);
            }
        }else if(!triger)
        {
            coracoes[2].gameObject.SetActive(false);
            Time.timeScale = 0f;
            // musica.Pause();
            PauseMusic();
            triger = true;
            SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
           // Debug.Log("more");
        }

        if(player.numEstrelas >= 0)
        {
            if(player.numEstrelas == 2)
            {
                estrelas[0].gameObject.SetActive(false);
            }else if (player.numEstrelas == 1)
            {
                estrelas[1].gameObject.SetActive(false);
            }else if (player.numEstrelas == 0)
            {
                estrelas[2].gameObject.SetActive(false);
            }
        }
        
    }

    public void PauseMusic()
    {
        if (bot1 != null)
        {
            if(bot1.life <= 2350)
            {
                musica2.Pause();
            }else
            {
                musica.Pause();
            }
        }
        else if (bot2 != null)
        {
            if (bot2.life <= 2350)
            {
                musica2.Pause();
            }
            else
            {
                musica.Pause();
            }
        }
        else if (bot3 != null)
        {
            if (bot3.life <= 2350)
            {
                musica2.Pause();
            }
            else
            {
                musica.Pause();
            }
        }
    }

    public void PlayMusic()
    {
        if (bot1 != null)
        {
            if (bot1.life <= 2350)
            {
                musica2.Play();
            }
            else
            {
                musica.Play();
            }
        }
        else if (bot2 != null)
        {
            if (bot2.life <= 2350)
            {
                musica2.Play();
            }
            else
            {
                musica.Play();
            }
        }
        else if (bot3 != null)
        {
            if (bot3.life <= 2350)
            {
                musica2.Play();
            }
            else
            {
                musica.Play();
            }
        }
    }

    
}
