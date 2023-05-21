using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] notas;
    public Player player;
    public Bot1 bot1;

    public int playerMortes;
    public bool bossMorte;

    private int cont = 0;

    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        bot1 = GameObject.Find("Inimigo1").GetComponent<Bot1>();
    }

    // Update is called once per frame
    void Update()
    {
  
        playerMortes = player.mortes;
        bossMorte = bot1.morreu;

        if (bossMorte)
        {
            nota();
        }
    }

    void nota()
    {
        if(playerMortes == 0)
        {
            notas[0] = GameObject.Find("A");
            notas[0].gameObject.SetActive(true);
        }
        else
            if(playerMortes >= 1 && playerMortes < 3)
        {
            notas[1] = GameObject.Find("B");
            notas[1].gameObject.SetActive(true);
        }
        else
            if (playerMortes >= 3 && playerMortes < 5)
        {
            notas[2] = GameObject.Find("C");
            notas[2].gameObject.SetActive(false);
        }
        else
            if (playerMortes >= 5)
        {
            notas[3] = GameObject.Find("D");
            notas[3].gameObject.SetActive(true);
        }
    }

}
