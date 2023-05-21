using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cenario : MonoBehaviour
{

    public float velocidadeCenario;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentCenario();
    }

    void MovimentCenario()
    {
        Vector2 deslocamento = new Vector2(0, Time.time * velocidadeCenario);
        GetComponent<Renderer>().material.mainTextureOffset = deslocamento;
    }
}
