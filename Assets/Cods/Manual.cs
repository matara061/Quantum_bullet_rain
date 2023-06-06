using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manual : MonoBehaviour
{

    public MenuManager menuManager;

    public GameObject manualPT;
    public GameObject manualEN;


    private void Awake()
    {
        menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
    }
    void Start()
    {
        if (menuManager != null)
        {
            if (menuManager.EN)
            {
                manualEN.SetActive(true);
            }
            else
            {
                manualPT.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("Start");
        }
    }
}
