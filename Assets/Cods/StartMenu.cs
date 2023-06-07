using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public MenuManager menuManager;

    public GameObject[] textPT;
    public GameObject[] textEN;

    public GameObject menuInicio;
    public GameObject selectEN;
    public GameObject selectPT;

    //public bool EN = true;

    private void Awake()
    {
        menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();

        CurrentLanguage();

        Cursor.visible = true;
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.X))
        {
            selectEN.SetActive(false);
            selectPT.SetActive(false);
            menuInicio.SetActive(true);
        }
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        SceneManager.LoadScene("Fase1");
    }

    public void Sair()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene("Manual");
    }

    public void BackButton()
    {
        
    }

    public void Credits()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void LanguageButton()
    {
        if(menuManager.EN)
        {
            for (int i = 0; i < 5; i++)
            {
                textEN[i].gameObject.SetActive(false);
                textPT[i].gameObject.SetActive(true);
            }
            menuManager.EN = false;
        }else
        {
            for (int i = 0; i < 5; i++)
            {
                textPT[i].gameObject.SetActive(false);
                textEN[i].gameObject.SetActive(true);
            }
            menuManager.EN = true;
        }
    }

    private void CurrentLanguage()
    {
        if (menuManager.EN)
        {
            for (int i = 0; i < 5; i++)
            {
                textEN[i].gameObject.SetActive(true);
                textPT[i].gameObject.SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                textPT[i].gameObject.SetActive(true);
                textEN[i].gameObject.SetActive(false);
            }
        }
    }

    public void SelectStage()
    {
        if (menuManager.EN)
        {
            selectEN.SetActive(true);
        }
        else
        {
            selectPT.SetActive(true);
        }
    }

    public void Fase1()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void Fase2()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Fase3()
    {
        SceneManager.LoadScene("Fase3");
    }
}
