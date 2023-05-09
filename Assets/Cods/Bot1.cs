using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot1 : MonoBehaviour
{
    public float life = 1000;
    public float speed;
    private float dam = 2.5f;
    public GameObject[] ataques;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 800 & life > 500)
        {
            Padrao1();
        }
        else if (life <= 500 & life > 250)
        {
            Padrao2();
        }
        else if (life <= 250 & life > 0)
        {
            Padrao3();
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
}
