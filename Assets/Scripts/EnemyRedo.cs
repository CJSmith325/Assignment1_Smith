using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;
using System.Globalization;
using System;


public class EnemyRedo : MonoBehaviour
{

    public float speed = 1.19f;
    Vector2 pointA;
    Vector2 pointB;

    void Start()
    {
        pointA = new Vector2(0, 0);
        pointB = new Vector2(2, 0);
    }

    void Update()
    {
        //PingPong between 0 and 1
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector2.Lerp(pointA, pointB, time);
    }
}
