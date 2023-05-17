using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarraVida : MonoBehaviour
{

    public Slider slide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxHealth(float health)
    {
        slide.maxValue = health;
        slide.value = health;
    }

    public void SetHealth(float health)
    {
        slide.value = health;   
    }
}
