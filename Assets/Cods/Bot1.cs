using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot1 : MonoBehaviour
{
    public float life = 1000; 
    public GameObject[] ataques;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 800)
        {
            Padrao1();
        }
        else if (life <= 500)
        {
            Padrao2();
        }
        else if (life <= 250)
        {
            Padrao3();
        }
    }

    public void Padrao1()
    {
        ataques[0].gameObject.SetActive(true); // ver como add um tempo para o proximo ataque (talvez configurar isso no spawner)
        ataques[1].gameObject.SetActive(true);
    }

    public void Padrao2()
    {
        ataques[0].gameObject.SetActive(false);
        ataques[1].gameObject.SetActive(false);
        ataques[2].gameObject.SetActive(true);
    }

    public void Padrao3()
    {

    }
}
