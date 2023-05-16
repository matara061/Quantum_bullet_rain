using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot1 : MonoBehaviour
{
    public float life = 5000; 
    public float speed;
    private float dam = 1.2f;

    public GameObject[] ataques;
    public GameObject[] bombas;

    public BulletHellSpawner hell;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // pra fazer as balas desaparecem e so mudar o tempo de viada restante 
    {
     
        if (life > 0)
        {
            if (life <= 5000 & life > 4900) // talvez de pra fazer pelo metodo de anrir uma cena em cima da outra  
            {
                 ataques[0].gameObject.SetActive(true);
                
            }
            else if (life <= 4900 & life > 4750)
            {
                ataques[1].gameObject.SetActive(true);
            }
            else if (life <= 4750 & life > 3000)
            {
                ataques[0].gameObject.SetActive(false);
                ataques[1].gameObject.SetActive(false);
                ataques[2].gameObject.SetActive(true);
                ataques[4].gameObject.SetActive(true);
            }
            else if (life <= 3000 & life > 2000)
            {
                ataques[4].gameObject.SetActive(false);
                ataques[3].gameObject.SetActive(true);
                bombas[0].gameObject.SetActive(true);
                bombas[1].gameObject.SetActive(true);
            }
            else if (life <= 2000 & life > 1100)
            {
                ataques[2].gameObject.SetActive(false);
                ataques[3].gameObject.SetActive(false);
                bombas[0].gameObject.SetActive(false);
                bombas[1].gameObject.SetActive(false);
                ataques[4].gameObject.SetActive(true);
                ataques[5].gameObject.SetActive(true);
                bombas[2].gameObject.SetActive(true);
                bombas[3].gameObject.SetActive(true);
            }
        }
        else if(life <= 0)
        {
            Death();
        } 
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
        hell.numer_of_columns = 50;
        hell.speed = 5;
        hell.speedAto = 0.5f;
        hell.color = Color.red;
        hell.lifetime = 10;
        hell.firerate = 1;
        hell.size = 0.2f;
        hell.spin_speed = 10;
    }

    public void Padrao2() // add movimento do boss 
    {
        hell.numer_of_columns = 15;
        hell.speed = 5;
        hell.speedAto = 0.5f;
        hell.color = Color.blue;
        hell.lifetime = 10;
        hell.firerate = 0.2f;
        hell.size = 0.2f;
        hell.spin_speed = 25;
    }

    public void Padrao3()
    {

    }
}
