using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public MenuManager menuManager;
    // Start is called before the first frame update
    public GameObject pag1EN;
    public GameObject pag2EN;
    public GameObject pag1PT;
    public GameObject pag2PT;

    public bool pag1 = true;

    private void Awake()
    {
        menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
    }
    void Start()
    {
        if(menuManager != null)
        {
            if(menuManager.EN)
            {
                pag1EN.SetActive(true);
            }else
            {
                pag1PT.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Z))
        {
            if(pag1)
            {
                if(menuManager.EN)
                {
                    pag1EN.SetActive(false);
                    pag2EN.SetActive(true);
                    pag1 = false;
                }else
                {
                    pag1PT.SetActive(false);
                    pag2PT.SetActive(true);
                    pag1 = false;
                }
            }else
            {
                if (menuManager.EN)
                {
                    pag1EN.SetActive(true);
                    pag2EN.SetActive(false);
                    pag1 = true;
                }
                else
                {
                    pag1PT.SetActive(true);
                    pag2PT.SetActive(false);
                    pag1 = true;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("Start");
        }
    }
}
