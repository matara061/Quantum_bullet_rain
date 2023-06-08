using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject pauseMenuPT;

    public AudioSource musica;

    public Player player;

    public Bot1 Bot1;

    public Bot2 bot2;

    public Bot3 bot3;

    public MenuManager menuManager;

    public bool tuto = false;


    private void Start()
    {
        musica = GameObject.Find("musicaBoss").GetComponent<AudioSource>();

        menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
    }
    // Update is called once per frame
    void Update()
    {

        if(Bot1 != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !player.morreu && !Bot1.morreu && !tuto)
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
        else if(bot2 != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !player.morreu && !bot2.morreu && !tuto)
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
        else if (bot3 != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !player.morreu && !bot3.morreu && !tuto)
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Resume()
    {
       // pauseMenuUI.SetActive(false);
        if (menuManager.EN)
        {
            pauseMenuUI.SetActive(false);
        }
        else
        {
            pauseMenuPT.SetActive(false);
        }
        Cursor.visible = false;
        Time.timeScale = 1f;
        musica.Play();
        GameIsPaused = false;
    }

    public void Pause()
    {
        musica.Pause();
        Cursor.visible = true;
        if(menuManager.EN)
        {
            pauseMenuUI.SetActive(true);
        }else
        {
            pauseMenuPT.SetActive(true);
        }
       // pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Desistir()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("Start");
    }

    public void Turorial()
    {
        if(!tuto)
        {
            tuto = true;
        }else
            tuto = false;
    }
}
