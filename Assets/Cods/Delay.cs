using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Rank : MonoBehaviour
{
    public GameObject[] notasEN;
    public GameObject[] notasPT;
    public GameManager gameManager;
    public MenuManager menuManager;

    public TextMeshProUGUI MortesText;
    public TextMeshProUGUI MortesTextPT;

    public int playerMortes;
    private void Awake()
    {
        menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
    }

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        playerMortes = gameManager.playerMortes;

        if(menuManager != null)
        {
            if(menuManager.EN)
            {
                MortesText.text = playerMortes.ToString();
            }else
            {
                MortesTextPT.text = playerMortes.ToString();
            }
        }

        nota();
    }

    void nota()
    {
        if(menuManager != null)
        {
            if(menuManager.EN)
            {
                if (playerMortes == 0)
                {
                    notasEN[0].gameObject.SetActive(true);
                }
                else
            if (playerMortes >= 1 && playerMortes < 3)
                {
                    notasEN[1].gameObject.SetActive(true);
                }
                else
            if (playerMortes >= 3 && playerMortes < 5)
                {

                    notasEN[2].gameObject.SetActive(true);
                }
                else
            if (playerMortes >= 5)
                {

                    notasEN[3].gameObject.SetActive(true);
                }
            }else
            {
                if (playerMortes == 0)
                {
                    notasPT[0].gameObject.SetActive(true);
                }
                else
            if (playerMortes >= 1 && playerMortes < 3)
                {
                    notasPT[1].gameObject.SetActive(true);
                }
                else
            if (playerMortes >= 3 && playerMortes < 5)
                {

                    notasPT[2].gameObject.SetActive(true);
                }
                else
            if (playerMortes >= 5)
                {

                    notasPT[3].gameObject.SetActive(true);
                }
            }
        }
    }
}
