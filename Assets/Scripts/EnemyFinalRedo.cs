using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinalRedo : MonoBehaviour
{
    public float speed = 10.0f;
    public float ToMove;
    public Transform target1;
    public Transform target2;
    private float direction = 1.0f;
    private float currentPosition = 0.0f;

    void Update()
    {
        currentPosition += speed * Time.deltaTime;
        transform.position = Vector3.Lerp(target1.position, target2.position, Mathf.PingPong(currentPosition, 2f));
    }
}
