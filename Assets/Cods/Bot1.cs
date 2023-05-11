using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot1 : MonoBehaviour
{
    public float life = 1000;
    public float speed;
    private float dam = 1.2f;

    public float timeCount;
    public bool timeOver;

    public GameObject[] ataques;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 1000 & life > 900) // quando desativa o objetos todas as particulas desaparecem de uma vez 
        {
            ataques[0].gameObject.SetActive(true);
        }
        else if (life <= 900 & life > 750)
        {
            ataques[1].gameObject.SetActive(true);
        }
        else if (life <= 750 & life > 550)
        {
            ataques[0].gameObject.SetActive(false);
            ataques[1].gameObject.SetActive(false);
            ataques[2].gameObject.SetActive(true);
            ataques[4].gameObject.SetActive(true);
        }
        else if (life <= 550 & life > 400)
        {
            ataques[5].gameObject.SetActive(true);
            ataques[3].gameObject.SetActive(true);
        }

        if (life <= 0)
            Death();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (life > 0)
        {
         life -= dam;

        }
        //Debug.Log("Hit");
    }

    private void Death()
    {
        Debug.Log("MORREU");
    }

    public void Padrao1()
    {
        ataques[0].gameObject.SetActive(true); // ver como add um tempo para o proximo ataque (talvez configurar isso no spawner)
        ataques[1].gameObject.SetActive(true);
    }

    public void Padrao2() // add movimento do boss 
    {
        ataques[0].gameObject.SetActive(false);
        ataques[1].gameObject.SetActive(false);
       // ataques[2].gameObject.SetActive(true);
    }

    public void Padrao3()
    {

    }

    void TimeCount()
    {
        timeOver = false;

        if (!timeOver && timeCount > 0)
        {
            timeCount -= Time.deltaTime;

            if (timeCount < 0)
            {
                timeCount = 0;
                
                timeOver = true;
                
            }
        }
    }
}
