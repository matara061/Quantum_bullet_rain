using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Itens : MonoBehaviour
{

    public float maxHeigth;
    public float minHeigth;
    public float maxLargura;
    public float minLargura;

    public float rateSpawn;
    public float rateSpawn2;

    private float currentRateSpawn;
    private float currentRateSpawn2;

    public int maxItem;

    public GameObject prefab;
    public GameObject estrela;

    public List<GameObject> itens;
    public List<GameObject> itens2;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxItem; i++)
        {
            GameObject tempItem = Instantiate(prefab) as GameObject;
            itens.Add(tempItem);
            tempItem.SetActive(false);
        }

        GameObject tempItem2 = Instantiate(estrela) as GameObject;
        itens2.Add(tempItem2);
        tempItem2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentRateSpawn += Time.deltaTime;
        currentRateSpawn2 += Time.deltaTime;

        if (currentRateSpawn > rateSpawn)
        {
            currentRateSpawn = 0;
            Spawn();
        }

        if (currentRateSpawn2 > rateSpawn2)
        {
            currentRateSpawn2 = 0;
            Spawn2();
        }
    }

    private void Spawn()
    {
        float randPosition = Random.Range(minHeigth, maxHeigth);
        float randPosition2 = Random.Range(minLargura, maxLargura);

        GameObject tempItem = null;

        for (int i = 0; i < maxItem; i++)
        {
            if (itens[i].activeSelf == false)
            {
                tempItem = itens[i];
                break;
            }
        }

        if (tempItem != null)
        {
            tempItem.transform.position = new Vector3(randPosition2, randPosition, transform.position.z);
            tempItem.SetActive(true);
        }
    }

    private void Spawn2()
    {
        float randPosition = Random.Range(minHeigth, maxHeigth);
        float randPosition2 = Random.Range(minLargura, maxLargura);

        GameObject tempItem2 = null;

        if (itens2[0].activeSelf == false)
        {
            tempItem2 = itens2[0];
        }

        if (tempItem2 != null)
        {
            tempItem2.transform.position = new Vector3(randPosition2, randPosition, transform.position.z);
            tempItem2.SetActive(true);
        }
    }
}
