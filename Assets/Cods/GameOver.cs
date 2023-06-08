using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Player player;
   // public AudioSource musica;
    public MenuManager menuManager;
    public GameManager gameManager;

    public GameObject panelEN;
    public GameObject panelPT;

    private void Awake()
    {
        menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();

        if(menuManager != null)
        {
            if(menuManager.EN)
            {
                panelEN.gameObject.SetActive(true);
            }else
            {
                panelPT.gameObject.SetActive(true);
            }
        }
        Cursor.visible = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(gameManager != null)
        {
            if(gameManager.fase == 1)
            {
                Time.timeScale = 1f;
                Cursor.visible = false;
                SceneManager.LoadScene("Fase1");
            }else if(gameManager.fase == 2)
            {
                Time.timeScale = 1f;
                Cursor.visible = false;
                SceneManager.LoadScene("Fase3");
            }else if(gameManager.fase==3)
            {
                Time.timeScale = 1f;
                Cursor.visible = false;
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void NextStage()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(gameManager != null)
        {
            if (gameManager.fase == 1)
            {
                Time.timeScale = 1f;
                Cursor.visible = false;
                SceneManager.LoadScene("Fase3");
            }
            else if (gameManager.fase == 2)
            {
                Time.timeScale = 1f;
                Cursor.visible = false;
                SceneManager.LoadScene("SampleScene");
            }
            else if (gameManager.fase == 3)
            {
                Time.timeScale = 1f;
                Cursor.visible = true;
                SceneManager.LoadScene("Start");
            }
        }
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
}
