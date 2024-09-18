using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SicklingsManager : MonoBehaviour
{
    public Sicklings[] sicklings;
    public int amountOfSicklings;
    public int amountOfIllSicklings;

    // Start is called before the first frame update
    void Start()
    {
        sicklings = new Sicklings[10];

        for (int i = 0; i < amountOfIllSicklings; i++)
        {
            bool infectedASickling = false;
            while(infectedASickling == false)
            {

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
