using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    public GameObject objeto;
    public string src;

    // Start is called before the first frame update

    private void Awake()
    {
        (objeto.GetComponent(src) as MonoBehaviour).enabled = false;
    }
    void Start()
    {
       // (objeto.GetComponent(src) as MonoBehaviour).enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
