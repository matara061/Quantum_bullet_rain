using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Player player;
    public AudioSource musica;

    public GameObject[] textPT;
    public GameObject[] textEN;

    public GameObject menuEN;
    public GameObject menuPT;

    public bool EN = true;

    private void Awake()
    {
        Cursor.visible = true;
    }

    private void Start()
    {
        musica = GameObject.Find("musicaBoss").GetComponent<AudioSource>();
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        SceneManager.LoadScene("SampleScene");
    }

    public void Sair()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void Desistir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
    }

    public void Continue()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
       // player.life = 3;
       // player.timeCount = 5;
        player.revive = true;
      //  player.hit = true;
        player.morreu = false;
      //  musica.Play();
        Cursor.visible = false;
       // Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync("GameOver");



    }

    public void TutorialButton()
    {
        if(EN)
        {
            menuEN.SetActive(true);
        }else
        {
            menuPT.SetActive(true);
        }
    }

    public void BackButton()
    {
        if (EN)
        {
            menuEN.SetActive(false);
        }
        else
        {
            menuPT.SetActive(false);
        }
    }

    public void LanguageButton()
    {
        if(EN)
        {
            for (int i = 0; i < 5; i++)
            {
                textEN[i].gameObject.SetActive(false);
                textPT[i].gameObject.SetActive(true);
            }
            EN = false;
        }else
        {
            for (int i = 0; i < 5; i++)
            {
                textPT[i].gameObject.SetActive(false);
                textEN[i].gameObject.SetActive(true);
            }
            EN = true;
        }
    }
}
