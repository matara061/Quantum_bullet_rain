using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rank : MonoBehaviour
{
    public GameObject[] notas;
    public GameManager gameManager;

    public int playerMortes;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        playerMortes = gameManager.playerMortes;

        nota();
    }

    void nota()
    {
        if (playerMortes == 0)
        {
            notas[0].gameObject.SetActive(true);
        }
        else
            if (playerMortes >= 1 && playerMortes < 3)
        {
            notas[1].gameObject.SetActive(true);
        }
        else
            if (playerMortes >= 3 && playerMortes < 5)
        {
            
            notas[2].gameObject.SetActive(true);
        }
        else
            if (playerMortes >= 5)
        {
            
            notas[3].gameObject.SetActive(true);
        }
    }
}
