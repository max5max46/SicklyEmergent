using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SicklingsManager : MonoBehaviour
{
    [Header("Properties")]
    public int amountOfSicklings = 10;
    public int amountOfIllSicklings = 1;

    [Header("References")]
    [SerializeField] private GameObject sicklingPrefab;

    [HideInInspector] public Sickling[] sicklings;
    [HideInInspector] public GameObject[] sicklingObjects;

    // Start is called before the first frame update
    void Awake()
    {
        sicklings = new Sickling[amountOfSicklings];
        sicklingObjects = new GameObject[amountOfSicklings];


        for (int i = 0; i < amountOfSicklings; i++)
        {
            GameObject currentSickling = Instantiate(sicklingPrefab);
            sicklings[i] = currentSickling.GetComponent<Sickling>();
            sicklingObjects[i] = currentSickling;
        }

        for (int i = 0; i < amountOfIllSicklings; i++)
        {
            bool infectedASickling = false;

            while(infectedASickling == false)
            {
                int randomIndex = Random.Range(0, sicklings.Length - 1);

                if (!sicklings[randomIndex].isIll)
                {
                    sicklings[randomIndex].isIll = true;
                    infectedASickling = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
