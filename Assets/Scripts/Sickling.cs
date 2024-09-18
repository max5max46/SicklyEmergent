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

    [HideInInspector] public bool isSick;
    [HideInInspector] public float[] distanceFromOtherSicklings;

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

        transform.position += transform.up * Time.deltaTime * speed;
    }
}
