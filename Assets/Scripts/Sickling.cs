using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickling : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float speed = 1;
    [SerializeField] private float distanceToKeepFromSicklings = 1;
    [SerializeField] private float distanceToKeepFromIllSicklings = 3;
    [SerializeField] private Color healthyColor;
    [SerializeField] private Color sickColor;
    [SerializeField] private float maxStepTime = 2;

    [Header("References")]
    public SicklingsManager sicklingManager;

    [HideInInspector] public bool isIll;

    private float stepTimer = 0;
    private Vector3 randomMoveDirection;
    private Vector3 moveDirection;

    private Vector3 nearestSicklingPosition;
    private float nearestSicklingDistance;
    private Vector3 nearestIllSicklingPosition;
    private float nearestIllSicklingDistance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isIll)
            transform.GetComponent<SpriteRenderer>().color = healthyColor;
        else
            transform.GetComponent<SpriteRenderer>().color = sickColor;

        nearestSicklingDistance = 10000;
        nearestIllSicklingDistance = 10000;

        stepTimer -= Time.deltaTime;

        if (stepTimer <= 0)
        {
            randomMoveDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
            stepTimer = Random.Range(0.5f, maxStepTime);
        }

        moveDirection = randomMoveDirection;

        if (!isIll)
        {
            for (int i = 0; i < sicklingManager.sicklingObjects.Length; i++)
            {
                float currentSicklingDistance = Vector3.Distance(transform.position, sicklingManager.sicklingObjects[i].transform.position);

                if (!sicklingManager.sicklingObjects[i].GetComponent<Sickling>().isIll)
                {
                    if (currentSicklingDistance < nearestSicklingDistance && currentSicklingDistance != 0)
                    {
                        nearestSicklingDistance = currentSicklingDistance;
                        nearestSicklingPosition = sicklingManager.sicklingObjects[i].transform.position;
                    }
                }
                else
                {
                    if (currentSicklingDistance < nearestIllSicklingDistance && currentSicklingDistance != 0)
                    {
                        nearestIllSicklingDistance = currentSicklingDistance;
                        nearestIllSicklingPosition = sicklingManager.sicklingObjects[i].transform.position;
                    }
                }
            }

            if (nearestSicklingDistance < distanceToKeepFromSicklings || nearestIllSicklingDistance < distanceToKeepFromIllSicklings)
            {
                if (nearestIllSicklingDistance < distanceToKeepFromIllSicklings)
                    moveDirection = (nearestIllSicklingPosition - transform.position) * -1;
                else
                    moveDirection = (nearestSicklingPosition - transform.position) * -1;
            }
        }

        // 
        transform.position += moveDirection * Time.deltaTime * speed;
    }
}
