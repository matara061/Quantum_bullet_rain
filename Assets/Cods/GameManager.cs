using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text timeText;
    public float timeCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount();
    }

    public void RefreshScreen()
    {
        timeText.text = timeCount.ToString("F0");
    }

    void TimeCount()
    {
        timeCount += Time.deltaTime;
        RefreshScreen();
    }
}
