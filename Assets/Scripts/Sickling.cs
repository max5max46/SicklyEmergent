using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickling : MonoBehaviour
{
    [Header("Properties")]
    public float healthySpeed = 1;
    public float illSpeed = 1;
    public bool chaseMode = false;
    public float distanceToKeepFromSicklings = 1;
    public float distanceToKeepFromIllSicklings = 3;
    public float distanceToGetIll = 3;
    public float timeToGetIll = 2;
    [SerializeField] private float minStepTime = 1;
    [SerializeField] private float maxStepTime = 3;
    [SerializeField] private float negXBorder = -5;
    [SerializeField] private float posXBorder = 5;
    [SerializeField] private float negYBorder = -5;
    [SerializeField] private float posYBorder = 5;
    [SerializeField] private Color healthyColor;
    [SerializeField] private Color sickColor;

    [HideInInspector] public SicklingsManager sicklingManager;
    [HideInInspector] public bool isIll;

    private float speed;

    private float stepTimer;
    private float illTimer;
    private Vector3 randomMoveDirection;
    private Vector3 moveDirection;

    private Vector3 nearestSicklingPosition;
    private float nearestSicklingDistance;
    private Vector3 nearestIllSicklingPosition;
    private float nearestIllSicklingDistance;

    // Start is called before the first frame update
    void Start()
    {
        stepTimer = 0;
        illTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isIll)
        {
            speed = healthySpeed;
            transform.GetComponent<SpriteRenderer>().color = healthyColor;
        }
        else
        {
            speed = illSpeed;
            transform.GetComponent<SpriteRenderer>().color = sickColor;
        }

        nearestSicklingDistance = 10000;
        nearestIllSicklingDistance = 10000;

        stepTimer -= Time.deltaTime;
        illTimer += Time.deltaTime;

        if (illTimer > timeToGetIll && !isIll)
        {
            isIll = true;
        }

        if (stepTimer <= 0)
        {
            randomMoveDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
            stepTimer = Random.Range(minStepTime, maxStepTime);
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
                    moveDirection = (nearestIllSicklingPosition - transform.position).normalized * -1;
                else
                    moveDirection = (nearestSicklingPosition - transform.position).normalized * -1;
            }

            if (nearestIllSicklingDistance > distanceToGetIll)
                illTimer = 0;
        }
        else if (chaseMode)
        {
            for (int i = 0; i < sicklingManager.sicklingObjects.Length; i++)
            {
                if (!sicklingManager.sicklingObjects[i].GetComponent<Sickling>().isIll)
                {
                    float currentSicklingDistance = Vector3.Distance(transform.position, sicklingManager.sicklingObjects[i].transform.position);
                    if (currentSicklingDistance < nearestSicklingDistance && currentSicklingDistance != 0)
                    {
                        nearestSicklingDistance = currentSicklingDistance;
                        nearestSicklingPosition = sicklingManager.sicklingObjects[i].transform.position;

                    }
                }
            }
            if (nearestSicklingDistance < 10000)
                moveDirection = (nearestSicklingPosition - transform.position).normalized;
        }

        transform.position += moveDirection * Time.deltaTime * speed;

        if (transform.position.x < negXBorder)
            transform.position = new Vector3(posXBorder - 0.5f, transform.position.y, 0);

        if (transform.position.x > posXBorder)
            transform.position = new Vector3(negXBorder + 0.5f, transform.position.y, 0);

        if (transform.position.y < negYBorder)
            transform.position = new Vector3(transform.position.x, posYBorder - 0.5f, 0);

        if (transform.position.y > posYBorder)
            transform.position = new Vector3(transform.position.x, negYBorder + 0.5f, 0);
    }
}
