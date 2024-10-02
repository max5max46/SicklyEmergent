using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickling : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float speed = 1;
    [SerializeField] private float visionDistance = 10;
    [SerializeField] private Color healthyColor;
    [SerializeField] private Color sickColor;
    [SerializeField] private float maxStepTime = 2;

    [HideInInspector] public bool isSick;
    [HideInInspector] public GameObject[] otherSicklings;

    private float stepTimer = 0;
    private Vector3 randomMoveDirection;
    private Vector3 moveDirection;
    private Vector3 nearistSickling;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isSick)
        {
            transform.GetComponent<SpriteRenderer>().color = healthyColor;
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().color = sickColor;
        }

        for (int i = 0; i < otherSicklings.Length; i++)
        {
            if (Vector3.Distance(transform.position, otherSicklings[i].transform.position) < Vector3.Distance(transform.position, nearistSickling))
            {

            }
        }

        stepTimer -= Time.deltaTime;

        if (stepTimer <= 0)
        {
            randomMoveDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
            stepTimer = Random.Range(0.5f, maxStepTime);
        }

        // Move Random
        transform.position += moveDirection * Time.deltaTime * speed;
    }
}
