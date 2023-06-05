using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    private static MenuManager instance; // vou ter que fazer esse cod procurar os outros.

    public bool EN = true;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if(instance == null)
        {
            instance = this;
        }else
        {
            Object.Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resolution1()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void Resolution2()
    {
        Screen.SetResolution(1280, 720, true);
    }

    public void Grafico1()
    {
        QualitySettings.SetQualityLevel(0, true);
    }

    public void Grafico2()
    {
        QualitySettings.SetQualityLevel(5, true);
    }
}
