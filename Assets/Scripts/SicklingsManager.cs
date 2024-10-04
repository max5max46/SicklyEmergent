using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SicklingsManager : MonoBehaviour
{
    [Header("Properties")]
    public int amountOfSicklings = 10;
    public int amountOfIllSicklings = 1;

    [HideInInspector] public float healthySpeed;
    [HideInInspector] public float illSpeed;
    [HideInInspector] public bool chaseMode = false;
    [HideInInspector] public float distanceToKeepFromSicklings;
    [HideInInspector] public float distanceToKeepFromIllSicklings;
    [HideInInspector] public float distanceToGetIll;
    [HideInInspector] public float timeToGetIll;

    [Header("References")]
    [SerializeField] private GameObject sicklingPrefab;

    [HideInInspector] public Sickling[] sicklings;
    [HideInInspector] public GameObject[] sicklingObjects;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetArrays()
    {
        if (sicklingObjects.Length != 0)
            for (int i = 0; i < sicklingObjects.Length; i++)
                Destroy(sicklingObjects[i]);

        sicklings = new Sickling[amountOfSicklings];
        sicklingObjects = new GameObject[amountOfSicklings];
    }

    public void StartSim()
    {
        for (int i = 0; i < amountOfSicklings; i++)
        {
            GameObject currentSickling = Instantiate(sicklingPrefab);
            currentSickling.transform.position = new Vector3(Random.Range(-9f, 9f), Random.Range(-5f, 5f), 0);
            currentSickling.GetComponent<Sickling>().healthySpeed = healthySpeed;
            currentSickling.GetComponent<Sickling>().illSpeed = illSpeed;
            currentSickling.GetComponent<Sickling>().chaseMode = chaseMode;
            currentSickling.GetComponent<Sickling>().distanceToKeepFromSicklings = distanceToKeepFromSicklings;
            currentSickling.GetComponent<Sickling>().distanceToKeepFromIllSicklings = distanceToKeepFromIllSicklings;
            currentSickling.GetComponent<Sickling>().distanceToGetIll = distanceToGetIll;
            currentSickling.GetComponent<Sickling>().timeToGetIll = timeToGetIll;
            currentSickling.GetComponent<Sickling>().sicklingManager = this;
            sicklings[i] = currentSickling.GetComponent<Sickling>();
            sicklingObjects[i] = currentSickling;
        }

        for (int i = 0; i < amountOfIllSicklings; i++)
        {
            bool infectedASickling = false;

            while (infectedASickling == false)
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
}
