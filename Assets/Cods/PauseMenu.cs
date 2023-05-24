using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public AudioSource musica;

    public Player player;

    public Bot1 Bot1;


    private void Start()
    {
        musica = GameObject.Find("musicaBoss").GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !player.morreu && !Bot1.morreu)
        {
            if (GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1f;
        musica.Play();
        GameIsPaused = false;
    }

    public void Pause()
    {
        musica.Pause();
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Desistir()
    {
        SceneManager.LoadScene("Start");
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
