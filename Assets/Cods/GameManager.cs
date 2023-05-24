using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Bot1 bot1;
    public AudioSource musica;

    public TextMeshProUGUI timeText;
    public float timeCount;

    public int playerMortes;
    public bool bossMorte;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>(); // mudar dps
        bot1 = GameObject.Find("Inimigo1").GetComponent<Bot1>();

        
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        timeText.text = timeCount.ToString("F0");
  
        playerMortes = player.mortes;
        bossMorte = bot1.morreu;

        if(bossMorte)
        {
            Time.timeScale = 0f;
            musica.Pause();
        }
        
    }

    
}
