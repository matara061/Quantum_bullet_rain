using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot1 : MonoBehaviour
{
    public float life = 1000; //sobrevive +- 30 segundos acertando todos os tiros 
    public float life2 = 1000;
    public float life3 = 1000;
    public float life4 = 1000;
    public float life5 = 1000;
    public float speed;
    private float dam = 1.2f;

    public GameObject[] ataques;

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
            if (life <= 1000 & life > 900) // pouco tempo entre um padrao e outro  
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
        }else if(life2 > 0)
        {

        } 

        if (life5 <= 0)
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
