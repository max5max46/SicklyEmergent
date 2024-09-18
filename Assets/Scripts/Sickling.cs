using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickling : MonoBehaviour
{
    [HideInInspector] public bool isSick;

    private float direction;
    private float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        direction = Random.Range(0f, 360f);
        transform.Rotate(new Vector3(0f, 0f, direction));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }
}
