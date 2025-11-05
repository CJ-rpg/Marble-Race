using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using UnityEditor.Tilemaps;
using UnityEngine;

public class TrapMove : MonoBehaviour
{
    public float speedx = 1f;
    public float speedy = 1f;
    public float maxHeight = 10;
    public float minHeight = -10;
    public float maxlength = 10;
    public float minlength = -10;

    public float delay = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speedx * Time.deltaTime, speedy * Time.deltaTime, 0);
        if (transform.position.y > maxHeight || transform.position.y < minHeight)
        {
            speedy = speedy * -1;
        }
        if (transform.position.x > maxlength || transform.position.x < minlength)
        {
            speedx = speedx * -1;
        }
    }
}
