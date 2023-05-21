using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] notas;
    public Player player;
    public Bot1 bot1;

    private int cont = 0;
    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
        if (bot1.morreu && cont == 0)
        {
            nota();
            cont = 1;
        }
    }

    void nota()
    {
        if(player.mortes == 0)
        {
            notas[0] = GameObject.Find("A");
            notas[0].gameObject.SetActive(true);
        }
        else
            if(player.mortes >= 1 && player.mortes < 3)
        {
            notas[1] = GameObject.Find("B");
            notas[1].gameObject.SetActive(true);
        }
        else
            if (player.mortes >= 3 && player.mortes < 5)
        {
            notas[2] = GameObject.Find("C");
            notas[2].gameObject.SetActive(false);
        }
        else
            if (player.mortes >= 5)
        {
            notas[3] = GameObject.Find("D");
            notas[3].gameObject.SetActive(true);
        }
    }

}
