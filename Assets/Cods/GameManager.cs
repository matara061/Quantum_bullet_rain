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
    public AudioSource musica;

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
            fase = 2;
        }else if (bot2 != null)
        {
            fase = 1;
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
        }else if(bot2 != null)
        {
            bossMorte = bot2.morreu;
        }

        if(bossMorte)
        {
            Time.timeScale = 0f;
            musica.Pause();
        }

        if(player.revive)
        {
            player.Revive();
            for (int i = 0; i < 3; i++)
            {
                coracoes[i].SetActive(true);
            }
            Time.timeScale = 1f;
            musica.Play();
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
            musica.Pause();
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

    
}
